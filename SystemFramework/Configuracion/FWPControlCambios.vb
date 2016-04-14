Imports Fwp.Common
Imports System.Data.SqlClient
Imports System.Web.Mail

Public Class ControlCambios
    Inherits System.Web.UI.Page
    Private _Trans As FWPTransaction
    Private _DatosAntesUpdate As DataSet
    Private _DatosUpdate As DataSet
    Private _id_original As Integer
    Private _cc_nombretabla As String
    Private _cc_nombrecampo As String
    Private _cc_valorcampo As String
    Private _TA As TipoAccion

    Private Enum TipoAccion
        Insert = 1
        Update = 2
        Delete = 3
    End Enum

    Sub New()
        _Trans = New FWPTransaction
    End Sub

    Sub New(ByVal Trans As FWPTransaction)
        _Trans = Trans
    End Sub

    Private Function GetData(ByVal ObjDatos As Object) As DataSet
        Try
            Dim ds As New DataSet
            Dim KeyID As Integer = CInt(ObjDatos.Tables(ObjDatos.TABLA).Rows.Item(0)(ObjDatos.KEY))
            Dim comm As New SqlCommand("pa_" & ObjDatos.TABLA & "_sel", _Trans.MyConnection)
            comm.CommandType = CommandType.StoredProcedure
            Dim Param As SqlParameter
            Param = New SqlParameter("@" & CStr(ObjDatos.KEY), SqlDbType.Int)
            Param.Direction = ParameterDirection.Input
            Param.Value = KeyID
            comm.Parameters.Add(Param)
            comm.Transaction = _Trans.myTransaction
            Dim DataAdapter As New SqlDataAdapter(comm)
            DataAdapter.Fill(ds)

            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ControlDeCambiosAntesUpdate(ByVal ObjDatos As Object) As Boolean
        Try
            _DatosUpdate = ObjDatos
            _DatosAntesUpdate = GetData(ObjDatos)
        Catch ex As Exception
            LogXML(0, ObjDatos.TABLA, "", "", _TA, ex.Message)
        End Try
    End Function

    Public Function ControlDeCambiosInsert(ByVal ObjDatos As Object, ByVal identity As Integer) As Boolean

        Try
            '_Trans.BeginTransaction()
            For Each dc As DataColumn In ObjDatos.Tables(ObjDatos.TABLA).Columns
                _id_original = identity
                _cc_nombretabla = ObjDatos.TABLA
                _cc_nombrecampo = dc.ColumnName
                _cc_valorcampo = Txt.Init(ObjDatos.Tables(ObjDatos.TABLA).Rows(0)(dc.ColumnName))
                _TA = TipoAccion.Insert
                SaveChange(ObjDatos.RawUrl, _id_original, _cc_nombretabla, _cc_nombrecampo, _cc_valorcampo, _TA, _Trans)
                'SaveChange(Request.RawUrl, ObjDatos.Tables(ObjDatos.TABLA).Row(0)(ObjDatos.Key), ObjDatos.TABLA, dc.ColumnName, ObjDatos.Tables(ObjDatos.TABLA).Row(0)(dc.ColumnName), TipoAccion.Insert, _Trans)
            Next
            '_Trans.Commit()
        Catch ex As Exception
            '_Trans.Rollback()
            LogXML(_id_original, _cc_nombretabla, _cc_nombrecampo, _cc_valorcampo, _TA, ex.Message)
            'Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function ControlDeCambiosUpdate() As Boolean
        Dim ObjOriginal As DataTable = _DatosAntesUpdate.Tables(0)
        Dim ObjDatos As Object = _DatosUpdate
        Dim Trans As New FWPTransaction
        Try
            ' _Trans.BeginTransaction()
            For Each dc As DataColumn In ObjDatos.Tables(ObjDatos.TABLA).Columns
                For Each drow As DataRow In ObjDatos.Tables(ObjDatos.TABLA).Rows
                    If Txt.Init(ObjOriginal.Rows(0)(dc.ColumnName)) <> Txt.Init(drow(dc.ColumnName)) Then
                        _id_original = drow(ObjDatos.Key)
                        _cc_nombretabla = ObjDatos.TABLA
                        _cc_nombrecampo = dc.ColumnName
                        _cc_valorcampo = drow(dc.ColumnName)
                        _TA = TipoAccion.Update
                        SaveChange(ObjDatos.RawUrl, _id_original, _cc_nombretabla, _cc_nombrecampo, _cc_valorcampo, _TA, _Trans)
                        'SaveChange("", drow(ObjDatos.Key), ObjDatos.TABLA, dc.ColumnName, drow(dc.ColumnName), TipoAccion.Update, _Trans)
                    End If
                Next
            Next
            '_Trans.Commit()
        Catch ex As Exception
            '_Trans.Rollback()
            LogXML(_id_original, _cc_nombretabla, _cc_nombrecampo, _cc_valorcampo, _TA, ex.Message)
            'Throw New Exception(ex.Message)
        End Try
    End Function


    Public Function ControlDeCambiosDelete(ByVal ObjDatos As Object) As Boolean
        Dim Trans As New FWPTransaction

        Try
            '_Trans.BeginTransaction()
            For Each dc As DataColumn In ObjDatos.Tables(ObjDatos.TABLA).Columns
                _id_original = NumInt.Init(ObjDatos.Tables(ObjDatos.TABLA).Rows(0)(ObjDatos.Key))
                _cc_nombretabla = ObjDatos.TABLA
                _cc_nombrecampo = dc.ColumnName
                _cc_valorcampo = Txt.Init(ObjDatos.Tables(ObjDatos.TABLA).Rows(0)(dc.ColumnName))
                _TA = TipoAccion.Delete
                SaveChange(ObjDatos.RawUrl, _id_original, _cc_nombretabla, _cc_nombrecampo, _cc_valorcampo, _TA, _Trans)
            Next
            ' _Trans.Commit()
        Catch ex As Exception
            '_Trans.Rollback()
            LogXML(_id_original, _cc_nombretabla, _cc_nombrecampo, _cc_valorcampo, _TA, ex.Message)
            'Throw New Exception(ex.Message)
        End Try
    End Function

    Private Function SaveChange(ByVal RawUrl As String, ByVal id_original As Integer, ByVal cc_nombretabla As String, ByVal cc_nombrecampo As String, ByVal cc_valorcampo As Object, ByVal TA As TipoAccion, ByVal Trans As FWPTransaction)
        Dim comm As New SqlCommand("pa_cu_controlcambios_in", Trans.MyConnection)
        comm.CommandType = CommandType.StoredProcedure
        Dim Param As SqlParameter
        Param = New SqlParameter("@cc_urlaspx", SqlDbType.VarChar, 200)
        Param.Direction = ParameterDirection.Input
        Param.Value = RawUrl
        comm.Parameters.Add(Param)
        Param = New SqlParameter("@id_original", SqlDbType.Int)
        Param.Direction = ParameterDirection.Input
        Param.Value = id_original
        comm.Parameters.Add(Param)
        Param = New SqlParameter("@cc_nombretabla", SqlDbType.VarChar, 50)
        Param.Direction = ParameterDirection.Input
        Param.Value = cc_nombretabla
        comm.Parameters.Add(Param)
        Param = New SqlParameter("@cc_nombrecampo", SqlDbType.VarChar, 50)
        Param.Direction = ParameterDirection.Input
        Param.Value = cc_nombrecampo
        comm.Parameters.Add(Param)
        Param = New SqlParameter("@cc_valorcampo", SqlDbType.VarChar, 500)
        Param.Direction = ParameterDirection.Input
        Param.Value = Txt.Db(cc_valorcampo)
        comm.Parameters.Add(Param)
        Param = New SqlParameter("@cc_usuario", SqlDbType.VarChar, 15)
        Param.Direction = ParameterDirection.Input
        Param.Value = FWPConfiguration.Cons_User(Session.SessionID)
        comm.Parameters.Add(Param)
        Param = New SqlParameter("@cc_fecha", SqlDbType.SmallDateTime)
        Param.Direction = ParameterDirection.Input
        Param.Value = Now
        comm.Parameters.Add(Param)
        Param = New SqlParameter("@cc_tipo", SqlDbType.Int)
        Param.Direction = ParameterDirection.Input
        Param.Value = TA
        comm.Parameters.Add(Param)
        Try
            comm.Transaction = Trans.myTransaction
            comm.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Function LogXML(ByVal id_original As Integer, ByVal cc_nombretabla As String, ByVal cc_nombrecampo As String, ByVal cc_valorcampo As Object, ByVal TA As TipoAccion, ByVal MsgError As String) As Boolean
        Try
            Dim ds As DataSet
            Dim UrlFileXML As String = context.Request.PhysicalApplicationPath & FWPConfiguration.AppSettings("sistema.cc.log")
            If IO.File.Exists(UrlFileXML) Then
                ds.ReadXml(UrlFileXML)
            Else
                Dim dt As DataTable
                ds = New DataSet
                dt = New DataTable
                dt.Columns.Add("id_original", GetType(Integer))
                dt.Columns.Add("cc_nombretabla", GetType(String))
                dt.Columns.Add("cc_nombrecampo", GetType(String))
                dt.Columns.Add("cc_valorcampo", GetType(String))
                dt.Columns.Add("cc_fecha", GetType(Date))
                dt.Columns.Add("cc_tipo", GetType(Integer))
                dt.Columns.Add("Error", GetType(String))
                ds.Tables.Add(dt)
            End If
            Dim dr As DataRow = ds.Tables(0).NewRow
            dr("id_original") = id_original
            dr("cc_nombretabla") = cc_nombretabla
            dr("cc_nombrecampo") = cc_nombrecampo
            dr("cc_valorcampo") = cc_valorcampo
            dr("cc_fecha") = Now
            dr("cc_tipo") = TA
            dr("Error") = MsgError
            ds.Tables(0).Rows.Add(dr)
            ds.WriteXml(UrlFileXML)
            EnviaMail(UrlFileXML)
        Catch : End Try
    End Function

    Private Sub EnviaMail(ByVal UrlFileXML As String)
        Try
            Dim msg As MailMessage
            msg = New MailMessage
            msg.BodyFormat = MailFormat.Html
            msg.To = FWPConfiguration.AppSettings("mail.admin")
            msg.From = FWPConfiguration.AppSettings("mail.sistema")
            msg.Priority = MailPriority.High
            msg.Subject = "Error al registrar un cambio (Modulo de Control de Cambios)"
            msg.Body = "El error esta registrado en el archivo de log ubicado en: " & UrlFileXML & "<br>"
            msg.Body &= "Fecha y Hora: " & Now.ToString & "<br><br>"
            msg.Body &= FWPConfiguration.AppSettings("NombreSistema")
            SmtpMail.SmtpServer = FWPConfiguration.AppSettings("mail.SMTP")
            SmtpMail.Send(msg)
        Catch : End Try
    End Sub

End Class
