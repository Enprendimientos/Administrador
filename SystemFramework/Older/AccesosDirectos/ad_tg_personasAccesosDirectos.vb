
Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

'Imports ETP.Common
'Imports ETP.Common.Data
'Imports ETP.Common.Nomina
Imports Fwp.Common
Imports Fwp.SystemFramework

Namespace Fwp.SystemFramework.Menu
    Public Class ad_tg_personasAccesosDirectos
        ' hereda de la super clase de acceso a datos
        Inherits SCAccesoDatos

        Public Sub New(ByVal Trans As FWPTransaction)
            MyBase.New()
            _Trans = Trans
        End Sub

        ' funcion de recuperacion de datos, se basa en metodo GetDataGenerico de la Super Clase SCAccesoDatos
        Public Function GetData(ByVal ObjDatos As cm_tg_personasAccesosDirectos) As cm_tg_personasAccesosDirectos
            Try
                ObjDatos = CType(MyBase.GetDataGenerico(ObjDatos, "pa_tg_personasAccesosDirectos_sel", _Trans), cm_tg_personasAccesosDirectos)
                If ObjDatos.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows.Count > 0 Then
                    _identity = CInt(ObjDatos.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows(0)(ObjDatos.KEY))
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return ObjDatos
        End Function

        ' metodo que realiza la inserción, se basa en metodo InsertGenerico de la Super Clase SCAccesoDatos
        Public Function Insert(ByVal ObjDatos As cm_tg_personasAccesosDirectos) As Boolean
            Try
                Me._identity = InsertGenerico(ObjDatos, "pa_tg_personasAccesosDirectos_in", _Trans)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return True
        End Function

        Public Function Update(ByVal ObjDatos As cm_tg_personasAccesosDirectos) As Boolean
            Try
                Me._identity = UpdateGenerico(ObjDatos, "pa_tg_personasAccesosDirectos_ac", _Trans)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return True
        End Function

        Public Function Delete(ByVal ID As Integer) As Boolean
            Try
                Dim ds As New cm_tg_personasAccesosDirectos
                Dim drow As DataRow = ds.Tables(cm_tg_personasAccesosDirectos.TABLA).NewRow
                drow(ds.KEY) = ID
                ds.Tables(cm_tg_personasAccesosDirectos.TABLA).Rows.Add(drow)
                Return Delete(ds)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function Delete(ByVal ObjDatos As cm_tg_personasAccesosDirectos) As Boolean
            Try
                Return DeleteGenerico(ObjDatos, "pa_tg_personasAccesosDirectos_el", _Trans)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function Get_tg_personasAccesosDirectos_nomina(ByVal pnom As ParametrosNomina) As DataTable
            Dim ds As New DataSet
            Dim dsnm As New cm_tg_personasAccesosDirectos_no(pnom)
            Try
                ds = GetNominaGenerico(dsnm, "pa_tg_personasAccesosDirectos_no_" & pnom.ColumnaOrden & "_" & pnom.Orden.ToString, _Trans)
                If ds.Tables(1).Rows.Count > 0 Then
                    Me._TotalRegistros = CInt(ds.Tables(1).Rows(0)("registros"))
                    Me._TotalPaginas = CInt(ds.Tables(1).Rows(0)("paginas"))
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return (ds.Tables(2))
        End Function

    End Class
End Namespace


