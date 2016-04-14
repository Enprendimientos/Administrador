Option Strict Off
Imports Fwp.Common

Public Class SCReglasNegocios
    Inherits System.Web.UI.Page
    Protected myTrans As FWPTransaction
    Protected _identity As Integer
    Protected _TotalPaginas As Integer
    Protected _TotalRegistros As Integer
    Protected myTransState As FWPTransaction.States = FWPTransaction.States.Liberate

    Public ReadOnly Property Identity() As Integer
        Get
            Return _identity
        End Get
    End Property

    Public ReadOnly Property TotalPaginas() As Integer
        Get
            Return _TotalPaginas
        End Get
    End Property

    Public ReadOnly Property TotalRegistros() As Integer
        Get
            Return _TotalRegistros
        End Get
    End Property

    Public Function ValidaIntegridad(ByVal ObjDatos As Object, ByVal drow As DataRow) As Boolean
        Dim dt As DataTable = ObjDatos.tables(ObjDatos.ESTRUCTURA)
        Dim errorIntegridad As String
        ' recorre al tabla con las estructuras
        For Each drEstruc As DataRow In dt.Rows
            ' saca la posicion de la columna asociada
            Dim columna As Integer = drow.Table.Columns(drEstruc(cm_estructuraSQL.NOMBRE_COLUMNA)).Ordinal
            If drEstruc(cm_estructuraSQL.TIPO_COLUMNA) Is GetType(System.String) Then
                If Len(drow(columna)) > drEstruc(cm_estructuraSQL.LARGO_COLUMNA) Then
                    errorIntegridad += "campo: " + drEstruc(cm_estructuraSQL.DESCRIPCION_COLUMNA) + " Largo Máximo: " + drEstruc(cm_estructuraSQL.LARGO_COLUMNA) + "\n"
                End If
            End If
            ' si no soporta nulos hay que valida si tiene o no campos vacios, 
            ' la comparacion de los campos vacios dependen del tipo
            ' se salta la llave principal en la comparación
            If drEstruc(cm_estructuraSQL.SOPORTANULL_COLUMNA) = False And drEstruc(cm_estructuraSQL.NOMBRE_COLUMNA) <> ObjDatos.KEY Then
                Dim checkVacio = False
                Select Case drEstruc(cm_estructuraSQL.TIPO_COLUMNA)
                    Case SqlDbType.Int, SqlDbType.Money, SqlDbType.Decimal
                        If NumInt.Init(drow(columna)) = 0 Then
                            checkVacio = True
                        End If
                    Case SqlDbType.VarChar
                        If drow(columna) Is DBNull.Value Then
                            checkVacio = True
                        Else
                            If drow(columna) = "" Then
                                checkVacio = True
                            End If
                        End If
                    Case SqlDbType.SmallDateTime, SqlDbType.DateTime
                        If drow(columna) Is DBNull.Value Then
                            checkVacio = True
                        End If
                    Case SqlDbType.Bit
                        If drow(columna) Is DBNull.Value Then
                            checkVacio = True
                        End If
                    Case Else
                        Throw New Exception("Tipo desconocido para la SuperClase Reglas de Negocio Campo:" + drEstruc(cm_estructuraSQL.DESCRIPCION_COLUMNA))
                End Select
                ' verifica si viene vacio y lo agrega al string de control de errores
                If checkVacio Then
                    errorIntegridad += "campo: " + drEstruc(cm_estructuraSQL.DESCRIPCION_COLUMNA) + " No puede ser Vacio\n"
                End If
            End If
        Next
        If Len(errorIntegridad) > 0 Then
            Throw New Exception(errorIntegridad)
        End If
        Return True
    End Function

    Public Function Enviar_correo() As Boolean
        Try

        Catch ex As Exception

        End Try
    End Function
End Class
