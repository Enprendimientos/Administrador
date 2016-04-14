Option Explicit On 
Option Strict On

Imports Microsoft.VisualBasic
Imports System

Imports System.Collections
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Xml
Imports System.IO

Namespace Fwp.SystemFramework
    Public Class XMLconfig
        Private mGuardarAlAsignar As Boolean = False
        Private Const configuration As String = "configuration/"
        Private ficConfig As String = ""
        Private XmlConfig As New XmlDocument

        Public Property GuardarAlAsignar() As Boolean
            Get
                Return mGuardarAlAsignar
            End Get
            Set(ByVal value As Boolean)
                mGuardarAlAsignar = value
            End Set
        End Property

        Public Function GetValue(ByVal seccion As String, _
                                ByVal clave As String) As String
            Return GetValue(seccion, clave, "")
        End Function

        Public Function GetValue(ByVal seccion As String, _
                                ByVal clave As String, _
                                ByVal predeterminado As String) As String
            Return cfgGetValue(seccion, clave, predeterminado)
        End Function

        Public Function GetValue(ByVal seccion As String, _
                                ByVal clave As String, _
                                ByVal predeterminado As Integer) As Integer
            Return CInt(cfgGetValue(seccion, clave, predeterminado.ToString))
        End Function

        Public Function GetValue(ByVal seccion As String, _
                                ByVal clave As String, _
                                ByVal predeterminado As Boolean) As Boolean
            Dim def As String = "0"
            If predeterminado Then def = "1"
            def = cfgGetValue(seccion, clave, def)
            If def = "1" Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function GetText(ByVal seccion As String, _
                                ByVal clave As String) As String
            Return GetText(seccion, clave, "")
        End Function
        Public Function GetText(ByVal seccion As String, _
                                ByVal clave As String, _
                                ByVal predeterminado As String) As String
            Return cfgGetText(seccion, clave, predeterminado)
        End Function

        Public Sub SetValue(ByVal seccion As String, _
                            ByVal clave As String, _
                            ByVal valor As String)
            cfgSetValue(seccion, clave, valor)
        End Sub

        Public Sub SetValue(ByVal seccion As String, _
                            ByVal clave As String, _
                            ByVal valor As Integer)
            cfgSetValue(seccion, clave, valor.ToString)
        End Sub

        Public Sub SetValue(ByVal seccion As String, _
                            ByVal clave As String, _
                            ByVal valor As Boolean)
            If valor Then
                cfgSetValue(seccion, clave, "1")
            Else
                cfgSetValue(seccion, clave, "0")
            End If
        End Sub

        Public Sub SetKeyValue(ByVal seccion As String, _
                                ByVal clave As String, _
                                ByVal valor As String)
            cfgSetKeyValue(seccion, clave, valor)
        End Sub

        Public Sub SetKeyValue(ByVal seccion As String, _
                                ByVal clave As String, _
                                ByVal valor As Integer)
            cfgSetKeyValue(seccion, clave, valor.ToString)
        End Sub

        Public Sub SetKeyValue(ByVal seccion As String, _
                                ByVal clave As String, _
                                ByVal valor As Boolean)
            If valor Then
                cfgSetKeyValue(seccion, clave, "1")
            Else
                cfgSetKeyValue(seccion, clave, "0")
            End If
        End Sub

        Public Sub RemoveSection(ByVal seccion As String)
            Dim n As XmlNode
            n = XmlConfig.SelectSingleNode(configuration & seccion)
            If Not n Is Nothing Then
                n.RemoveAll()
                If mGuardarAlAsignar Then
                    Me.Save()
                End If
            End If
        End Sub

        Public Sub Save()
            Try
                'Comentada hasta poder manejar los permisos de escritura en el archivo
                XmlConfig.Save(ficConfig)
            Catch ex As Exception

            End Try
        End Sub

        Public Sub Read()
            Dim fic As String = ficConfig
            Const revDate As String = "Mon, 20 Sep 2006 20:20:00 GMT"
            If File.Exists(fic) Then
                XmlConfig.Load(fic)
                ' Actualizar los datos de la información de esta clase
                Dim b As Boolean = mGuardarAlAsignar
                mGuardarAlAsignar = False
                Me.SetValue("configXml_Info", "info", _
                            "Generado con XmlConfig para Visual Basic 2003")
                Me.SetValue("configXml_Info", "revision", revDate)
                Me.SetValue("configXml_Info", "formatoUTF8", _
                            "El formato de este fichero debe ser UTF-8")
                mGuardarAlAsignar = b
                'Me.Save()
            Else
                ' Crear el XML de configuración con la sección General
                Dim sb As New System.Text.StringBuilder
                sb.Append("<?xml version=""1.0"" encoding=""utf-8"" ?>")
                sb.Append("<configuration>")
                ' Por si es un fichero appSetting
                sb.Append("<configSections>")
                sb.Append("<section name=""General"" " & _
                        "type=""System.Configuration.DictionarySectionHandler"" />")
                sb.Append("</configSections>")
                sb.Append("<General>")
                sb.Append("<!-- Los valores irán dentro del elemento indicado por la clave -->")
                sb.Append("<!-- Aunque también se podrán indicar como pares key / value -->")
                sb.AppendFormat("<add key=""Revisión"" value=""{0}"" />", revDate)
                sb.Append("<!-- La clase siempre los añade como un elemento -->")
                sb.Append("<Copyright></Copyright>")
                sb.Append("</General>")
                '
                sb.AppendFormat("<configXml_Info>{0}", vbCrLf)
                sb.AppendFormat("<info>Generado con Config para Visual Basic 2003" & _
                                "</info>{0}", vbCrLf)
                sb.AppendFormat("<copyright>" & _
                                "</copyright>{0}", vbCrLf)
                sb.AppendFormat("<revision>{0}</revision>{1}", revDate, vbCrLf)
                sb.AppendFormat("<formatoUTF8>El formato de este fichero debe ser UTF-8" & _
                                "</formatoUTF8>{0}", vbCrLf)
                sb.AppendFormat("</configXml_Info>{0}", vbCrLf)
                '
                sb.Append("</configuration>")
                ' Asignamos la cadena al objeto
                XmlConfig.LoadXml(sb.ToString)
                '
                ' Guardamos el contenido de XmlConfig y creamos el fichero
                'XmlConfig.Save(ficConfig)
            End If
        End Sub

        Public Property FileName() As String
            Get
                Return ficConfig
            End Get
            Set(ByVal value As String)
                ' Al asignarlo, NO leemos el contenido del fichero
                ficConfig = value
                'LeerFile()
            End Set
        End Property

        Public Sub New(ByVal File As String)
            ficConfig = File
            ' Por defecto se guarda al asignar los valores
            mGuardarAlAsignar = True
            Read()
        End Sub

        Public Sub New(ByVal fic As String, ByVal guardarAlAsignar As Boolean)
            ficConfig = fic
            mGuardarAlAsignar = guardarAlAsignar
            Read()
        End Sub

        Public Function Secciones() As StringCollection
            Dim d As New StringCollection
            Dim root As XmlNode
            Dim s As String = "configuration"
            root = XmlConfig.SelectSingleNode(s)
            If Not root Is Nothing Then
                For Each n As XmlNode In root.ChildNodes
                    d.Add(n.Name)
                Next
            End If
            Return d
        End Function

        Public Function Claves(ByVal seccion As String) As Hashtable
            Dim hash As Hashtable
            Dim d As New Hashtable 'System.Collections.Specialized.StringDictionary
            Dim root As XmlNode
            seccion = seccion.Replace(" ", "_")
            root = XmlConfig.SelectSingleNode(configuration & seccion)
            If Not root Is Nothing Then
                For Each n As XmlNode In root.ChildNodes
                    If d.ContainsKey(n.Name) = False AndAlso n.Name = "add" Then
                        hash = New Hashtable
                        hash.Add(n.Attributes("value").Value, n.InnerText)
                        d.Add(LCase(n.Attributes("key").Value), hash)
                    End If
                Next
            End If
            Return d
        End Function
        '
        '----------------------------------------------------------------------
        ' Los métodos privados
        '----------------------------------------------------------------------
        '
        ' El método interno para guardar los valores
        ' Este método siempre guardará en el formato:
        ' <seccion><clave>valor</clave></seccion>
        Public Sub cfgSetValue( _
                        ByVal seccion As String, _
                        ByVal clave As String, _
                        ByVal valor As String)
            '
            Dim n As XmlNode
            '
            ' Filtrar los caracteres no válidos
            ' en principio solo comprobamos el espacio
            seccion = seccion.Replace(" ", "_")
            clave = clave.Replace(" ", "_")

            ' Se comprueba si es un elemento de la sección:
            '   <seccion><clave>valor</clave></seccion>
            n = XmlConfig.SelectSingleNode(configuration & seccion & "/" & clave)
            If Not n Is Nothing Then
                n.InnerText = valor
            Else
                Dim root As XmlNode
                Dim elem As XmlElement
                root = XmlConfig.SelectSingleNode(configuration & seccion)
                If root Is Nothing Then
                    ' Si no existe el elemento principal,
                    ' lo añadimos a <configuration>
                    elem = XmlConfig.CreateElement(seccion)
                    XmlConfig.DocumentElement.AppendChild(elem)
                    root = XmlConfig.SelectSingleNode(configuration & seccion)
                End If
                If Not root Is Nothing Then
                    ' Crear el elemento
                    elem = XmlConfig.CreateElement(clave)
                    elem.InnerText = valor
                    ' Añadirlo al nodo indicado
                    root.AppendChild(elem)
                End If
            End If
            '
            If mGuardarAlAsignar Then
                Me.Save()
            End If
        End Sub

        ' Asigna un atributo a una sección
        ' Por ejemplo: <Seccion clave=valor>...</Seccion>
        ' También se usará para el formato de appSettings:
        ' <add key=clave value=valor />
        ' Aunque en este caso, debe existir el elemento a asignar.
        Private Sub cfgSetKeyValue( _
                        ByVal seccion As String, _
                        ByVal clave As String, _
                        ByVal valor As String)
            '
            Dim n As XmlNode
            '
            ' Filtrar los caracteres no válidos
            ' en principio solo comprobamos el espacio
            seccion = seccion.Replace(" ", "_")
            clave = clave.Replace(" ", "_")

            n = XmlConfig.SelectSingleNode(configuration & seccion & _
                                            "/add[@key=""" & clave & """]")
            If Not n Is Nothing Then
                n.Attributes("value").InnerText = valor
            Else
                Dim root As XmlNode
                Dim elem As XmlElement
                root = XmlConfig.SelectSingleNode(configuration & seccion)
                If root Is Nothing Then
                    ' Si no existe el elemento principal,
                    ' lo añadimos a <configuration>
                    elem = XmlConfig.CreateElement(seccion)
                    XmlConfig.DocumentElement.AppendChild(elem)
                    root = XmlConfig.SelectSingleNode(configuration & seccion)
                End If
                If Not root Is Nothing Then
                    Dim a As XmlNode
                    a = CType(XmlConfig.CreateNode(XmlNodeType.Element, _
                                                "", "add", Nothing), XmlNode)

                    Dim b As XmlAttribute
                    b = CType(XmlConfig.CreateNode(XmlNodeType.Attribute, _
                                                 "key", Nothing), XmlAttribute)
                    b.InnerText = clave
                    a.Attributes.Append(b)
                    b = CType(XmlConfig.CreateNode(XmlNodeType.Attribute, _
                                                 "value", Nothing), XmlAttribute)
                    b.InnerText = valor
                    a.Attributes.Append(b)
                    root.AppendChild(a)

                End If
            End If
            If mGuardarAlAsignar Then
                Me.Save()
            End If
        End Sub

        ' Devolver el valor de la clave indicada
        Private Function cfgGetValue( _
                        ByVal seccion As String, _
                        ByVal clave As String, _
                        ByVal valor As String _
                        ) As String
            '
            Dim n As XmlNode
            '
            ' Filtrar los caracteres no válidos
            ' en principio solo comprobamos el espacio
            seccion = seccion.Replace(" ", "_")
            clave = clave.Replace(" ", "_")
            ' Primero comprobar si están el formato de appSettings:
            ' <add key = clave value = valor />
            n = XmlConfig.SelectSingleNode(configuration & seccion & _
                                            "/add[@key=""" & clave & """]")
            If Not n Is Nothing Then
                Return n.Attributes("value").InnerText
            End If
            '
            ' Después se comprueba si está en el formato <Seccion clave = valor>
            n = XmlConfig.SelectSingleNode(configuration & seccion)
            If Not n Is Nothing Then
                Dim a As XmlAttribute = n.Attributes(clave)
                If Not a Is Nothing Then
                    Return a.InnerText
                End If
            End If
            '
            ' Por último se comprueba si es un elemento de seccion:
            '   <seccion><clave>valor</clave></seccion>
            n = XmlConfig.SelectSingleNode(configuration & seccion & "/" & clave)
            If Not n Is Nothing Then
                Return n.InnerText
            End If
            '
            ' Si no existe, se devuelve el valor predeterminado
            Return valor
        End Function

        ' Devolver el valor de la clave indicada
        Private Function cfgGetText( _
                        ByVal seccion As String, _
                        ByVal clave As String, _
                        ByVal valor As String _
                        ) As String
            '
            Dim n As XmlNode
            '
            ' Filtrar los caracteres no válidos
            ' en principio solo comprobamos el espacio
            seccion = seccion.Replace(" ", "_")
            clave = clave.Replace(" ", "_")
            ' Primero comprobar si están el formato de appSettings:
            ' <add key = clave value = valor />
            n = XmlConfig.SelectSingleNode(configuration & seccion & _
                                            "/add[@key=""" & clave & """]")
            If Not n Is Nothing Then
                Return n.Attributes("text").InnerText
            End If
            '
            ' Después se comprueba si está en el formato <Seccion clave = valor>
            n = XmlConfig.SelectSingleNode(configuration & seccion)
            If Not n Is Nothing Then
                Dim a As XmlAttribute = n.Attributes(clave)
                If Not a Is Nothing Then
                    Return a.InnerText
                End If
            End If
            '
            ' Por último se comprueba si es un elemento de seccion:
            '   <seccion><clave>valor</clave></seccion>
            n = XmlConfig.SelectSingleNode(configuration & seccion & "/" & clave)
            If Not n Is Nothing Then
                Return n.InnerText
            End If
            '
            ' Si no existe, se devuelve el valor predeterminado
            Return valor
        End Function

        ' Devolver el valor de la clave indicada
        Public Function cfgGetValues( _
                        ByVal seccion As String) As IDictionary
            '
            Dim h As New Hashtable
            Dim n As XmlNode
            '
            ' Filtrar los caracteres no válidos
            ' en principio solo comprobamos el espacio
            seccion = seccion.Replace(" ", "_")
            '
            ' Después se comprueba si está en el formato <Seccion clave = valor>
            n = XmlConfig.SelectSingleNode(configuration & seccion)


            'Display the contents of the child nodes.
            If n.HasChildNodes Then
                Dim i As Integer
                For i = 0 To n.ChildNodes.Count - 1
                    Dim key As XmlAttribute = n.ChildNodes(i).Attributes(0)
                    Dim value As XmlAttribute = n.ChildNodes(i).Attributes(1)
                    h.Add(key.InnerText, value.InnerText)
                Next i
            End If
            '
            ' Si no existe, se devuelve el valor predeterminado
            Return h
        End Function
    End Class
End Namespace

