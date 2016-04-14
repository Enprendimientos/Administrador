

Namespace Fwp.SystemFramework
    Public Interface IParametrosNomina
        Sub GetDataNomina(ByVal Param As ParametrosNomina)
    End Interface

    <System.ComponentModel.DesignerCategory("Code"), SerializableAttribute()> _
    Public Class ParametrosNomina
        Public Filtros As New Hashtable
        Public Pagina As Integer
        Public RegistrosPorPaginas As Integer
        Public ColumnaOrden As String
        Public Orden As Sort

        Public Enum Sort
            ASC
            DESC
        End Enum
    End Class

End Namespace

