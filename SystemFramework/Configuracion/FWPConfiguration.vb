Option Strict On
Option Explicit On 

Imports System
Imports System.Collections
Imports System.Configuration

Imports Fwp.SystemFramework
Imports System.Collections.Specialized

Namespace Fwp.common
    Public Class FWPConfiguration
        Inherits System.Web.UI.Page
        Implements IConfigurationSectionHandler

        Private Shared _FijaPermisos As String
        Private Shared _DirecBase As String
        Private Shared _PasoSessionID As String

        Private Const RUTACONFIG_CONSTANTES As String = "Fwp.RutaConfig.Constantes"
        'Private Const RUTACONFIG_CONSTANTES_DEFAULT As String = "C:\Inetpub\wwwroot\bitacorasWeb\Config\configuracion.config"
        Private Const DATAACCESS_CONNECTIONSTRING As String = "Fwp.DataAccess.ConnectionString"
        'Private Const DATAACCESS_CONNECTIONSTRING_DEFAULT As String = "server=localhost; User ID=sa;database=bitacora"
        Private Const SECTIONCLIENTES_CONSTANTES As String = "clientes"

        Public Shared rutaArchivoConfiguracion As String
        Private Shared fieldConnectionString As String

        Public Shared Constantes As Hashtable
        Private Shared Sesion As FWPSession

        Public Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal section As System.Xml.XmlNode) As Object Implements System.Configuration.IConfigurationSectionHandler.Create
            Dim settings As NameValueCollection
            Try
                Dim baseHandler As NameValueSectionHandler
                baseHandler = New NameValueSectionHandler
                settings = CType(baseHandler.Create(parent, configContext, section), NameValueCollection)

            Catch

            End Try

            'If settings Is Nothing Then
            'rutaArchivoConfiguracion = RUTACONFIG_CONSTANTES_DEFAULT
            'Else
            rutaArchivoConfiguracion = ApplicationConfiguration.RutaArchivoConfiguracion
            'End If
        End Function

        Public Shared Sub OnSessionStart(ByVal SessionID As String)
            LoadContantes()
            Dim Sesion As New FWPSession
            If Not Constantes.Contains(SessionID) Then
                Constantes.Add(SessionID, Sesion)
            Else
                Constantes.Item(SessionID) = Sesion
            End If
        End Sub

        Public Shared Sub OnSessionEnd(ByVal SessionID As String)
            If Constantes.Contains(SessionID) Then
                Constantes.Remove(SessionID)
            End If
        End Sub

        Public Shared ReadOnly Property Count() As Integer
            Get
                Return Constantes.Count
            End Get
        End Property

        Public Shared Property Item(ByVal Constante As String) As Object
            Get
                Return Constantes(Constante)
            End Get
            Set(ByVal Value As Object)
                Add(Constante, Value)
            End Set
        End Property

        Public Shared Property Item(ByVal Constante As String, ByVal SessionID As String) As Object
            Get
                Dim ses As FWPSession = CType(Constantes(SessionID), FWPSession)
                Dim nav As Object = ses.Item(Constante)
                Return nav
            End Get
            Set(ByVal Value As Object)
                Add(Constante, Value)
            End Set
        End Property


        Public Shared Sub Add(ByVal Constante As String, ByVal Valor As Object)
            If Constantes.Contains(CStr(Constante)) Then
                Constantes.Remove(CStr(Constante))
            End If
            Constantes.Add(CStr(Constante), Valor)
        End Sub

        Public Shared Sub Remove(ByVal Constante As String)
            If Constantes.Contains(CStr(Constante)) Then
                Constantes.Remove(CStr(Constante))
            End If
        End Sub


        Public Shared ReadOnly Property Contains(ByVal Constante As String) As Boolean
            Get
                Return Constantes.Contains(CStr(Constante))
            End Get
        End Property


        'Public Shared ReadOnly Property AppSettingsText(ByVal Constante As String) As String
        '    Get
        '        Return CType(GetText(Constante), String)
        '    End Get
        'End Property

        'Private Shared Function GetText(ByVal Constante As String) As String
        '    Dim hash As Hashtable = CType(Constantes(Constante.ToLower), Hashtable)
        '    Dim de As DictionaryEntry
        '    For Each de In hash
        '        Return CStr(de.Value)
        '    Next
        'End Function

        Public Shared ReadOnly Property AppSettingsText(ByVal Constante As String) As String
            Get
                Return CType(GetText(Constante), String)
            End Get
        End Property

        Private Shared Function GetText(ByVal Constante As String) As String
            Dim hash As Hashtable = CType(Constantes(Constante.ToLower), Hashtable)
            Dim de As DictionaryEntry
            For Each de In hash
                Return CStr(de.Value)
            Next
            Return ""
        End Function

        Public Shared Function GetValue(ByVal Constante As String) As String
            Try
                Dim hash As Hashtable = CType(Constantes(Constante.ToLower), Hashtable)
                If Not hash Is Nothing Then
                    Dim de As DictionaryEntry
                    For Each de In hash
                        Return CStr(de.Key)
                    Next
                Else
                    Throw New Exception("No existe la constante """ & Constante & """ en el origen de configuración")
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared ReadOnly Property AppSettings(ByVal Constante As String) As String
            Get
                Return CType(GetValue(Constante.ToLower), String)
            End Get
        End Property

        Public Shared Property SessionIDTemporal() As String
            Get
                Return _PasoSessionID
            End Get
            Set(ByVal Value As String)
                _PasoSessionID = Value
            End Set
        End Property


        Public Shared WriteOnly Property FijarPermisos(ByVal SessionID As String) As String
            Set(ByVal Value As String)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.Accesos = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Function TienePermiso(ByVal Constante As String, ByVal SessionID As String) As Boolean
            Try
                If Constante = "" Then Return True : Exit Function
                Dim session As FWPSession = CType(Constantes(CStr(SessionID)), FWPSession)
                Dim AAccesos() As String
                AAccesos = Split(session.Accesos, ",")
                If CInt(GetValue(Constante.ToLower)) <= AAccesos.Length Then
                    If GetValue(Constante.ToLower) Is Nothing Then
                        Return False
                        Exit Function
                    End If
                    If CInt(AAccesos(CInt(GetValue(Constante.ToLower)))) = 1 Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    'Return False
                    Return True
                End If
            Catch
                'Return False
                Return True
            End Try
        End Function

        Public Shared ReadOnly Property DirecBase() As String
            Get
                Dim db As String = CType(GetValue(LCase("DirecBase")), String)
                Return CStr(IIf(Right(db, 1) = "/", Left(db, Len(db) - 1), db))
            End Get
        End Property


        Private Shared Sub LoadContantes()
            Try
                If Constantes Is Nothing Then
                    Constantes = New Hashtable
                End If
                Dim ds As DataSet = CargaConstantes()
                For Each dr As DataRow In ds.Tables(0).Rows
                    Dim hash1 As Hashtable
                    Dim hash2 As Hashtable
                    hash1 = New Hashtable
                    hash1.Add(dr("ct_constanteValor").ToString.ToLower, dr("ct_constanteDescripcion"))
                    hash2 = New Hashtable
                    hash2.Add(dr("ct_constante").ToString.ToLower, hash1)
                    If Constantes.Contains(CStr(dr("ct_constante").ToString.ToLower)) Then
                        Constantes.Remove(CStr(dr("ct_constante").ToString.ToLower))
                    End If
                    Constantes.Add(CStr(CStr(dr("ct_constante").ToString.ToLower)), hash1)
                Next
                Dim clientes As System.Configuration.ConnectionStringSettingsCollection = System.Configuration.ConfigurationManager.ConnectionStrings
                For i As Integer = 0 To clientes.Count - 1
                    Dim hash1 As Hashtable
                    Dim hash2 As Hashtable
                    hash1 = New Hashtable
                    hash1.Add(clientes.Item(i).ConnectionString.ToLower, "")
                    hash2 = New Hashtable
                    hash2.Add(clientes.Item(i).Name.ToLower, hash1)
                    If Constantes.Contains(CStr(clientes.Item(i).Name.ToLower)) Then
                        Constantes.Remove(CStr(clientes.Item(i).Name.ToLower))
                    End If
                    Constantes.Add(CStr(CStr(clientes.Item(i).Name.ToLower)), hash1)
                Next
            Catch ex As Exception
        Throw New ApplicationException(ex.Message)
            End Try
        End Sub


        Private Shared Function CargaConstantes() As DataSet
            Dim conn As SqlClient.SqlConnection = Nothing
            Dim ds As New DataSet
            Dim ad As SqlClient.SqlDataAdapter = Nothing
            Try
                conn = New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("BD_DEFAULT").ConnectionString)
        Dim comm As New SqlClient.SqlCommand("pa08_tg_constantes_selList", conn)
                comm.CommandType = CommandType.StoredProcedure
                ad = New SqlClient.SqlDataAdapter(comm)
                ad.Fill(ds)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                If Not conn Is Nothing Then
                    conn.Close()
                    conn.Dispose()
                End If
                ' libera los recursos
                If Not ad.SelectCommand Is Nothing Then
                    If Not ad.SelectCommand.Connection Is Nothing Then
                        ad.SelectCommand.Connection.Close()
                        ad.SelectCommand.Connection.Dispose()
                    End If
                    ad.SelectCommand.Dispose()
                End If
                ad.Dispose()
            End Try
            Return ds
        End Function

        Public Shared ReadOnly Property ConnectionString(ByVal SessionID As String) As String
            Get
                If Not Constantes.Contains(CStr(SessionID)) Then
                    Return ""
                Else
                    Dim session As FWPSession = CType(Constantes(CStr(SessionID)), FWPSession)
                    Return session.ConnectionString
                End If
            End Get
        End Property

        Public Shared Property ID_User(ByVal SessionID As String) As Integer
            Get
                If Not Constantes.Contains(CStr(SessionID)) Then
                    Return 0
                Else
                    Dim session As FWPSession = CType(Constantes(CStr(SessionID)), FWPSession)
                    Return session.ID_User
                End If
            End Get
            Set(ByVal Value As Integer)
                Dim session As FWPSession
                If Constantes.Contains(CStr(SessionID)) Then
                    session = CType(Constantes(CStr(SessionID)), FWPSession)
                    session.ID_User = Value
                    Constantes(CStr(SessionID)) = session
                Else
                    session = New FWPSession
                    session.ID_User = Value
                    Constantes.Add(CStr(SessionID), session)
                End If
            End Set
        End Property

        Public Shared Property Cons_User(ByVal SessionID As String) As String
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.Cons_User
            End Get
            Set(ByVal Value As String)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.Cons_User = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property ID_Person(ByVal SessionID As String) As Integer
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.ID_Person
            End Get
            Set(ByVal Value As Integer)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.ID_Person = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property ID_Oficina(ByVal SessionID As String) As Integer
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.ID_Oficina
            End Get
            Set(ByVal Value As Integer)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.ID_Oficina = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property ID_Organizacion(ByVal SessionID As String) As Integer
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.ID_Organizacion
            End Get
            Set(ByVal Value As Integer)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.ID_Organizacion = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property CambioPassword(ByVal SessionID As String) As Boolean
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.CambioPassword
            End Get
            Set(ByVal Value As Boolean)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.CambioPassword = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property Name_Person(ByVal SessionID As String) As String
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.Name_Person
            End Get
            Set(ByVal Value As String)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.Name_Person = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property Garantia_Persona(ByVal SessionID As String) As Decimal
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.MontoGarantia
            End Get
            Set(ByVal Value As Decimal)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.MontoGarantia = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property queryvars(ByVal SessionID As String) As String
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.queryvars
            End Get
            Set(ByVal Value As String)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.queryvars = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property Perfil(ByVal SessionID As String) As Integer
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.Perfil
            End Get
            Set(ByVal Value As Integer)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.Perfil = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared WriteOnly Property FijarCliente(ByVal SessionID As String) As String
            Set(ByVal Value As String)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.FijarCliente = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property Token(ByVal SessionID As String) As String
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.Token
            End Get
            Set(ByVal Value As String)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.Token = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property Excel(ByVal SessionID As String) As System.Web.UI.WebControls.DataGrid
            Get
                Dim obj As System.Web.UI.WebControls.DataGrid
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                obj = Sesion.Excel
                Sesion.Excel = Nothing
                Return obj
            End Get
            Set(ByVal Value As System.Web.UI.WebControls.DataGrid)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.Excel = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property

        Public Shared Property Accesos(ByVal SessionID As String) As String
            Get
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Return Sesion.Accesos
            End Get
            Set(ByVal Value As String)
                Sesion = CType(Constantes(CStr(SessionID)), FWPSession)
                Sesion.Accesos = Value
                Constantes(CStr(SessionID)) = Sesion
            End Set
        End Property
    End Class

End Namespace
