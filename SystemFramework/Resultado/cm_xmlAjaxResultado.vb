Option Explicit On 
Option Strict On

Imports System
Imports System.IO
Imports System.Xml

Public Class cm_xmlAjaxResultado
    Inherits XmlDocument

    Private doc As XmlDocument
    Private xmlData As String
    Private elem As XmlElement
    Private _resultado As String
    Private _excepcion As String

    Private Enum TipoResultado
        Resultado = 0
        Excepcion = 1
    End Enum


    Sub New()
        BuildXmlDocument()
    End Sub

    Private Sub BuildXmlDocument()
        xmlData = "<xmldata></xmldata>"
        MyBase.Load(New StringReader(xmlData))
        elem = MyBase.CreateElement("resultado")
        MyBase.DocumentElement.AppendChild(elem)
        elem = MyBase.CreateElement("body")
        MyBase.DocumentElement.AppendChild(elem)
        elem = MyBase.CreateElement("excepcion")
        MyBase.DocumentElement.AppendChild(elem)
    End Sub

    Public Property Resultado() As String
        Get
            Return _resultado
        End Get
        Set(ByVal Value As String)
            _resultado = Value
            completaXmlDocumen(TipoResultado.Resultado)
        End Set
    End Property

    Public Property Excepcion() As String
        Get
            Return _excepcion
        End Get
        Set(ByVal Value As String)
            _excepcion = Value
            completaXmlDocumen(TipoResultado.Excepcion)
        End Set
    End Property

    Private Sub completaXmlDocumen(ByVal tipo As TipoResultado)
        Dim nedeResul As XmlNode
        Dim nedebody As XmlNode
        Dim nedeExcep As XmlNode
        Select Case tipo
            Case TipoResultado.Resultado
                nedeResul = MyBase.FirstChild.FirstChild
                nedeResul.InnerText = "ok"
                nedebody = MyBase.FirstChild.FirstChild.NextSibling
                nedebody.InnerText = Me._resultado
                nedeExcep = MyBase.FirstChild.FirstChild.NextSibling.NextSibling
                nedeExcep.InnerText = ""
            Case TipoResultado.Excepcion
                nedeResul = MyBase.FirstChild.FirstChild
                nedeResul.InnerText = "err"
                nedebody = MyBase.FirstChild.FirstChild.NextSibling
                nedebody.InnerText = ""
                nedeExcep = MyBase.FirstChild.FirstChild.NextSibling.NextSibling
                nedeExcep.InnerText = Me._excepcion
        End Select
    End Sub

    Public Overrides Function ToString() As String
        Return MyBase.OuterXml
    End Function

End Class
