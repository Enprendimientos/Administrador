
Namespace Fwp.common
    Public Class FWPSession
        Private _CONNECTIONSTRING As String
        Private _Cliente As String
        Private _Cons_User As String
        Private _ID_Person As String
        Private _NamePerson As String
        Private _queryvars As String
        Private _ID_User As Integer
        Private _Perfil As Integer
        Private _Token As String
        Private _Accesos As String
        Private _Excel As System.Web.UI.WebControls.DataGrid
        Private _ID_Oficina As Integer
        Private _ID_Organizacion As Integer
        Private _CambioPassword As Boolean
        Private Constantes As Hashtable
        Private _Navegacion As FwpBase.Navegacion
        Private _MontoGarantia As Decimal

        Public Sub New()
            Constantes = New Hashtable
        End Sub

        Public Property Item(ByVal Constante As String) As Object
            Get
                Return Constantes(Constante)
            End Get
            Set(ByVal Value As Object)
                Add(Constante, Value)
            End Set
        End Property


        Public Sub Add(ByVal Constante As String, ByVal Valor As Object)
            If Contains(CStr(Constante)) Then
                Constantes.Remove(CStr(Constante))
            End If
            Constantes.Add(CStr(Constante), Valor)
        End Sub

        Public Sub Remove(ByVal Constante As String)
            If Contains(CStr(Constante)) Then
                Constantes.Remove(CStr(Constante))
            End If
        End Sub

        Public ReadOnly Property Contains(ByVal Constante As String) As Boolean
            Get
                Return Constantes.Contains(Constante)
            End Get
        End Property

        Public Property ID_User() As Integer
            Get
                Return _ID_User
            End Get
            Set(ByVal Value As Integer)
                _ID_User = Value
            End Set
        End Property


        Public Property Cons_User() As String
            Get
                Return _Cons_User
            End Get
            Set(ByVal Value As String)
                _Cons_User = Value
            End Set
        End Property

        Public Property ID_Person() As Integer
            Get
                Return _ID_Person
            End Get
            Set(ByVal Value As Integer)
                _ID_Person = Value
            End Set
        End Property


        Public Property ID_Oficina() As Integer
            Get
                Return _ID_Oficina
            End Get
            Set(ByVal Value As Integer)
                _ID_Oficina = Value
            End Set
        End Property

        Public Property ID_Organizacion() As Integer
            Get
                Return _ID_Organizacion
            End Get
            Set(ByVal Value As Integer)
                _ID_Organizacion = Value
            End Set
        End Property

        Public Property CambioPassword() As Boolean
            Get
                Return _CambioPassword
            End Get
            Set(ByVal Value As Boolean)
                _CambioPassword = Value
            End Set
        End Property
        '

        Public Property Name_Person() As String
            Get
                Return _NamePerson
            End Get
            Set(ByVal Value As String)
                _NamePerson = Value
            End Set
        End Property

        Public Property queryvars() As String
            Get
                Return _queryvars
            End Get
            Set(ByVal Value As String)
                _queryvars = Value
            End Set
        End Property

        Public WriteOnly Property FijarCliente() As String
            Set(ByVal Value As String)
                _Cliente = Value
                _CONNECTIONSTRING = CType(FWPConfiguration.GetValue(Value.ToLower), String)
            End Set
        End Property

        Public ReadOnly Property Cliente() As String
            Get
                Return _Cliente
            End Get
        End Property

        Public ReadOnly Property ConnectionString() As String
            Get
                If Not _CONNECTIONSTRING Is Nothing Then
                    Return _CONNECTIONSTRING
                Else
                    Throw New Exception("No se ha fijado al cliente para obtener el string de conexión")
                End If
            End Get
        End Property

        Public Property Token() As String
            Get
                Return _Token
            End Get
            Set(ByVal Value As String)
                _Token = Value
            End Set
        End Property

        Public Property Excel() As System.Web.UI.WebControls.DataGrid
            Get
                Return _Excel
            End Get
            Set(ByVal Value As System.Web.UI.WebControls.DataGrid)
                _Excel = Value
            End Set
        End Property

        Public Property Perfil() As Integer
            Get
                Return _Perfil
            End Get
            Set(ByVal Value As Integer)
                _Perfil = Value
            End Set
        End Property

        Public Property Accesos() As String
            Get
                Return _Accesos
            End Get
            Set(ByVal Value As String)
                _Accesos = Value
            End Set
        End Property

        Public Property MontoGarantia() As Decimal
            Get
                Return _MontoGarantia
            End Get
            Set(ByVal Value As Decimal)
                _MontoGarantia = Value
            End Set
        End Property

        'Public Property Navegacion() As FwpBase.Navegacion
        '    Get
        '        Return _Navegacion
        '    End Get
        '    Set(ByVal Value As FwpBase.Navegacion)
        '        _Navegacion = Value
        '    End Set
        'End Property
    End Class
End Namespace

