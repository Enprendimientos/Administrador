
Option Strict On
Option Explicit On 

Namespace Fwp.SystemFramework
    ' clase que se usa para las validaciones 
    Public Class ApplicationVerifications
        Public Shared ReadOnly Property LineNumber() As Integer
            Get
                Try
                    ' entrega el numero de linea donde se produjo el error (para efectos de depuracion)
                    With New StackTrace(1, True)
                        LineNumber = .GetFrame(0).GetFileLineNumber
                    End With
                Catch
                End Try
            End Get
        End Property
        ' Metodo que revisa si la condicion entregada en "condition" es Falsa. Si es Falsa geneara una nueva Exception
        ' usando el manejo de errores nativo de NET
        Public Shared Sub CheckCondition(ByVal condition As Boolean, ByVal errorText As String, Optional ByVal lineNumber As Integer = 0)
            If Not condition Then
                Throw (New ApplicationException(errorText))
            End If
        End Sub

        Public Shared Sub CheckArgument(ByVal condition As Boolean, ByVal errorText As String, Optional ByVal lineNumber As Integer = 0)
            If Not condition Then
                Throw (New ArgumentException(errorText))
            End If
        End Sub

    End Class
End Namespace

