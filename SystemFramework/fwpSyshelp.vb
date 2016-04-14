Imports System.Data.SqlClient
Imports Fwp.common

Namespace Ajax
    Public Class fwpSyshelp
        Implements System.Web.IHttpHandler
        Public Proceso As Integer
        Public id_filtro As Integer
        Public id_filtroin As String
        Public id_filtronotin As String
        Public registros As Integer
        Public TxtBuscar As String
        Private _context As System.Web.HttpContext

        Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
            Get
                Return True
            End Get
        End Property

        Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
            _context = context
            Try
                Proceso = FWPConfiguration.AppSettings(context.Request.QueryString("proceso"))
                id_filtro = IIf(IsNumeric(context.Request.QueryString("id_filtro")), context.Request.QueryString("id_filtro"), 0)
                id_filtroin = Replace(context.Request.QueryString("id_filtroin"), "|", ",")
                id_filtronotin = Replace(context.Request.QueryString("id_filtronotin"), "|", ",")
                registros = context.Request.QueryString("registros")
                TxtBuscar = context.Request.QueryString("TxtBuscar")
                context.Response.Write(pa_zhelp())
            Catch ex As Exception
                Dim resul As New cm_xmlAjaxResultado
                resul.Excepcion = ex.Message
                context.Response.Write(resul.ToString)
            End Try
        End Sub

        Private Function pa_zhelp() As String
            Dim resul As New cm_xmlAjaxResultado
            Dim conn As SqlConnection
            Try
                conn = New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("BD_DEFAULT").ConnectionString) 'FWPConfiguration.ConnectionString(_context.Request.Params.Item("ASP.NET_SessionId"))
                Dim comm As New SqlCommand("pa_zhelp_" & Proceso, conn)
                comm.CommandType = CommandType.StoredProcedure
                Dim Param As SqlParameter
                Param = New SqlParameter("@id_filtro", SqlDbType.Int)
                Param.Direction = ParameterDirection.Input
                Param.Value = id_filtro
                comm.Parameters.Add(Param)
                Param = New SqlParameter("@id_filtroin", SqlDbType.VarChar, 50)
                Param.Direction = ParameterDirection.Input
                Param.Value = id_filtroin
                comm.Parameters.Add(Param)
                Param = New SqlParameter("@id_filtronotin", SqlDbType.VarChar, 50)
                Param.Direction = ParameterDirection.Input
                Param.Value = id_filtronotin
                comm.Parameters.Add(Param)
                Param = New SqlParameter("@registros", SqlDbType.Int)
                Param.Direction = ParameterDirection.Input
                Param.Value = registros
                comm.Parameters.Add(Param)
                Param = New SqlParameter("@buscar", SqlDbType.VarChar, 50)
                Param.Direction = ParameterDirection.Input
                Param.Value = TxtBuscar
                comm.Parameters.Add(Param)
                Dim dr As SqlDataReader
                conn.Open()
                dr = comm.ExecuteReader
                Dim str As String = "<xlm>"
                While dr.Read
                    If Not dr.Item(0) Is DBNull.Value And Not dr.Item(1) Is DBNull.Value And dr.Item(1).ToString <> "" And dr.Item(1).ToString.Length > 0 Then
                        str &= "<element id=""" & dr.Item(0) & """>" & dr.Item(1) & "</element>"
                    End If
                End While
                dr.Close()
                str &= "</xlm>"
                resul.Resultado = str.ToString
            Catch ex As Exception
                resul.Excepcion = ex.Message
            Finally
                If Not conn Is Nothing Then
                    conn.Close()
                End If
            End Try
            Return resul.ToString
        End Function
    End Class
End Namespace

