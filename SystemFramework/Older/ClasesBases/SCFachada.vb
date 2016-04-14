Public Class SCFachadaOLD
    Inherits DataSet
    ' corresponde al string con el nombre del cliente, 
    ' se usa para implementar multiples bases de datos con cada una asociada a un cliente
    ' el string de conexion del cliente esta en archivo XML (configuracion.config) 
    ' y usa este nombre para recuperarlo
    Protected _Cliente As String
    Protected _Cons_User As String
    Protected _TotalRegistros As Integer
    Protected _TotalPaginas As Integer

    ' atributo privado para manejar el ID del registro
    Protected _identity As Integer

    ' Propiedad para recuperar que publica el ID del registro para los metodos que usan este objeto
    Public ReadOnly Property Identity() As Integer
        Get
            Return _identity
        End Get
    End Property
    Public ReadOnly Property TotalRegistros() As Integer
        Get
            Return _TotalRegistros
        End Get
    End Property
    Public ReadOnly Property TotalPaginas() As Integer
        Get
            Return _TotalPaginas
        End Get
    End Property

End Class
