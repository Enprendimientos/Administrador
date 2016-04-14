' remplazar 
' Administracion por el nombre del modulo correspondiente
' id_personaAccesoDirecto  por nombre del la llave principal
' tg_personasAccesosDirectos por el nombre de la tabla en la base de datos  Ej tg_Administracion
' Administracion por el nombre logico de la tabla ej Administracion

Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports Fwp.Common
Imports Fwp.SystemFramework
'Imports ETP.Common
'Imports ETP.Common.Data
'Imports ETP.Common.Nomina
'Imports ETP.BusinessRules.Administracion_RN

' se crea un NameSpace para poder referenciar los componentes cuando se hace un imports.
' en la práctica sirve para ordenar de mejor manera los componentes
Namespace Fwp.SystemFramework.Menu
    ' implementa el objeto Administracion, en general corresponde al objeto de la vida 
    ' real (ej: factura), muchas veces es equivalente a la tabla de la base de datos
    Public Class fn_tg_personasAccesosDirectos
        Inherits SCFachadaOLD

        ' Metodo constructor de la clase, debe recibir el string con el nombre del cliente
        Public Sub New()
            MyBase.New()
        End Sub

        ' Metodo que permite recuperar un objeto a partir del identity, devuelve un DataSet
        Public Function GetData(ByVal id As Integer) As cm_tg_personasAccesosDirectos
            Dim ds As cm_tg_personasAccesosDirectos
            With New rn_tg_personasAccesosDirectos
                ds = .GetData(id)
                ' llena la propiedad privada con el Identity
                MyBase._identity = .Identity
            End With
            Return ds
        End Function

        ' Metodo que permite recuperar un objeto a partir de cualquier campo, devuelve un DataSet con todos los
        ' registros que parean la condicion (multiregistro)
        Public Function GetData(ByVal tg_personasAccesosDirectos As cm_tg_personasAccesosDirectos) As cm_tg_personasAccesosDirectos
            Dim ds As cm_tg_personasAccesosDirectos
            With New rn_tg_personasAccesosDirectos
                ds = .GetData(tg_personasAccesosDirectos)
                ' llena la propiedad privada con el Identity
                _identity = .Identity
            End With
            Return ds
        End Function

        ' Metodo que actualiza o inserta uno o varios registros en la Base de datos
        Public Function Update(ByVal tg_personasAccesosDirectos As cm_tg_personasAccesosDirectos) As Boolean
            ' revisa condiciones de validación básicas. las definitivas deben ir a nivel de las reglas de negocios
            ApplicationVerifications.CheckCondition(Not tg_personasAccesosDirectos Is Nothing, "El parametro Administracion no puede ser nulo", ApplicationVerifications.LineNumber)
            Try
                ' Verifica que el id sea valido
                If CType(PFun.elimina_nulo(tg_personasAccesosDirectos.Tables(tg_personasAccesosDirectos.TABLA).Rows(0)(tg_personasAccesosDirectos.KEY), 0), Integer) = 0 Then
                    tg_personasAccesosDirectos.Tables(tg_personasAccesosDirectos.TABLA).Rows(0)(tg_personasAccesosDirectos.KEY) = 0
                End If
                ' genera un constructor para el objeto que voy a actualizar
                With New rn_tg_personasAccesosDirectos
                    If CInt(tg_personasAccesosDirectos.Tables(tg_personasAccesosDirectos.TABLA).Rows(0)(tg_personasAccesosDirectos.KEY)) = 0 Then
                        Update = .Insert(tg_personasAccesosDirectos)
                        _identity = .Identity
                    Else
                        Update = .Update(tg_personasAccesosDirectos)
                        _identity = .Identity
                    End If
                End With
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        End Function

        ' Metodo que permite recuperar un objeto a partir de cualquier campo, devuelve un DataSet con todos los
        ' registros que parean la condicion (multiregistro)
        Public Function Delete(ByVal ID As Integer) As Boolean
            Dim ds As cm_tg_personasAccesosDirectos
            Try
                With New rn_tg_personasAccesosDirectos
                    Return .Delete(ID)
                End With
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function Get_tg_personasAccesosDirectos_nomina(ByVal pn As ParametrosNomina) As DataTable
            ApplicationVerifications.CheckCondition(Not pn Is Nothing, "El parametro PN no puede ser nulo", ApplicationVerifications.LineNumber)
            Dim dt As DataTable
            Try
                With New rn_tg_personasAccesosDirectos
                    dt = .Get_tg_personasAccesosDirectos_nomina(pn)
                    _totalpaginas = .TotalPaginas()
                    _totalRegistros = .TotalRegistros()
                End With
                Return dt
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        End Function



    End Class
End Namespace






