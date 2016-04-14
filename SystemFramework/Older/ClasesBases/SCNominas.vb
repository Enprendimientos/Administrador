Imports Fwp.SystemFramework

Public Class SCNominas
    Inherits DataSet

    Protected _pagina As Integer
    Protected _RegistrosPorPaginas As Integer
    Protected _ColumnaOrden As String
    Protected _Orden As ParametrosNomina.Sort
    Protected _TotalPaginas As Integer
    Protected _TotalRegistros As Integer
    Public Filtros As New Hashtable
    Public ESTRUCTURA As String

    Public ReadOnly Property TotalPaginas() As Integer
        Get
            Return _TotalPaginas
        End Get
    End Property

    Public ReadOnly Property TotalRegistros() As Integer
        Get
            Return _TotalRegistros
        End Get
    End Property

    Public Property Pagina() As Integer
        Set(ByVal Value As Integer)
            _pagina = Value
        End Set
        Get
            Return _pagina
        End Get
    End Property

    Public Property RegistrosPorPaginas() As Integer
        Set(ByVal Value As Integer)
            _RegistrosPorPaginas = Value
        End Set
        Get
            Return _RegistrosPorPaginas
        End Get
    End Property

    Public Property ColumnaOrden() As String
        Set(ByVal Value As String)
            _ColumnaOrden = Value
        End Set
        Get
            Return _ColumnaOrden
        End Get
    End Property

    Public Property Orden() As ParametrosNomina.Sort
        Set(ByVal Value As ParametrosNomina.Sort)
            _Orden = Value
        End Set
        Get
            Return _Orden
        End Get
    End Property

    Public Function CreaFilaEstructura(ByVal dt As DataTable, ByVal nc As String, ByVal tipo As SqlDbType, ByVal largo As Integer) As DataRow
        Dim drow As DataRow
        drow = dt.NewRow()
        drow(cm_estructuraSQL.NOMBRE_COLUMNA) = nc
        drow(cm_estructuraSQL.TIPO_COLUMNA) = tipo
        drow(cm_estructuraSQL.LARGO_COLUMNA) = largo
        Return drow
    End Function

End Class
