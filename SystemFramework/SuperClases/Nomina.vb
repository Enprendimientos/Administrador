Imports System.Collections.Generic
Imports System.ComponentModel
Imports Fwp.common

Namespace Fwp.common

    Public Class Nomina(Of T)
        Private _Nomina As IList(Of T)
        Private _Registros As Integer
        Private _Paginas As Integer

        Sub New()
            _Nomina = New List(Of T)
        End Sub

        Public Property Registros() As Integer
            Get
                Return _Registros
            End Get
            Set(ByVal value As Integer)
                _Registros = value
            End Set
        End Property

        Public Property Paginas() As Integer
            Get
                Return _Paginas
            End Get
            Set(ByVal value As Integer)
                _Paginas = value
            End Set
        End Property

        Public Property DataSource() As IList(Of T)
            Get
                Return _Nomina
            End Get
            Set(ByVal value As IList(Of T))
                _Nomina = value
            End Set
        End Property

    End Class
End Namespace

Namespace Fwp.common
    Public Class Informes(Of T)
        Private _Informe As IList(Of T)
        Public Property DataSource() As IList(Of T)
            Get
                Return _Informe
            End Get
            Set(ByVal value As IList(Of T))
                _Informe = value
            End Set
        End Property
    End Class
End Namespace

