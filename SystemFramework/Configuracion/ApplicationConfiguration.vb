
Option Explicit On 

Imports System
Imports System.Diagnostics
Imports System.Configuration
Imports System.Collections
Imports System.Xml
Imports System.Collections.Specialized

Namespace Fwp.SystemFramework
    Public Class ApplicationConfiguration
        Implements IConfigurationSectionHandler
        Private Const RUTACONFIG_CONSTANTES As String = "Fwp.RutaConfig.Constantes"
        Private Const RUTACONFIG_CONSTANTES_DEFAULT As String = ""
        Private Shared _rutaArchivoConfiguracion As String

        Public Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal section As System.Xml.XmlNode) As Object Implements System.Configuration.IConfigurationSectionHandler.Create
            Dim settings As NameValueCollection

            Try
                Dim baseHandler As NameValueSectionHandler
                baseHandler = New NameValueSectionHandler

                settings = CType(baseHandler.Create(parent, configContext, section), NameValueCollection)
            Catch

            End Try
            If settings Is Nothing Then
                _rutaArchivoConfiguracion = RUTACONFIG_CONSTANTES_DEFAULT
            Else
                _rutaArchivoConfiguracion = ReadSetting(settings, RUTACONFIG_CONSTANTES, RUTACONFIG_CONSTANTES_DEFAULT)
            End If
        End Function

        Public Shared Sub OnApplicationStart()
            'ConfigurationManager.GetSection("ApplicationConfiguration")
            'ConfigurationManager.GetSection("FWPConfiguration")

            System.Configuration.ConfigurationSettings.GetConfig("ApplicationConfiguration")
            System.Configuration.ConfigurationSettings.GetConfig("FWPConfiguration")
        End Sub


        Public Overloads Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As String) As String
            Try
                Dim setting As Object = settings(key)
                If setting Is Nothing Then
                    ReadSetting = defaultValue
                Else
                    ReadSetting = CStr(setting)
                End If
            Catch
                ReadSetting = defaultValue
            End Try
        End Function

        Public Shared ReadOnly Property RutaArchivoConfiguracion() As String
            Get
                Return _rutaArchivoConfiguracion
            End Get
        End Property


    End Class
End Namespace

