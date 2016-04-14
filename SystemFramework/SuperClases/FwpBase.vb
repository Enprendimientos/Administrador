Imports Fwp.common
Imports System.IO
Imports Zip = ICSharpCode.SharpZipLib.Zip.Compression

Public Class FwpBase
    Inherits System.Web.UI.Page
    Private _Mtn_grabar As FwpServerControls.FwpButton
    Private _Mtn_eliminar As FwpServerControls.FwpButton
    Private _Mtn_volver As FwpServerControls.FwpButton
    Private _PermisoAcceso As String
    Private _PermisoCrear As String
    Private _PermisoModificar As String

    Private _PermisoEliminar As String
    Private _Dtg_Retorno As String
    Private _Retorno As String
    Private _Hidden_ID As System.Web.UI.HtmlControls.HtmlInputHidden
    Private _FwpDataGrid As FwpServerControls.FwpDataGridDataBound
    Private _Columna As Integer
    Private _TipoOrigen As OrigenSolicitud
    Protected FwpMemento As Navegacion
    'Protected _Mtn_grabarVolver As FwpServerControls.FwpButton
    'Protected _TieneGuargarVolver As Boolean = True

    Private _Mtn_grabarVolver As FwpServerControls.FwpButton
    Private _TieneGuargarVolver As Boolean = True
    Private _EsExcel As Boolean
    Private _ClassNavegacio As Navegacion

    Private Const TextBtnGravar As String = "Grabar"
    Private Const TextBtnGravarAgregarDetalle As String = "GrabarYagregarDetalle"
    Private Const TextBtnGravarVolver As String = "Grabar y volver"
    Private Const TextBtnModificar As String = "Modificar"
    Private Const TextBtnModificarVolver As String = "Modificar y volver"
    Private Const TextBtnEliminar As String = "Eliminar"
    Private Const TextBtnLimpiar As String = "Limpiar"
    Private Const TextBtnVolver As String = "Volver"
    Private Const TextBtnCerrar As String = "Cerrar"
    Private _MySessionID As String
    Private _URL As String
    Private _HoraIni As DateTime

    Protected Sub New()
        MyBase.New()
        _ClassNavegacio = New Navegacion
    End Sub
    Public Overrides Sub Dispose()
        GC.Collect()
    End Sub

    Protected Sub Inicia()
        Me._HoraIni = Now()
        Me._URL = Me.Request.RawUrl
        Me._MySessionID = Session.SessionID
        If Not FWPConfiguration.Item(Path.GetFileName(Me.Request.RawUrl), Me._MySessionID) Is Nothing Then
            Me.FwpMemento = FWPConfiguration.Item(Path.GetFileName(Me.Request.RawUrl), Me._MySessionID)
            Me.Navegaciones.KeyConfiguracion = Path.GetFileName(Me.Request.RawUrl)
            Me.TipoOrigen = Me.FwpMemento.OrigenSolicitud
            Me.Navegaciones.CabeceraDetalle.Formulario = Me.FwpMemento.CabeceraDetalle.Formulario
        Else
            Me.FwpMemento = New Navegacion
            Me.FwpMemento.KeyConfiguracion = Path.GetFileName(Me.Request.RawUrl)
            Me.TipoOrigen = FwpBase.OrigenSolicitud.SysHelp
            Me.Navegaciones.CabeceraDetalle.Formulario = Me.FwpMemento.CabeceraDetalle.Formulario.Normal
        End If
        Page.RegisterClientScriptBlock("autocomplete", Js.AbreScript & "document.getElementById(""" & Page.Form.ClientID & """).autocomplete=""off""" & Js.CierraScript)
        WriteLog()
    End Sub

    Protected Function Finaliza() As Boolean
        WriteLogFin()
    End Function

    Private Function RegXPagGrilla() As Integer
        Dim rxp As Integer
        Try
            Dim ns As String = NombreSesionGrilla() & "Exc"
            If Not Session(ns) Is Nothing Then
                Dim xmlDoc As New Xml.XmlDocument

                xmlDoc.LoadXml(Session(ns))
                rxp = xmlDoc.FirstChild.ChildNodes(2).InnerText
            End If
        Catch : End Try
        Return rxp
    End Function

    'Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object
    '    'Dim viewState As String = Request.Form("__VSTATE")
    '    'Dim bytes() As Byte = Convert.FromBase64String(viewState)
    '    ''Dim c = Compresion.Compress
    '    'bytes = Compresion.Decompress(bytes)
    '    'Dim formatter As New System.Web.UI.LosFormatter
    '    'Return formatter.Deserialize(Convert.ToBase64String(bytes))
    'End Function

    'Protected Overrides Sub SavePageStateToPersistenceMedium(ByVal viewState As Object)
    '    'Dim formatter As New System.Web.UI.LosFormatter
    '    'Dim writer As New StringWriter
    '    'formatter.Serialize(writer, viewState)
    '    'Dim viewStateString As String = writer.ToString()
    '    'Dim bytes() As Byte = Convert.FromBase64String(viewStateString)
    '    ''Dim c As New Compresion.Compressor
    '    'bytes = Compresion.Compress(bytes)
    '    'RegisterHiddenField("__VSTATE", Convert.ToBase64String(bytes))
    'End Sub

    Private Function CargaDialog() As String
        Dim s As String = "<div id=""vid_fondo"" style=""DISPLAY: none; Z-INDEX: 9999; FILTER: alpha(opacity=20); LEFT: 0px; WIDTH: 100px; POSITION: absolute; TOP: 0px; HEIGHT: 100px; BACKGROUND-COLOR: #000000; moz-opacity: 0.2; opacity: 0.2""></div>" & vbCrLf
        s &= "<DIV style=""Z-INDEX: 9999; POSITION: absolute; BACKGROUND-COLOR: transparent; DISPLAY: none; WIDTH: 300px; HEIGHT: 30px; TOP: 10px; LEFT: 300px"" id=""vid_excel"">" & vbCrLf
        s &= "<TABLE style=""BORDER-BOTTOM: red thin solid; BORDER-LEFT: red thin solid; BACKGROUND-COLOR: lightyellow; WIDTH: 100%; HEIGHT: 20px; BORDER-TOP: red thin solid; BORDER-RIGHT: red thin solid"" id=""Table999"" border=""0"" cellSpacing=""5"" cellPadding=""5"" width=""100%"">" & vbCrLf
        s &= "<TR>" & vbCrLf
        s &= "	<TD colspan=""2"" class=""dg_titulo"" align=""center"">Descarga de Archivo Excel</TD></TR>" & vbCrLf
        s &= "<TR>" & vbCrLf
        s &= "	<TD style=""HEIGHT: 34px"" align=""center"">" & vbCrLf
        s &= "		<TABLE id=""Table9999"" cellSpacing=""0"" cellPadding=""0"" border=""0"">" & vbCrLf
        s &= "			<TR>" & vbCrLf
        s &= "				<TD><IMG class=""btnIz"" height=""25"" alt="""" src=""../utilitarios/clases/desktop/examples/desktop/images/s.gif"" width=""4""></TD>" & vbCrLf
        s &= "				<TD><INPUT class=""man_boton"" id=""btn_excelx"" style=""WIDTH: 100px; HEIGHT: 56px"" onClick=""window.open(document.getElementById('hidden_xexcelx').value);document.getElementById('vid_excel').style.display = 'none';document.getElementById('vid_fondo').style.display = 'none';"" tabIndex=""2"" type=""button"" value=""Bajar Excel"" name=""btn_excelx""></TD>" & vbCrLf
        s &= "				<TD><IMG class=""btnDe"" height=""25"" alt="""" src=""../utilitarios/clases/desktop/examples/desktop/images/s.gif"" width=""4""></TD>" & vbCrLf
        s &= "        			</TR>" & vbCrLf
        s &= "		</TABLE></TD>" & vbCrLf
        s &= "	<TD style=""HEIGHT: 34px"" align=""center"">" & vbCrLf
        s &= "		<TABLE id=""Table99999"" cellSpacing=""0"" cellPadding=""0"" border=""0"">" & vbCrLf
        s &= "		<TR>" & vbCrLf
        s &= "			<TD><IMG class=""btnIz"" height=""25"" alt="""" src=""../utilitarios/clases/desktop/examples/desktop/images/s.gif"" width=""4""></TD>" & vbCrLf
        s &= "			<TD><INPUT class=""man_boton"" id=""btn_cerrx"" style=""WIDTH: 100px; HEIGHT: 56px"" onClick=""if (document.getElementById('vid_excel').style.display == ''){document.getElementById('vid_excel').style.display = 'none';document.getElementById('vid_fondo').style.display = 'none';}else{document.getElementById('vid_excel').style.display = '';document.getElementById('vid_fondo').style.display = '';}"" tabIndex=""2"" type=""button"" value=""Cerrar"" name=""btn_cerrx""></TD>" & vbCrLf
        s &= "			<TD><IMG class=""btnDe"" height=""25"" alt="""" src=""../utilitarios/clases/desktop/examples/desktop/images/s.gif"" width=""4""></TD>" & vbCrLf
        s &= "		</TR>" & vbCrLf
        s &= "		</TABLE></TD>" & vbCrLf
        s &= "</TR>" & vbCrLf
        s &= "</TABLE></DIV>"
        Return s
    End Function
    Protected Sub NavegacionAlmacena(ByVal Navegacion As FwpServerControls.FwpDataGridDataBound.Navegacion, ByVal NombreSesion As String)

        Dim NavegacionXML As String = "<xml>"
        NavegacionXML &= "<filtros>"
        For i As Integer = 0 To Navegacion.Filtros.Count - 1
            Select Case Navegacion.Filtros(i).TipoFiltro
                Case FwpServerControls.Filtros.Tipo.Date
                    NavegacionXML &= "<" & Navegacion.Filtros(i).ID & " type=""Date"">" & Navegacion.Filtros(i).DFecha.ToShortDateString & "|" & Navegacion.Filtros(i).HFecha.ToShortDateString & "</" & Navegacion.Filtros(i).ID & ">"
                Case FwpServerControls.Filtros.Tipo.Logic
                    NavegacionXML &= "<" & Navegacion.Filtros(i).ID & " type=""Logic"">" & Navegacion.Filtros(i).TrueFalse & "</" & Navegacion.Filtros(i).ID & ">"
                Case FwpServerControls.Filtros.Tipo.Numeric
                    NavegacionXML &= "<" & Navegacion.Filtros(i).ID & " type=""Numeric"">" & Navegacion.Filtros(i).Text & "</" & Navegacion.Filtros(i).ID & ">"
                Case FwpServerControls.Filtros.Tipo.Autocompletar, FwpServerControls.Filtros.Tipo.SysHelp
                    NavegacionXML &= "<" & Navegacion.Filtros(i).ID & " type=""Autocompletar"" ProcesoAjax=""" & Navegacion.Filtros(i).ProcesoAjax & """>" & Navegacion.Filtros(i).IDValue & "</" & Navegacion.Filtros(i).ID & ">"
                Case FwpServerControls.Filtros.Tipo.Text
                    NavegacionXML &= "<" & Navegacion.Filtros(i).ID & " type=""Text"">" & Navegacion.Filtros(i).Text & "</" & Navegacion.Filtros(i).ID & ">"
            End Select
        Next
        NavegacionXML &= "</filtros>"
        NavegacionXML &= "<Pagina>" & Navegacion.Pagina.ToString & "</Pagina>"
        NavegacionXML &= "<PageSize>" & Navegacion.RegxPag.ToString & "</PageSize>"
        NavegacionXML &= "<Retorno>" & Navegacion.Retorno & "</Retorno>"
        NavegacionXML &= "<SpExcel>" & Navegacion.sp & "</SpExcel>"
        NavegacionXML &= "<Criterio>" & Navegacion.Criterio.ToString & "</Criterio>"
        NavegacionXML &= "<colvisibles></colvisibles>"
        NavegacionXML &= "<coltext></coltext>"
        NavegacionXML &= "<CriterioOrden>" & Navegacion.CriterioOrden.ToString & "</CriterioOrden>"
        NavegacionXML &= "<CriterioNombreColumna>" & Navegacion.CriterioNombreColumna & "</CriterioNombreColumna>"
        NavegacionXML &= "</xml>"
        Session(NombreSesion & "Personalizado") = NavegacionXML
    End Sub

    Protected Function NavegacionObtiene(ByVal NombreSesion As String) As FwpServerControls.FwpDataGridDataBound.Navegacion
        Dim exc As FwpServerControls.FwpDataGridDataBound.Navegacion
        If Not Session(NombreSesion & "Personalizado") Is Nothing Then
            Dim xmlDoc As New Xml.XmlDocument
            xmlDoc.LoadXml(Session(NombreSesion & "Personalizado"))
            Dim fil As Xml.XmlNodeList = xmlDoc.FirstChild.FirstChild.ChildNodes
            Dim filNav As FwpServerControls.Filtros
            Dim Coll As New FwpServerControls.TexBoxFilterCollection
            For i As Integer = 0 To fil.Count - 1
                filNav = New FwpServerControls.Filtros
                Select Case fil(i).Attributes(0).Value
                    Case "Date"
                        filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Date
                        filNav.DFecha = Split(fil(i).InnerText, "|")(0).ToString
                        filNav.HFecha = Split(fil(i).InnerText, "|")(1).ToString
                    Case "Logic"
                        filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Logic
                        filNav.TrueFalse = CByte(IIf(fil(i).InnerText = "", 2, fil(i).InnerText))
                    Case "Numeric"
                        filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Numeric
                        filNav.Value = CDec(IIf(fil(i).InnerText = "", 0, fil(i).InnerText))
                    Case "Autocompletar"
                        filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Autocompletar
                        filNav.IDValue = CInt(IIf(fil(i).InnerText = "", 0, fil(i).InnerText))
                        filNav.ProcesoAjax = fil(i).Attributes(1).Value
                    Case "Text"
                        filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Text
                        filNav.Text = fil(i).InnerText
                End Select
                filNav.ID = fil(i).Name
                Coll.Add(filNav)
            Next
            exc = New FwpServerControls.FwpDataGridDataBound.Navegacion(CInt(xmlDoc.FirstChild.ChildNodes(1).InnerText), CInt(xmlDoc.FirstChild.ChildNodes(2).InnerText), "", Coll, xmlDoc.FirstChild.ChildNodes(4).InnerText, CInt(xmlDoc.FirstChild.ChildNodes(5).InnerText), Nothing, Nothing, HomologaOrdenExcel(xmlDoc.FirstChild.ChildNodes(8).InnerText), xmlDoc.FirstChild.ChildNodes(9).InnerText)
        End If
        Return exc
    End Function

    Private Function WriteLog(Optional ByVal exc As String = "") As Boolean
        Dim sw As StreamWriter
        Try
            Dim FilePath As String = FWPConfiguration.AppSettings("DirecSitio") & "logs\log" & Replace(Replace(Now.Date, "-", ""), "/", "") & ".txt"
            If Not IO.File.Exists(FilePath) Then
                Dim fi As IO.FileStream = IO.File.Create(FilePath)
                fi.Close()
            End If
            sw = File.AppendText(FilePath)
            sw.WriteLine(FWPConfiguration.Cons_User(Session.SessionID) & ";" & Now & ";" & Me._URL & ";" & RegXPagGrilla() & ";" & exc & ";entrada")
            sw.Flush()
            sw.Close()
        Catch ex As Exception
            Try
                sw.Close()
            Catch
            End Try
        End Try
    End Function



    Private Function WriteLogFin() As Boolean
        Dim sw As StreamWriter
        Try
            Dim FilePath As String = FWPConfiguration.AppSettings("DirecSitio") & "\log" & Replace(Replace(Now.Date, "-", ""), "/", "") & ".txt"
            If Not IO.File.Exists(FilePath) Then
                Dim fi As IO.FileStream = IO.File.Create(FilePath)
                fi.Close()
            End If
            sw = File.AppendText(FilePath)
            sw.WriteLine(FWPConfiguration.Cons_User(Session.SessionID) & ";" & Now & ";" & Me._URL & ";0;;" & "salida;" & DateDiff(DateInterval.Second, Me._HoraIni, Now()))
            sw.Flush()
            sw.Close()
        Catch ex As Exception
            sw.Close()
        End Try
    End Function

    Public ReadOnly Property NombreSesionGrilla() As String
        Get
            Dim limp1 As String = Replace(Replace(Me.Page.Request.RawUrl, ".", "_"), "/", "_")
            Dim rurl As String
            If InStr(limp1, "?") > 0 Then
                rurl = Strings.Left(limp1, InStr(limp1, "?") - 1)
            Else
                rurl = limp1
            End If
            Return "FwpDataGridDataBound1" & "_" & rurl & "_" & "fwp_navegacion"
        End Get
    End Property

    Protected Property MySessionID() As String
        Get
            If Me._MySessionID Is Nothing Or Me._MySessionID = "" Then
                Me._MySessionID = Session.SessionID
            End If
            Return Me._MySessionID
        End Get
        Set(ByVal Value As String)
            _MySessionID = Value
        End Set
    End Property

    Public Class Navegacion
        Private _Retorno As String = ""
        Private _OrigenSolicitud As OrigenSolicitud = OrigenSolicitud.Normal
        Private _ArrayParametros As Hashtable
        Private _ID As Integer
        Private _KeyConfiguracion As String = ""
        Private _Descipcion As String
        Private _CabeceraDetalle As DatosCabeceraDetalle
        Private _KeyContenedor As String = ""
        Private _ArrayRelacionados As ArrayList

        Public Sub New()
            _CabeceraDetalle = New DatosCabeceraDetalle
            _ArrayParametros = New Hashtable
            _ArrayRelacionados = New ArrayList
        End Sub

        Public Property Retorno() As String
            Get
                Return _Retorno
            End Get
            Set(ByVal Value As String)
                _Retorno = Value
            End Set
        End Property

        Public Property OrigenSolicitud() As OrigenSolicitud
            Get
                Return _OrigenSolicitud
            End Get
            Set(ByVal Value As OrigenSolicitud)
                _OrigenSolicitud = Value
            End Set
        End Property

        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal Value As Integer)
                _ID = Value
            End Set
        End Property

        'Public Function ParametrosAdd(ByVal Key As String, ByVal Value As String) As Boolean

        'End Function
        Public Property Parametro(ByVal Key As String) As Object
            Get
                Return _ArrayParametros(Key)
            End Get
            Set(ByVal Value As Object)
                If _ArrayParametros.Contains(Key) Then
                    _ArrayParametros.Remove(Key)
                End If
                _ArrayParametros.Add(Key, Value)
            End Set
        End Property

        Public Property Parametros() As Hashtable
            Get
                Return _ArrayParametros
            End Get
            Set(ByVal Value As Hashtable)
                _ArrayParametros = Value
            End Set
        End Property


        Public Function ParametroRemove(ByVal Key As String) As Object
            If _ArrayParametros.Contains(Key) Then
                _ArrayParametros.Remove(Key)
            End If
        End Function

        Public Property KeyConfiguracion() As String
            Get
                Return _KeyConfiguracion
            End Get
            Set(ByVal Value As String)
                _KeyConfiguracion = Value
            End Set
        End Property


        Public Sub AddRelacionados(ByVal Key As String)
            If Not Me._ArrayRelacionados.Contains(Key) Then
                Me._ArrayRelacionados.Add(Key)
            End If
        End Sub

        Public Function ItemRelacionados(ByVal Index As Integer) As String
            Return CStr(_ArrayRelacionados(Index))
        End Function


        Public Function Relacionados() As ArrayList
            Return _ArrayRelacionados
        End Function



        Public ReadOnly Property CabeceraDetalle() As DatosCabeceraDetalle
            Get
                Return _CabeceraDetalle
            End Get
        End Property

        Public Class DatosCabeceraDetalle
            Private _Id As String
            Private _Descripcion As String
            Private _Formulario As TipoFormulario

            Enum TipoFormulario
                Normal = 0
                Cabecera = 1
                Detalle = 2
            End Enum

            Public Property Formulario() As TipoFormulario
                Get
                    Return _Formulario
                End Get
                Set(ByVal Value As TipoFormulario)
                    _Formulario = Value
                End Set
            End Property

            Public Property Id() As String
                Get
                    Return _Id
                End Get
                Set(ByVal Value As String)
                    _Id = Value
                End Set
            End Property

            Public Property Descripcion() As String
                Get
                    Return _Descripcion
                End Get
                Set(ByVal Value As String)
                    _Descripcion = Value
                End Set
            End Property

        End Class
    End Class

    Protected Sub Redirec(ByVal Url As String)
        RememberIn(Path.GetFileName(Url))
        If Left(Url, 1) <> "/" Then Url = "/" & Url
        Response.Redirect(FWPConfiguration.DirecBase & Url)
    End Sub

    Protected Sub RememberIn(ByVal Key As String)

        'Verifica que si la instancia existe y agrega paginas relacionadas para el control de basura en la configuracion
        If FWPConfiguration.Contains(Me.MySessionID) Then
            Dim hash As FWPSession = FWPConfiguration.Item(Me.MySessionID)
            If hash.Contains(_ClassNavegacio.KeyConfiguracion) Then
                Dim AddMemento As Navegacion = hash.Item(_ClassNavegacio.KeyConfiguracion)
                AddMemento.AddRelacionados(Key)
                hash.Item(_ClassNavegacio.KeyConfiguracion) = AddMemento
                FWPConfiguration.Item(Me.MySessionID) = hash
            End If
        End If

        'Crea o agrega elementos a la configuracion
        If FWPConfiguration.Contains(Me.MySessionID) Then
            Dim hash As FWPSession = FWPConfiguration.Item(Me.MySessionID)
            If hash.Contains(Key) Then
                Dim Mem As Navegacion = hash.Item(Key)
                If Mem.CabeceraDetalle.Formulario.Detalle Then
                    If Not _ClassNavegacio.CabeceraDetalle.Id Is Nothing Then
                        Mem.CabeceraDetalle.Id = _ClassNavegacio.CabeceraDetalle.Id
                    End If
                    If Not _ClassNavegacio.CabeceraDetalle.Descripcion Is Nothing Then
                        Mem.CabeceraDetalle.Descripcion = _ClassNavegacio.CabeceraDetalle.Descripcion
                    End If
                End If
                Mem.OrigenSolicitud = _ClassNavegacio.OrigenSolicitud
                Mem.Retorno = _ClassNavegacio.Retorno
                Mem.ID = _ClassNavegacio.ID
                Dim diMem As Hashtable = Mem.Parametros

                Try
                    For Each di As DictionaryEntry In _ClassNavegacio.Parametros
                        If diMem.Contains(di.Key) Then
                            diMem(di.Key) = di.Value
                        End If
                    Next
                Catch : End Try
                'For Each di As DictionaryEntry In _ClassNavegacio.Parametros
                '    If diMem.Contains(di.Key) Then
                '        diMem(di.Key) = di.Value
                '    End If
                'Next
                hash.Item(Key) = Mem
                FWPConfiguration.Item(Me.MySessionID) = hash
            Else
                hash = FWPConfiguration.Item(Me.MySessionID)
                hash.Item(Key) = _ClassNavegacio
                FWPConfiguration.Item(Me.MySessionID) = hash
            End If
        End If

    End Sub

    Public Enum OrigenSolicitud
        Normal = 0
        CabeceraDetalle = 1
        SysHelp = 2
    End Enum


    Protected ReadOnly Property Navegaciones() As Navegacion
        Get
            Return _ClassNavegacio
        End Get
    End Property


    Protected Property Hidden_ID() As System.Web.UI.HtmlControls.HtmlInputHidden
        Get
            If _Hidden_ID.Value = "0" Then
                _Hidden_ID.Value = ""
            End If
            Return _Hidden_ID
        End Get
        Set(ByVal Value As System.Web.UI.HtmlControls.HtmlInputHidden)
            _Hidden_ID = Value
        End Set
    End Property

    Public Property Mtn_TieneGuardarVolver(ByVal Mtn_grabarVolver As FwpServerControls.FwpButton) As Boolean
        Get
            Return _TieneGuargarVolver
        End Get
        Set(ByVal Value As Boolean)
            _TieneGuargarVolver = Value
            _Mtn_grabarVolver = Mtn_grabarVolver
        End Set
    End Property

    Protected Property Mtn_grabar(ByVal PermisoCrear As String) As FwpServerControls.FwpButton
        Get
            Return _Mtn_grabar
        End Get
        Set(ByVal Value As FwpServerControls.FwpButton)
            _Mtn_grabar = Value
            _PermisoCrear = PermisoCrear
            _Mtn_grabar.Enabled = False
            If Accion() = TipoAccion.Grabar Then
                If Me.Navegaciones.CabeceraDetalle.Formulario = Navegacion.DatosCabeceraDetalle.TipoFormulario.Cabecera Then
                    _Mtn_grabar.Text = Me.TextBtnGravarAgregarDetalle
                End If
                Try
                    If Me._TieneGuargarVolver Then
                        _Mtn_grabarVolver.Text = Me.TextBtnGravarVolver
                    End If
                Catch : End Try
                Try
                    If TienePermiso(_PermisoCrear) Then
                        _Mtn_grabar.Enabled = True
                    End If
                Catch : End Try
            End If
        End Set
    End Property

    Protected Property Mtn_modificar(ByVal PermisoModificar As String) As FwpServerControls.FwpButton
        Get
            Return _Mtn_grabar
        End Get
        Set(ByVal Value As FwpServerControls.FwpButton)
            _Mtn_grabar = Value
            _PermisoModificar = PermisoModificar
            '            _Mtn_grabarVolver.Text = ""
            If Accion() = TipoAccion.Modificar Then
                _Mtn_grabar.Text = Me.TextBtnModificar
                'If Me._TieneGuargarVolver Then
                '    _Mtn_grabarVolver.Text = "Modificar y volver" 'Me.TextBtnModificarVolver
                'End If
                If TienePermiso(_PermisoModificar) Then
                    _Mtn_grabar.Enabled = True
                Else
                    _Mtn_grabar.Enabled = False
                End If
            End If
        End Set
    End Property

    Protected Property Mtn_eliminar(ByVal PermisoEliminar As String) As FwpServerControls.FwpButton
        Get
            Return _Mtn_eliminar
        End Get
        Set(ByVal Value As FwpServerControls.FwpButton)
            _Mtn_eliminar = Value
            _Mtn_eliminar.Attributes.Add("onclick", "if (!confirm('¿Esta seguro de eliminar este registro?')) return false;")
            _PermisoEliminar = PermisoEliminar
            _Mtn_eliminar.Enabled = False
            _Mtn_eliminar.Text = Me.TextBtnEliminar
            If TienePermiso(_PermisoEliminar) Then
                _Mtn_eliminar.Enabled = True
            End If
            If _Hidden_ID.Value = "" Or _Hidden_ID.Value = "0" Then
                _Mtn_eliminar.Enabled = False
            End If
        End Set
    End Property

    Protected Property Mtn_volver(ByVal Retorno As String) As FwpServerControls.FwpButton
        Get
            Return _Mtn_volver
        End Get
        Set(ByVal Value As FwpServerControls.FwpButton)
            _Mtn_volver = Value
            _Retorno = Retorno
            If Not Retorno Is Nothing AndAlso Retorno <> "" Then
                _Mtn_volver.Text = Me.TextBtnVolver
            Else
                _Mtn_volver.Text = Me.TextBtnCerrar
            End If
        End Set
    End Property

    Protected Property TipoOrigen() As OrigenSolicitud
        Get
            Return _TipoOrigen
        End Get
        Set(ByVal Value As OrigenSolicitud)
            _TipoOrigen = Value
        End Set
    End Property

    Protected Sub ResuelveExcel(ByVal DataGrid As System.Web.UI.WebControls.DataGrid)
        FWPConfiguration.Excel(Session.SessionID) = DataGrid
        Dim url As String = FWPConfiguration.DirecBase & "/utilitarios/FwpDynamicExcel.aspx"
        Dim str As String = Js.AbreScript
        str &= "    var mt = (screen.height - 550) / 2;" & vbCrLf
        str &= "    var ml = (screen.width - 750) / 2;" & vbCrLf
        str &= "    window.open('" & url & "','WFExcel','menubar=yes,toolbar=yes,scrollbars=yes,resizable=yes,width=750,height=550,left='+ml+',top='+mt);" & vbCrLf
        str &= Js.CierraScript
        Page.RegisterClientScriptBlock("PasoaExcel", str)
    End Sub

    Private Function HomologaOrden(ByVal orden As String) As String
        Select Case orden
            Case "ASC"
                Return "ASC"
            Case "DESC"
                Return "DESC"
            Case "0"
                Return "ASC"
            Case "1"
                Return "DESC"
        End Select
    End Function

    Private Function HomologaOrdenExcel(ByVal orden As String) As String
        Select Case orden
            Case "ASC"
                Return "0"
            Case "DESC"
                Return "1"
            Case "0"
                Return "0"
            Case "1"
                Return "1"
        End Select
    End Function

    Protected Sub ResuelveExcel(ByVal DataGrid As FwpServerControls.FwpDataGridDataBound)

        Try
            If Not Session(DataGrid.NombreSesion & "Exc") Is Nothing Then
                'Dim fil As FwpServerControls.FwpDataGridDataBound.Navegacion = Session(DataGrid.NombreSesion)

                Dim xmlDoc As New Xml.XmlDocument
                xmlDoc.LoadXml(Session(DataGrid.NombreSesion & "Exc"))
                Dim exc As New Excel
                Dim fil As Xml.XmlNodeList = xmlDoc.FirstChild.FirstChild.ChildNodes
                'fil = Session(DataGrid.NombreSesion)

                exc.pagina = CInt(xmlDoc.FirstChild.ChildNodes(1).InnerText)
                exc.regpag = 65530
                exc.criterio = CInt(xmlDoc.FirstChild.ChildNodes(5).InnerText)
                'If InStr(xmlDoc.FirstChild.ChildNodes(4).InnerText.ToLower, "_new") = 0 Then
                '    exc.Sp = xmlDoc.FirstChild.ChildNodes(4).InnerText & "_" & xmlDoc.FirstChild.ChildNodes(9).InnerText & "_" & HomologaOrden(xmlDoc.FirstChild.ChildNodes(8).InnerText.ToString)
                'Else
                exc.Sp = xmlDoc.FirstChild.ChildNodes(4).InnerText
                'End If
                Dim filNav As FwpServerControls.Filtros
                Dim Coll As New FwpServerControls.TexBoxFilterCollection
                For i As Integer = 0 To fil.Count - 1
                    filNav = New FwpServerControls.Filtros
                    Select Case fil(i).Attributes(0).Value
                        Case "Date"
                            filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Date
                            filNav.DFecha = Split(fil(i).InnerText, "|")(0).ToString
                            filNav.HFecha = Split(fil(i).InnerText, "|")(1).ToString
                        Case "Logic"
                            filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Logic
                            filNav.TrueFalse = CByte(IIf(fil(i).InnerText = "", 2, fil(i).InnerText))
                        Case "Numeric"
                            filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Numeric
                            filNav.Value = CDec(IIf(fil(i).InnerText = "", 0, fil(i).InnerText))
                        Case "Autocompletar"
                            filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Autocompletar
                            filNav.IDValue = CInt(IIf(fil(i).InnerText = "", 0, fil(i).InnerText))
                            filNav.ProcesoAjax = fil(i).Attributes(1).Value
                        Case "Text"
                            filNav.TipoFiltro = FwpServerControls.Filtros.Tipo.Text
                            filNav.Text = fil(i).InnerText
                    End Select
                    filNav.ID = fil(i).Name
                    Coll.Add(filNav)
                Next
                exc.fil = Coll 'fil.Filtros
                exc.CriterioOrden = HomologaOrdenExcel(xmlDoc.FirstChild.ChildNodes(8).InnerText)
                exc.CriterioNombreColumna = xmlDoc.FirstChild.ChildNodes(9).InnerText
                Dim s As String = exc.GetData(DataGrid)

                Page.RegisterClientScriptBlock("vid", CargaDialog)
                RegisterClientScriptBlock("excelx", "<input type='hidden' id='hidden_xexcelx' name='hidden_xexcelx' value='" & s & "' />")
                RegisterStartupScript("excel_method", Js.script("javascript:bloqDiv('vid_excel','vid_fondo')"))
                'Dim gw As New System.Web.UI.WebControls.DataGrid
                'Dim dcs As System.Web.UI.WebControls.DataGridColumn
                'gw.AllowPaging = False                RegisterClientScriptBlock("excelx", "<input type='hidden' id='hidden_xexcelx' name='hidden_xexcelx' value='" & s & "' />")

                'gw.AllowSorting = False
                'gw.EnableViewState = False
                'gw.AutoGenerateColumns = False
                'For Each dcs In DataGrid.Columns
                '    If dcs.GetType.FullName = "System.Web.UI.WebControls.BoundColumn" Then
                '        If dcs.Visible Then
                '            gw.Columns.Add(dcs)
                '        End If
                '    End If
                'Next
                'gw.DataSource = dt
                'dt.Dispose()
                'gw.DataBind()

                'Dim s As New System.IO.StringWriter
                'Dim h As New System.Web.UI.HtmlTextWriter(s)
                'Dim frm As New System.Web.UI.HtmlControls.HtmlForm

                'Response.Clear()
                'Response.Buffer = True
                'Response.AddHeader("content-disposition", "attachment;filename=" & Replace(DataGrid.Titulo, " ", "") & ".xls")
                'Response.Charset = ""
                ''Para ver el archivo y no bajarlo descomentar la linea sgte!
                ''Response.Cache.SetCacheability(HttpCacheability.NoCache)
                'Response.ContentType = "application/vnd.xls"


                'Controls.Add(frm)
                'frm.Controls.Add(gw)
                'frm.RenderControl(h)
                'Response.ContentEncoding = System.Text.Encoding.UTF7
                'Response.Write(s.ToString())
                'Response.End()
                WriteLog("excel")
            End If
        Catch ex As Exception
            Response.Write(Js.alert(ex.Message))
        End Try
    End Sub

    Protected Sub ResuelveRedireccionar()
        'If Not Me.FwpMemento.CabeceraDetalle.Formulario.Detalle Then
        '    Dim hash As FWPSession = FWPConfiguration.Item(Me.MySessionID)
        '    Dim MemRel As Navegacion = hash.Item(_ClassNavegacio.KeyConfiguracion)
        '    For i As Integer = 0 To Me.FwpMemento.Relacionados.Count - 1
        '        hash.Remove(Me.FwpMemento.ItemRelacionados(i))
        '    Next
        '    hash.Remove(_ClassNavegacio.KeyConfiguracion)
        '    FWPConfiguration.Item(Me.MySessionID) = hash
        'End If
        Select Case Me.FwpMemento.OrigenSolicitud
            Case OrigenSolicitud.Normal
                Response.Redirect(FwpMemento.Retorno)
            Case OrigenSolicitud.CabeceraDetalle
                Response.Write(Js.OpenerRefresh)
            Case OrigenSolicitud.SysHelp
                Response.Write(Js.VentanaCerrar)
        End Select
    End Sub

    Protected Sub ResuelveRedireccionar(ByVal nombreVentana As String)
        Response.Write(Js.VentanaCerrar(nombreVentana))
        Response.End()
    End Sub

    Protected Property Dtg_Acceso(ByVal PermisoAcceso As String) As FwpServerControls.FwpDataGridDataBound
        Get
            Return _FwpDataGrid
        End Get
        Set(ByVal Value As FwpServerControls.FwpDataGridDataBound)
            Me._FwpDataGrid = Value
            _PermisoAcceso = PermisoAcceso
            If Not TienePermiso(_PermisoAcceso) Then
                MensajeSinPermiso()
            End If
        End Set
    End Property

    Protected Property Dtg_CraerNuevo() As String
        Get
            Return _PermisoCrear
        End Get
        Set(ByVal Value As String)
            _PermisoCrear = Value
            'verifica si tiene permiso para crear registro
            If Not TienePermiso(_PermisoCrear) Then
                Me._FwpDataGrid.VisibleNuevo = False
            End If
        End Set
    End Property

    Protected Property Dtg_Modificar(ByVal Columna As Integer) As String
        Get
            Return _PermisoModificar
        End Get
        Set(ByVal Value As String)
            _PermisoModificar = Value
            _Columna = Columna
            If Not TienePermiso(_PermisoModificar) Then
                Me._FwpDataGrid.Columns(_Columna).Visible = False
            End If
        End Set
    End Property

    Protected Property Dtg_Eliminar(ByVal Columna As Integer) As String
        Get
            Return _PermisoEliminar
        End Get
        Set(ByVal Value As String)
            _PermisoEliminar = Value
            _Columna = Columna
            If Not TienePermiso(_PermisoEliminar) Then
                Me._FwpDataGrid.Columns(_Columna).Visible = False
            End If
        End Set
    End Property

    Protected Property Dtg_Retorno() As String
        Get
            Return _Dtg_Retorno
        End Get
        Set(ByVal Value As String)
            _Dtg_Retorno = Value
            Me._FwpDataGrid.Retorno = Value
        End Set
    End Property


    Protected Sub Contador(ByVal id_contadorcabecera As Integer, ByVal id_original As Integer)
        'id_original = id del bien o propiedad
        'Dim cont As New Contador(Application.Contents)
        'cont.Nuevo(ConfigurationSettings.AppSettings("sistema"), Request.UserHostAddress, Session("cons_user"), Request.RawUrl, id_contadorcabecera, id_original, Session.SessionID)
    End Sub

    Protected Sub Contador(ByVal id_contadorcabecera As Integer, ByVal id_original As Integer, ByVal id_cliente As Integer)
        'id_original = id del bien o propiedad
        'id_cliente = id del mandante o dueño de la propiedad
        'Dim cont As New Contador(Application.Contents)
        'cont.Nuevo(ConfigurationSettings.AppSettings("sistema"), Request.UserHostAddress, Session("cons_user"), Request.RawUrl, id_contadorcabecera, id_original, id_cliente, Session.SessionID)
    End Sub

    Protected Sub Contador(ByVal id_contadorcabecera As Integer, ByVal id_original As Integer, ByVal id_cliente As Integer, ByVal id_agrupador As Integer)
        'id_original = id del bien o propiedad
        'id_cliente = id del mandante o dueño de la propiedad
        'id_agrupador = id_remate
        'Dim cont As New Contador(Application.Contents)
        'cont.Nuevo(ConfigurationSettings.AppSettings("sistema"), Request.UserHostAddress, Session("cons_user"), Request.RawUrl, id_contadorcabecera, id_original, id_cliente, id_agrupador, Session.SessionID)
    End Sub

    Protected Function SessionMantenedor() As Boolean
        'Verifica que la session (token) este activa 
        If Not TieneSesion() Then
            MensajeSesionExpirada()
        End If
    End Function

    Protected Function SessionNomina() As Boolean
        'Verifica que la session (token) este activa 
        If TieneSesion() Then
            'verifica si tiene permiso para acceder al formulario
            If Not TienePermiso(_PermisoAcceso) Then
                MensajeSinPermiso()
            Else
                ButtonsNomina()
            End If
        Else
            MensajeSesionExpirada()
        End If
    End Function

    Private Sub MensajeSinPermiso()
        Response.Redirect(ConfigurationManager.AppSettings("urlUtilitarios") & "wf_accessdenied.aspx")
        'Dim str As String
        'Response.Write(Js.alertClose("No esta autorizado para visualizar este formulario"))
    End Sub

    Private Sub MensajeSesionExpirada()
        Dim str As String
        Response.Write(Js.alertClose("Su sesión ha expirado vuelva a ingresar en el sistema"))
    End Sub

    Protected Sub ButtonsNomina()
        'verifica si tiene permiso para crear registro
        If Not TienePermiso(_PermisoCrear) Then
            Me._FwpDataGrid.VisibleNuevo = False
        End If
        'verifica si tiene permiso para modificar registro
        If Not TienePermiso(_PermisoModificar) Then
            Me._FwpDataGrid.Columns(_Columna).Visible = False
        End If
    End Sub

    Protected Sub ButtonsMantenedor()
        _Mtn_grabar.Text = Me.TextBtnGravar
        'If Me._TieneGuargarVolver Then
        '    _Mtn_grabarVolver.Text = Me.TextBtnGravarVolver
        'End If
        _Mtn_grabar.Enabled = False
        Try
            _Mtn_eliminar.Enabled = False
            _Mtn_eliminar.Attributes.Add("onclick", "if (!confirm('¿Esta seguro de eliminar este registro?')) return false;")
        Catch : End Try

        If _Retorno = "" Then
            _Mtn_volver.Text = Me.TextBtnCerrar
        End If
        If Accion() = TipoAccion.Grabar Then
            _Mtn_grabar.Text = Me.TextBtnGravar
            If Me._TieneGuargarVolver Then
                Try
                    _Mtn_grabarVolver.Text = Me.TextBtnGravarVolver
                Catch : End Try
            End If
            If TienePermiso(_PermisoCrear) Then
                _Mtn_grabar.Enabled = True
            End If
        Else
            _Mtn_grabar.Text = Me.TextBtnModificar
            'If Me._TieneGuargarVolver Then
            '    _Mtn_grabarVolver.Text = Me.TextBtnModificarVolver
            'End If
            If TienePermiso(_PermisoModificar) Then
                _Mtn_grabar.Enabled = True
            End If
        End If
        Try
            If TienePermiso(_PermisoEliminar) Then
                _Mtn_eliminar.Enabled = True
            End If
            If _Hidden_ID.Value = "" Or _Hidden_ID.Value = "0" Then
                _Mtn_eliminar.Enabled = False
            End If
        Catch : End Try

    End Sub

    Enum TipoAccion
        Grabar = 0
        Modificar = 1
    End Enum

    Public Function Accion() As TipoAccion
        Try
            If _Hidden_ID.Value = "" Or _Hidden_ID.Value = "0" Then
                _Mtn_eliminar.Enabled = False
                Return TipoAccion.Grabar
            Else
                _Mtn_eliminar.Enabled = True
                Return TipoAccion.Modificar
            End If
        Catch : End Try

    End Function

    Protected Function TieneSesion() As Boolean
        Return True
    End Function

    Protected Function TienePermiso(ByVal ConstanteOpcion As String) As Boolean
        Return FWPConfiguration.TienePermiso(ConstanteOpcion, Me._MySessionID)
    End Function

    Protected Function TieneAccesos() As Boolean
        Return True 'FWPConfiguration.TienePermiso(ConstanteOpcion)
    End Function

    Protected Sub LimpiaFormulario(ByVal msg As String)
        LimpiaFormulario()
        Response.Write(Js.alert(msg))
    End Sub

    Protected Sub LimpiaFormulario()
        Dim objFormControls As Object = Me.FindControl("Form1").Controls
        For Each obj As Object In objFormControls
            Try
                If Not obj Is Nothing AndAlso Not obj.id Is Nothing AndAlso Left(obj.id, 2) <> "__" Then   'Para no tocar los viewstate 
                    If Left(obj.id, 4) = "txt_" Then
                        If obj.GetType.FullName = "FwpServerControls.MantSyshelp" Then
                            obj.value = 0
                        End If
                        obj.Text = ""
                    ElseIf Left(obj.id, 7) = "hidden_" Then
                        obj.value = ""
                    ElseIf Left(obj.id, 4) = "chk_" Then
                        obj.Checked = False
                    End If
                End If

            Catch ex As Exception
                'Throw New Exception(ex.Message)
            End Try
        Next
        ''Response.Write(Js.alert("Operación realizada con éxito"))
        ButtonsMantenedor()
    End Sub

    'Funcion que permite pasar los campos desde un registro a los controls de un formulario
    Protected Function datarowToControls(ByVal drow As DataRow, ByVal cols As DataColumnCollection)
        Dim objFormControls As Object = Me.FindControl("Form1").Controls
        For Each dc As DataColumn In cols ' ds.Tables(0).Columns
            ' verifico si es id
            For Each obj As Object In objFormControls
                If LCase(obj.id) = "txt_" & LCase(dc.ColumnName) Then
                    If Left(dc.ColumnName, 3) = "id_" Then
                        obj.value = IIf(drow(dc.ColumnName) Is DBNull.Value, 0, drow(dc.ColumnName))
                        Exit For
                    Else
                        obj.Text = IIf(drow(dc.ColumnName) Is DBNull.Value, "", drow(dc.ColumnName))
                        Exit For
                    End If
                End If
                If LCase(obj.id) = "chk_" & LCase(dc.ColumnName) Then
                    obj.checked = IIf(drow(dc.ColumnName) Is DBNull.Value, False, drow(dc.ColumnName))
                End If
            Next
        Next
    End Function

    'Funcion que permite pasar los campos desde los controls de un formulario a un Registro
    Protected Function ControlsToDatarow(ByVal drow As DataRow, ByVal cols As DataColumnCollection)
        Dim objFormControls As Object = Me.FindControl("Form1").Controls
        For Each dc As DataColumn In cols ' ds.Tables(0).Columns
            ' verifico si es id
            For Each obj As Object In objFormControls
                If LCase(obj.id) = "txt_" & LCase(dc.ColumnName) Then
                    If Left(dc.ColumnName, 3) = "id_" Then
                        If obj.value Is Nothing Then
                            drow(dc.ColumnName) = DBNull.Value
                        Else
                            If IsNumeric(obj.value) AndAlso CInt(obj.value = 0) Then
                                drow(dc.ColumnName) = DBNull.Value
                            Else
                                drow(dc.ColumnName) = obj.value
                            End If

                        End If
                    Else
                        If obj.text <> "" Then
                            drow(dc.ColumnName) = obj.Text
                        Else
                            Select Case LCase(dc.DataType.FullName)
                                Case LCase("system.DateTime")
                                    drow(dc.ColumnName) = DBNull.Value
                                Case Else
                                    drow(dc.ColumnName) = DBNull.Value
                            End Select
                        End If
                    End If
                    Exit For
                End If
                If LCase(obj.id) = "chk_" & LCase(dc.ColumnName) Then
                    drow(dc.ColumnName) = obj.checked.ToString
                    Exit For
                ElseIf InStr(LCase(dc.ColumnName), "cons_user") > 0 Or InStr(LCase(dc.ColumnName), "consuser") Then
                    drow(dc.ColumnName) = FWPConfiguration.Cons_User(Session.SessionID)
                    Exit For
                End If
            Next
        Next
    End Function


End Class


Public Class Compresion

    Shared Function Compress(ByVal bytes() As Byte) As Byte()
        'Dim memory As New MemoryStream
        'Dim stream = New Zip.Streams.DeflaterOutputStream(memory, New Zip.Deflater(Zip.Deflater.BEST_COMPRESSION), 131072)
        'stream.Write(bytes, 0, bytes.Length)
        'stream.Close()
        'Return memory.ToArray()
    End Function
    Shared Function Decompress(ByVal bytes() As Byte) As Byte()
        'Dim stream = New Zip.Streams.InflaterInputStream(New MemoryStream(bytes))
        'Dim memory As New MemoryStream
        'Dim writeData(4096) As Byte
        'Dim size As Integer
        'While True
        '    size = stream.Read(writeData, 0, writeData.Length)
        '    If size > 0 Then memory.Write(writeData, 0, size) Else Exit While
        'End While
        'stream.Close()
        'Return memory.ToArray()
    End Function
End Class
