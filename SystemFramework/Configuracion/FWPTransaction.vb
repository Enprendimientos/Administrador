Imports System.ComponentModel
Imports System.Configuration


Namespace Fwp.common
    Public Class FWPTransaction
        Inherits System.Web.UI.Page

        Private _MyStates As States = States.Liberate
        Private _myTrans As SqlClient.SqlTransaction
        Private _myConn As SqlClient.SqlConnection

        Enum States
            Taken = 0
            Liberate = 1
        End Enum
        Public Sub New()

        End Sub

        Public Sub New(ByVal Conn As SqlClient.SqlConnection)
            _myConn = Conn
        End Sub

        ''' <summary>
        ''' Indica si la coneccion es parte de una trasaccion para que
        ''' no se cierre automaticamente en el getdata generico
        ''' </summary>
        Public Property MyStates() As States
            Get
                Return _MyStates
            End Get
            Set(ByVal value As States)
                _MyStates = value
            End Set
        End Property

        Public Property MyConnection() As SqlClient.SqlConnection
            Get
                Try

                    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("BD_DEFAULT").ToString ' "user id=scanales;data source=192.0.0.44\SQL2005;persist security info=false;initial catalog=PJBCI_ASIS;password=scan$7058;"
                    'Dim ConnectionString As String = "" 'ConfigurationManager.ConnectionStrings("BD_DEFAULT").ToString ' "user id=scanales;data source=192.0.0.44\SQL2005;persist security info=false;initial catalog=PJBCI_ASIS;password=scan$7058;"
                    'Try
                    '    ConnectionString = FWPConfiguration.ConnectionString(Session.SessionID)
                    'Catch eh As System.Web.HttpException
                    '    ConnectionString = FWPConfiguration.ConnectionString(FWPConfiguration.SessionIDTemporal)
                    'End Try
                    If _myConn Is Nothing Then
                        _myConn = New SqlClient.SqlConnection(ConnectionString)
                    Else
                        If _myConn.ConnectionString = "" Then
                            _myConn = New SqlClient.SqlConnection(ConnectionString)
                        End If
                    End If
                    If _myConn.State <> ConnectionState.Open Then
                        _myConn.Open()
                    End If
                    Return _myConn
                Catch ex As Exception
                    Dim err As String = ex.Message
                End Try
            End Get
            Set(ByVal Value As SqlClient.SqlConnection)
                _myConn = Value
            End Set
        End Property

        ''' <summary>
        ''' Cierra una conexion
        ''' </summary>
        Public Sub CloseConnection()
            If Not _myConn Is Nothing Then
                If _myConn.State = ConnectionState.Open Then
                    _myConn.Close()
                End If
            End If
        End Sub


        Public Property myTransaction() As SqlClient.SqlTransaction
            Get
                Return _myTrans
            End Get
            Set(ByVal Value As SqlClient.SqlTransaction)
                _myTrans = Value
            End Set
        End Property

        Public Sub BeginTransaction(ByVal Comiting As Boolean)
            If Comiting Then
                myTransaction = MyConnection.BeginTransaction
            End If
        End Sub

        Public Sub BeginTransaction()
            If MyStates = States.Liberate Then
                myTransaction = MyConnection.BeginTransaction
            End If
        End Sub

        Public Sub Commit(ByVal Comiting As Boolean)
            If Not _myTrans Is Nothing And Comiting Then
                _myTrans.Commit()
            End If
        End Sub

        Public Sub Commit()
            If Not _myTrans Is Nothing Then
                If MyStates = States.Liberate Then
                    _myTrans.Commit()
                End If
            End If
        End Sub

        Public Sub BeginTransaction(ByVal Estado As States)
            If myTransaction Is Nothing And Estado = States.Liberate Then
                myTransaction = MyConnection.BeginTransaction
            End If
        End Sub

        Public Sub Commit(ByVal Estado As States)
            If Not _myTrans Is Nothing And Estado = States.Liberate Then
                _myTrans.Commit()
            End If
        End Sub
        Public Sub Rollback()
            If Not _myTrans Is Nothing Then
                If MyStates = States.Liberate Then
                    _myTrans.Rollback()
                End If
            End If
        End Sub

        Public Sub Rollback(ByVal Estado As States)
            If Not _myTrans Is Nothing And Estado = States.Liberate Then
                _myTrans.Rollback()
            End If
        End Sub

        Protected Overrides Sub Finalize()
            If Not MyConnection Is Nothing Then
                If _myConn.State <> ConnectionState.Closed Then
                    Try
                        MyConnection.Close()
                    Catch ex As Exception

                    End Try
                End If
            End If
            MyBase.Finalize()
        End Sub
    End Class
End Namespace

