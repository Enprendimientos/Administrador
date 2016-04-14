Option Strict Off
Option Explicit Off

Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Xml
Imports System.IO

Public Class cm_tablaResultado

    Private dtg As DataGrid
    Private hashColumnas As Hashtable
    Private hashControles As Hashtable
    Private _VisibleHeaders As Boolean = True
    Private _DataSource As Object
    Private _ID As String
    Private _NombreBaseHidden As String
    Public _SoloSelecciones As Boolean

    Public Enum TypeControl
        CheckBox = 0
    End Enum

    Public Sub New(ByVal ID As String, ByVal DataSource As Object)
        dtg = New DataGrid
        _DataSource = DataSource
        _ID = ID
        hashColumnas = New Hashtable
        hashControles = New Hashtable
    End Sub


    Public Property CssClass() As String
        Get
            Return dtg.CssClass
        End Get
        Set(ByVal Value As String)
            dtg.CssClass = Value
        End Set
    End Property

    Public Property ItemCssClass() As String
        Get
            Return dtg.ItemStyle.CssClass
        End Get
        Set(ByVal Value As String)
            dtg.ItemStyle.CssClass = Value
        End Set
    End Property

    Public Property HeaderCssClass() As String
        Get
            Return dtg.HeaderStyle.CssClass
        End Get
        Set(ByVal Value As String)
            dtg.HeaderStyle.CssClass = Value
        End Set
    End Property

    Public Property VisibleHeaders() As Boolean
        Get
            Return _VisibleHeaders
        End Get
        Set(ByVal Value As Boolean)
            _VisibleHeaders = Value
        End Set
    End Property

    Public Property NombreBaseHidden() As String
        Get
            Return _NombreBaseHidden
        End Get
        Set(ByVal Value As String)
            _NombreBaseHidden = Value
        End Set
    End Property

    Public Property SoloSelecciones() As Boolean
        Get
            Return Me._SoloSelecciones
        End Get
        Set(ByVal Value As Boolean)
            _SoloSelecciones = Value
        End Set
    End Property

    Public Property DataSource() As Object
        Get
            Return _DataSource
        End Get
        Set(ByVal Value As Object)
            _DataSource = Value
        End Set
    End Property

    Public Sub addColumn(ByVal HeaderText As String, ByVal DataSouceField As String, ByVal Visible As Boolean) ', ByVal ColumnWidth As Unit
        Dim est As New EstructuraColumna
        est.HeaderText = HeaderText
        est.DataSouceField = DataSouceField
        est.Visible = Visible
        'est.Width = ColumnWidth
        hashColumnas.Add(HeaderText, est)
    End Sub

    Public Sub addColumn(ByVal HeaderText As String, ByVal Control As TypeControl, ByVal DataKeyField As String, ByVal DataSouceField As String) ', ByVal ColumnWidth As Unit
        Dim est As New EstructuraControl
        est.DataKeyField = DataKeyField
        est.DataSouceField = DataSouceField
        est.TypeControl = Control
        est.HeaderText = HeaderText
        'est.Width = ColumnWidth
        hashControles.Add(HeaderText, est)
    End Sub

    Public Overrides Function ToString() As String
        Dim tabla As String = BuildTable()
        Dim valores As String = JoinValores()
        'Dim doc As XmlDocument = BuildXmlDocument()
        Dim doc As New XmlDocument
        Dim xmlData As String
        Dim elem As XmlElement
        xmlData = "<xmlobjeto></xmlobjeto>"
        doc.Load(New StringReader(xmlData))
        elem = doc.CreateElement("objeto")
        elem.InnerText = tabla
        doc.DocumentElement.AppendChild(elem)
        elem = doc.CreateElement("valores")
        elem.InnerText = valores
        doc.DocumentElement.AppendChild(elem)
        Return doc.OuterXml
    End Function

    Private Function JoinValores()
        Dim join As String = ""
        Dim dtgDt As DataTable = CType(dtg.DataSource, DataTable)
        For Each di As DictionaryEntry In Me.hashControles
            Dim ec As EstructuraControl = di.Value
            For Each dr As DataRow In dtgDt.Rows
                If Not ec.DataSouceField Is String.Empty AndAlso ec.DataSouceField <> "" AndAlso Logic.Init(dr(ec.DataSouceField)) Then
                    If join = "" Then
                        join &= dr(ec.DataKeyField)
                    Else
                        join &= "," & dr(ec.DataKeyField)
                    End If
                End If
            Next
        Next
        Return join
    End Function

    Private Function BuildTable() As String
        Dim dc As BoundColumn
        Dim tc As TemplateColumn
        dtg.ID = _ID
        dtg.EnableViewState = False
        dtg.AllowPaging = False
        dtg.AllowSorting = False
        dtg.AutoGenerateColumns = False
        dtg.Width = Unit.Percentage(100)
        dtg.ShowHeader = _VisibleHeaders

        For Each di As DictionaryEntry In Me.hashColumnas
            Dim ec As EstructuraColumna = di.Value
            dc = New BoundColumn
            dc.DataField = CType(ec.DataSouceField, String)
            dc.HeaderText = CType(ec.HeaderText, String)
            dc.Visible = ec.Visible
            'dc.ItemStyle.Width = ec.Width
            dtg.Columns.Add(dc)
        Next
        tc = New TemplateColumn
        For Each di As DictionaryEntry In Me.hashControles
            Dim ec As EstructuraControl = di.Value
            tc.ItemTemplate = New DataGridTemplate(ListItemType.Item, ec.TypeControl, ec.DataKeyField, ec.DataSouceField, _NombreBaseHidden, _SoloSelecciones)
            tc.ItemTemplate.InstantiateIn(dtg)
            tc.HeaderText = CType(ec.HeaderText, String)
            tc.ItemStyle.HorizontalAlign = HorizontalAlign.Center
            'tc.ItemStyle.Width = ec.Width
            dtg.Columns.Add(tc)
        Next
        dtg.DataSource = _DataSource
        dtg.DataBind()

        Dim tw As System.IO.StringWriter = New System.IO.StringWriter
        Dim render As New Web.UI.HtmlTextWriter(tw)
        dtg.RenderControl(render)
        Return tw.ToString()
    End Function

    Private Class EstructuraControl
        Public DataKeyField As String
        Public DataSouceField As String
        Public TypeControl As TypeControl
        Public HeaderText As String
        Public Width As Unit

    End Class

    Private Class EstructuraColumna
        Public HeaderText As String
        Public DataSouceField As String
        Public Visible As Boolean
        Public Width As Unit
    End Class

    Private Class DataGridTemplate
        Implements ITemplate
        Private _templateType As ListItemType
        Private _columnName As String
        Private _tipoControl As cm_tablaResultado.TypeControl
        Private _DataKeyField As String
        Private _DataSouceField As String
        Private _NombreBaseHidden As String
        Private _CargaSoloSelecciones As Boolean

        Sub New(ByVal type As ListItemType, ByVal TipoControl As cm_tablaResultado.TypeControl, ByVal DataKeyField As String, ByVal DataSouceField As String, ByVal NombreBaseHidden As String, ByVal CargaSoloSelecciones As Boolean)
            _templateType = type
            _DataKeyField = DataKeyField
            _DataSouceField = DataSouceField
            _NombreBaseHidden = NombreBaseHidden
            _CargaSoloSelecciones = CargaSoloSelecciones
        End Sub

        Sub InstantiateIn(ByVal container As Control) _
           Implements ITemplate.InstantiateIn
            Select Case _templateType
                Case ListItemType.Item
                    Select Case _tipoControl
                        Case cm_tablaResultado.TypeControl.CheckBox
                            Dim chk As New CheckBox
                            AddHandler chk.DataBinding, AddressOf BindCheckBox
                            container.Controls.Add(chk)
                    End Select
            End Select
        End Sub

        Public Sub BindCheckBox(ByVal sender As Object, ByVal e As EventArgs)
            Dim chk As CheckBox = CType(sender, CheckBox)
            Dim container As DataGridItem = CType(chk.NamingContainer, DataGridItem)
            Dim identificador As String = CType(CType(container.DataItem, DataRowView).Row.Item(_DataKeyField), String)
            If Not _DataSouceField Is String.Empty AndAlso _DataSouceField <> "" Then
                chk.Checked = CType(Logic.Init(CType(container.DataItem, DataRowView).Row.Item(_DataSouceField)), Boolean)
            Else
                chk.Checked = False
            End If
            chk.Attributes.Add("onclick", "javascript:__storedCheckSelection(this, " & identificador & ", '" & _NombreBaseHidden & "', " & _CargaSoloSelecciones.ToString.ToLower & ");")
        End Sub

    End Class



End Class



