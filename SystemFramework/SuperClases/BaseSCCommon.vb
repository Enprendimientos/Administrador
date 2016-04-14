Imports System.ComponentModel


Namespace Fwp.common
    <Serializable()> _
    Public Class TiposBases

        Public Enum ForceUpdateSP
            Y
            N
        End Enum

        Public Enum EstadoRegistro
            DES = 0
            ACT = 1
            TODOS = 2
        End Enum

        Public Enum TipoDescripcion
            SqlDbType = 0
            Size = 1
            Null = 2
        End Enum

        Public Enum TipoDescripcionCompuesto
            NombreId = 0
            SqlDbType = 1
            Size = 2
            Null = 3
            NombreDescripcion = 4
            NDSqlDbType = 5
            NDSize = 6
            NDNull = 7
            NDDesnormalizado = 8
        End Enum
    End Class
End Namespace

