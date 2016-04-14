<System.ComponentModel.DesignerCategory("Code"), SerializableAttribute()> _
Public Class SCDatos
    Inherits DataSet

    'Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
    '    MyBase.New(info, context)
    'End Sub

    Private _rawUrl As String
    Public Property rawUrl() As String
        Get
            Return _rawUrl
        End Get
        Set(ByVal Value As String)
            _rawUrl = Value
        End Set
    End Property

    ' crea un fila con la estructura para llamar al procedimiento almacenado
    Public Function CreaFilaEstructura(ByVal dt As DataTable, ByVal nc As String, ByVal tipo As SqlDbType, ByVal largo As Integer) As DataRow
        Return CreaFilaEstructura(dt, nc, tipo, largo, nc)
    End Function

    Public Function CreaFilaEstructura(ByVal dt As DataTable, ByVal nc As String, ByVal tipo As SqlDbType, ByVal largo As Integer, ByVal descripcion As String) As DataRow
        Return CreaFilaEstructura(dt, nc, tipo, largo, descripcion, True)
    End Function

    Public Function CreaFilaEstructura(ByVal dt As DataTable, ByVal nc As String, ByVal tipo As SqlDbType, ByVal largo As Integer, ByVal descripcion As String, ByVal SoportaNulos As Boolean) As DataRow
        Dim drow As DataRow
        drow = dt.NewRow()
        drow(cm_estructuraSQL.NOMBRE_COLUMNA) = nc
        drow(cm_estructuraSQL.TIPO_COLUMNA) = tipo
        drow(cm_estructuraSQL.LARGO_COLUMNA) = largo
        drow(cm_estructuraSQL.DESCRIPCION_COLUMNA) = descripcion
        drow(cm_estructuraSQL.SOPORTANULL_COLUMNA) = SoportaNulos
        Return drow
    End Function


    ' Crea estructura a partir de la estructura SQL
    Public Function CreaEstructuraRegistros(ByVal tabla As String, ByVal dt As cm_estructuraSQL) As DataTable
        Dim dtnew As New DataTable(tabla)
        Dim tipo As Type
        Dim dr As DataRow
        Try
            For Each dr In dt.Rows
                Select Case dr(cm_estructuraSQL.TIPO_COLUMNA)
                    Case SqlDbType.Int
                        tipo = GetType(System.Int32)
                    Case SqlDbType.VarChar
                        tipo = GetType(System.String)
                    Case SqlDbType.SmallDateTime
                        tipo = GetType(System.DateTime)
                    Case SqlDbType.Money
                        tipo = GetType(System.Decimal)
                    Case SqlDbType.Decimal
                        tipo = GetType(System.Decimal)
                    Case SqlDbType.DateTime
                        tipo = GetType(System.DateTime)
                    Case SqlDbType.Bit
                        tipo = GetType(System.Boolean)
                End Select
                dtnew.Columns.Add(CStr(dr(cm_estructuraSQL.NOMBRE_COLUMNA)), tipo)
            Next
        Catch ex As Exception
            Throw New Exception("Error al crear la estructura: " + ex.Message + " " + ex.Source + " " + ex.StackTrace)
        End Try
        Return dtnew
    End Function
End Class


Public Class TransportaDatos
    Public Dataset As DataSet
    Public Reader As System.Data.SqlClient.SqlDataReader
    Public Realizado As Boolean
    Public Mensaje As String
    Public Existe As Boolean
    Public identity As Integer
    Public TD_Dato1 As String
    Public TD_Dato2 As String
    Public TD_Dato3 As String
    Public Objeto As Object
End Class
