Imports System.ComponentModel

<Serializable()> _
Public Class SCNomina
    Inherits Fwp.common.TiposBases
    Private _Pagina As Integer
    Private _RegxPag As Integer
    Private _OrdenarPor As String
    Private _Ordenar As FwpServerControls.FwpDataGridDataBound.Orden

    'Enum Orden
    '    ASC = 0
    '    DESC = 1
    'End Enum

    <Category("DataColumn"), Description("SqlDbType=SqlDbType.Int, Size=0, Null=False")> _
    Public Property Pagina() As Integer
        Get
            Return _Pagina
        End Get
        Set(ByVal value As Integer)
            _Pagina = value
        End Set
    End Property

    <Category("DataColumn"), Description("SqlDbType=SqlDbType.Int, Size=0, Null=False")> _
    Public Property RegistrosPorPaginas() As Integer
        Get
            Return _RegxPag
        End Get
        Set(ByVal value As Integer)
            _RegxPag = value
        End Set
    End Property

    <Category("DataColumn"), Description("SqlDbType=SqlDbType.VarChar, Size=50, Null=True")> _
    Public Property ColumnaOrden() As String
        Get
            Return _OrdenarPor
        End Get
        Set(ByVal value As String)
            _OrdenarPor = value
        End Set
    End Property

    <Category("DataColumn"), Description("SqlDbType=SqlDbType.Int, Size=0, Null=False")> _
    Public Property OrdenColumna() As FwpServerControls.FwpDataGridDataBound.Orden
        Get
            Return _Ordenar
        End Get
        Set(ByVal value As FwpServerControls.FwpDataGridDataBound.Orden)
            _Ordenar = value
        End Set
    End Property
End Class
