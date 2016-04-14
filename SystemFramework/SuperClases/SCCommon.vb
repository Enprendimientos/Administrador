'CLase Base desde donde heredan todos las clases basicas 
' que representan tablas en la base de datos
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace Fwp.common
    <Serializable()> _
    Public Class SCCommon
        Inherits TiposBases
        Private _id As String
        Private _descripcion As String
        Private _activo As EstadoRegistro = EstadoRegistro.TODOS
        Private _binaryChecksum As String
        Private _ForceUpdate As ForceUpdateSP = ForceUpdateSP.Y
        Private _RawUrl As String

        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property

        Public Property activo() As EstadoRegistro
            Get
                Return _activo
            End Get
            Set(ByVal value As EstadoRegistro)
                _activo = value
            End Set
        End Property


        <Category("DataColumn"), Description("SqlDbType=SqlDbType.NVarChar, Size=4000, Null=True")> _
        Public Property BinaryChecksum() As String
            Get
                Return _binaryChecksum
            End Get
            Set(ByVal value As String)
                _binaryChecksum = value
            End Set
        End Property

        <Category("DataColumn"), Description("SqlDbType=SqlDbType.Char, Size=1, Null=True")> _
        Public Property ForceUpdate() As ForceUpdateSP
            Get
                Return _ForceUpdate
            End Get
            Set(ByVal value As ForceUpdateSP)
                _ForceUpdate = value
            End Set
        End Property

        Public Property RawUrl() As String
            Get
                Return _RawUrl
            End Get
            Set(ByVal value As String)
                _RawUrl = value
            End Set
        End Property

    End Class
End Namespace



