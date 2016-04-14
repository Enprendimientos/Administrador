Imports System.ComponentModel
Namespace Fwp.common
    <Serializable()> _
    Public Class SCCommonFecha
        Private _Fecha As Date
        Private _FechaDesde As Date
        Private _FechaHasta As Date

        Public Property Fecha() As Date
            Get
                Return _Fecha
            End Get
            Set(ByVal value As Date)
                _Fecha = value
                _FechaDesde = value
            End Set
        End Property

        Public Property FechaDesde() As Date
            Get
                Return _Fecha
            End Get
            Set(ByVal value As Date)
                _Fecha = value
            End Set
        End Property

        Public Property FechaHasta() As Date
            Get
                Return _FechaHasta
            End Get
            Set(ByVal value As Date)
                _FechaHasta = value
            End Set
        End Property
    End Class
End Namespace

