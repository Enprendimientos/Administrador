Option Strict Off
Imports Fwp.Common

Public Class SCBusinessRules(Of T)
    Inherits BaseSearch(Of T)
    Private _myTrans As FWPTransaction

    Protected Property myTrans() As FWPTransaction
        Get
            Return _myTrans
        End Get
        Set(ByVal value As FWPTransaction)
            _myTrans = value
        End Set
    End Property


End Class
