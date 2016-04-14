' remplazar 
' Administracion por el nombre del modulo correspondiente
' id_personaAccesoDirecto  por nombre del la llave principal
' tg_personasAccesosDirectos por el nombre de la tabla en la base de datos  Ej tg_bitacoras
' Administracion por el nombre logico de la tabla ej Bitacora

Option Strict On
Option Explicit On 
' genera los imports correspondientes incluyendo los namespaces
Imports System.Data
'Imports ETP.Common
'Imports ETP.Common.Data
'Imports ETP.Common.Nomina
'Imports ETP.DataAccess.Administracion_AD
Imports Fwp.Common
Imports Fwp.SystemFramework

Namespace Fwp.SystemFramework.Menu
    Public Class rn_tg_personasAccesosDirectos
        ' hereda de la superclase SCReglasNegocios
        Inherits SCReglasNegocios

        Public Sub New()
            MyBase.New()
            myTrans = New FWPTransaction
        End Sub
#Region "Metodos asociados a Administracion"

        ' Funcion de recuperacion por el ID
        Public Function GetData(ByVal id As Integer) As cm_tg_personasAccesosDirectos
            ApplicationVerifications.CheckCondition(id > 0, "El parámetro ID debe ser mayor a cero para una recuperación precisa", ApplicationVerifications.LineNumber)
            Dim ds As New cm_tg_personasAccesosDirectos
            Try
                ' crea una nueva fila en la tabla principal de la estructura
                Dim drow As DataRow = ds.Tables(cm_tg_personasAccesosDirectos.TABLA).NewRow
                ' asocia a la columna Key (ID) el valor del id.
                drow(ds.KEY) = id
                ' agregar la fila a la tabla
                ds.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows.Add(drow)
                ds = Me.GetData(ds)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            ' llama a la funcion que recupera datos por cualquier dato solo con el ID lleno.
            Return ds
        End Function

        ' Funcion generica de recuperacion de datos por todos los campos
        Public Function GetData(ByVal objDatos As cm_tg_personasAccesosDirectos) As cm_tg_personasAccesosDirectos
            Dim ds As cm_tg_personasAccesosDirectos
            Try
                With New ad_tg_personasAccesosDirectos(myTrans)
                    ds = .GetData(objDatos)
                    _identity = .Identity
                End With
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return ds
        End Function

        ' Funcion de Insercion de un nuevo registro
        Public Function Insert(ByVal objDatos As cm_tg_personasAccesosDirectos) As Boolean
            Dim result As Boolean
            ' validaciones básicas
            ApplicationVerifications.CheckCondition(Not objDatos Is Nothing, "El parametro objDatos no puede ser nulo", ApplicationVerifications.LineNumber)
            ApplicationVerifications.CheckCondition(objDatos.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows.Count > 0, "Para poder insertar debe tener al menos un registro en la objDatos", ApplicationVerifications.LineNumber)

            With objDatos.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows(0)
                Dim dr As DataRow
                Try
                    ' revisa cada una de las filas de la tabla
                    For Each dr In objDatos.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows
                        ' valida la fila 
                        result = Validate(dr)
                    Next

                    ' se debe hacer un try-catch para capturar el error y hacer rollback de la transaccion
                    Try
                        ' comienza la transaccion de inserción
                        myTrans.BeginTransaction()
                        ' crear nueva clase con la estructura del registro a actualizar
                        With New ad_tg_personasAccesosDirectos(myTrans)
                            result = .Insert(objDatos)
                            _identity = .Identity
                        End With
                        myTrans.Commit()
                    Catch ex As Exception
                        myTrans.Rollback()
                        Throw New Exception(ex.Message)
                    End Try

                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                End Try
            End With
            Insert = result
        End Function

        ' Actualiza a partir de la definicion del Objeto
        Public Function Update(ByVal objDatos As cm_tg_personasAccesosDirectos) As Boolean
            Try
                Dim result As Boolean
                ApplicationVerifications.CheckCondition(Not objDatos Is Nothing, "El parametro para la actualización no puede ser nulo", ApplicationVerifications.LineNumber)
                ApplicationVerifications.CheckCondition(objDatos.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows.Count = 1, "El parametro objDatos debe contener una fila", ApplicationVerifications.LineNumber)
                With objDatos.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows(0)
                    result = Validate(objDatos.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows(0))
                    If result Then
                        myTrans.BeginTransaction()
                        With New ad_tg_personasAccesosDirectos(myTrans)
                            result = .Update(objDatos)
                            _identity = .Identity
                        End With
                        myTrans.Commit()
                    End If
                End With
                Update = result
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function Get_tg_personasAccesosDirectos_nomina(ByVal pn As ParametrosNomina) As DataTable
            ApplicationVerifications.CheckCondition(Not pn Is Nothing, "El parametro PN no puede ser nulo", ApplicationVerifications.LineNumber)
            Dim dt As DataTable
            Try
                With New ad_tg_personasAccesosDirectos(myTrans)
                    dt = .Get_tg_personasAccesosDirectos_nomina(pn)
                    Me._TotalPaginas = .TotalPaginas
                    Me._TotalRegistros = .TotalRegistros
                End With
                Return dt
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        ' Funcion generica de recuperacion de datos por todos los campos
        Public Function Delete(ByVal ID As Integer) As Boolean
            ApplicationVerifications.CheckCondition(Not ID > 0, "El parametro ID debe ser superior a 0", ApplicationVerifications.LineNumber)
            Dim ds As cm_tg_personasAccesosDirectos
            Try
                With New ad_tg_personasAccesosDirectos(myTrans)
                    Return .Delete(ID)
                End With
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        ' funcion que realiza la validacion de un registro
        Private Shadows Function Validate(ByVal ObjReg As DataRow) As Boolean
            Dim isValid As Boolean = True
            Try
                ' valida los largo
                isValid = MyBase.ValidaIntegridad(New cm_tg_personasAccesosDirectos, ObjReg)

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Validate = isValid
        End Function
#End Region


    End Class
End Namespace

