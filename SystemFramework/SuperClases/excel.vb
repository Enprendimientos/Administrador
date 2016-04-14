Imports System.Data.SqlClient
Imports Fwp.common

Public Class Excel

    Inherits System.Web.UI.Page
    Public pagina As Integer
    Public regpag As Integer
    Public criterio As Integer
    Public Sp As String
    Public CriterioOrden As String
    Public CriterioNombreColumna As String
    Public fil As FwpServerControls.TexBoxFilterCollection

    Public Function GetData(ByVal datagrid As FwpServerControls.FwpDataGridDataBound) As String
        Dim Param As SqlParameter
        Dim myTrans As New FWPTransaction
        Dim conn As New SqlConnection(myTrans.MyConnection.ConnectionString)
        Dim comm As New SqlCommand(Sp, conn)
        comm.CommandType = CommandType.StoredProcedure
        Dim discoveredParameters() As SqlParameter = SPAveriguaParametros(Sp)
        Dim i As Integer
        Param = New SqlParameter("@Pagina", SqlDbType.Int)
        Param.Direction = ParameterDirection.Input
        Param.Value = pagina
        comm.Parameters.Add(Param)
        Param = New SqlParameter("@RegistrosPorPaginas", SqlDbType.Int)
        Param.Direction = ParameterDirection.Input
        Param.Value = regpag
        comm.Parameters.Add(Param)
        'Param = New SqlParameter("@criterio", SqlDbType.Int)
        'Param.Direction = ParameterDirection.Input
        'Param.Value = criterio
        'comm.Parameters.Add(Param)
        If Trim(CriterioNombreColumna) <> "" Then
            Param = New SqlParameter("@ColumnaOrden", SqlDbType.VarChar, 50)
            Param.Direction = ParameterDirection.Input
            Param.Value = CriterioNombreColumna
            comm.Parameters.Add(Param)
            Param = New SqlParameter("@OrdenColumna", SqlDbType.Int)
            Param.Direction = ParameterDirection.Input
            Param.Value = CriterioOrden
            comm.Parameters.Add(Param)
        End If
        Dim anterior As String
        For Each Param In discoveredParameters
            For i = 0 To fil.Count - 1
                Dim IDFILTRO As String = fil(i).ID
                If Left(IDFILTRO, 4) = "txt_" Then
                    IDFILTRO = Mid(IDFILTRO, 5)
                End If
                Select Case fil(i).TipoFiltro
                    Case FwpServerControls.Filtros.Tipo.Date
                        If IDFILTRO = Replace(Mid(Param.ParameterName, 2), "_hasta", "") Then
                            If InStr(Param.ParameterName, "_hasta") = 0 Then
                                Param = New SqlParameter(Param.ParameterName, Param.SqlDbType.VarChar, 20)
                                Param.Direction = ParameterDirection.Input
                                Param.Value = Fechas.ISO(fil(i).DFecha)
                                comm.Parameters.Add(Param)
                            Else
                                Param = New SqlParameter(Param.ParameterName, Param.SqlDbType.VarChar, 20)
                                Param.Direction = ParameterDirection.Input
                                Param.Value = Fechas.ISO(fil(i).HFecha)
                                comm.Parameters.Add(Param)
                            End If
                            Exit For
                        End If
                    Case FwpServerControls.Filtros.Tipo.Logic
                        If IDFILTRO = Mid(Param.ParameterName, 2) Then
                            Param = New SqlParameter(Param.ParameterName, Param.SqlDbType)
                            Param.Direction = ParameterDirection.Input
                            If fil(i).TrueFalse = 2 Then
                                Param.Value = fil(i).TrueFalse
                                comm.Parameters.Add(Param)
                            Else
                                'En la componente esta definido que 0=si, 1=no, 2=todos
                                Param.Value = IIf(fil(i).TrueFalse = 0, 1, 0)
                                comm.Parameters.Add(Param)
                            End If
                            Exit For
                        End If
                    Case FwpServerControls.Filtros.Tipo.Numeric
                        If IDFILTRO = Mid(Param.ParameterName, 2) Then
                            If Not comm.Parameters.Contains(Param.ParameterName) Then
                                Param = New SqlParameter(Param.ParameterName, Param.SqlDbType)
                                Param.Direction = ParameterDirection.Input
                                Param.Value = fil(i).Value
                                comm.Parameters.Add(Param)
                                Exit For
                            End If
                        End If
                    Case FwpServerControls.Filtros.Tipo.Autocompletar
                        If IDFILTRO = Mid(Param.ParameterName, 2) Then
                            Dim id_ As String = FWPConfiguration.AppSettingsText(fil(i).ProcesoAjax)
                            If comm.Parameters.Contains("@" & id_) Then
                                comm.Parameters.RemoveAt("@" & id_)
                            End If
                            Param = New SqlParameter("@" & id_, Param.SqlDbType.Int)
                            Param.Direction = ParameterDirection.Input
                            Param.Value = fil(i).IDValue
                            comm.Parameters.Add(Param)
                            Exit For
                        End If
                    Case FwpServerControls.Filtros.Tipo.Text
                        If IDFILTRO = Mid(Param.ParameterName, 2) Then
                            If Param.SqlDbType <> SqlDbType.Bit Then
                                If InStr(fil(i).Text, "D:") > 0 And InStr(fil(i).Text, "H:") > 0 Then
                                    Dim arr As String() = Split(fil(i).Text, " - ")
                                    Dim desde As Date = Split(arr(0), ":")(1)
                                    Dim hasta As Date = Split(arr(1), ":")(1)
                                    Param = New SqlParameter(Param.ParameterName, Param.SqlDbType)
                                    Param.Direction = ParameterDirection.Input
                                    Param.Value = desde
                                    comm.Parameters.Add(Param)
                                    Param = New SqlParameter(Param.ParameterName & "_hasta", Param.SqlDbType)
                                    Param.Direction = ParameterDirection.Input
                                    Param.Value = hasta
                                    comm.Parameters.Add(Param)
                                Else
                                    Param = New SqlParameter(Param.ParameterName, Param.SqlDbType)
                                    Param.Direction = ParameterDirection.Input
                                    Select Case Param.SqlDbType
                                        Case SqlDbType.Int, SqlDbType.Decimal, SqlDbType.Money, SqlDbType.BigInt
                                            If Not IsNumeric(fil(i).Text) Then
                                                Param.Value = 0
                                            Else
                                                Param.Value = CType(fil(i).Text, Integer)
                                            End If
                                        Case SqlDbType.DateTime, SqlDbType.SmallDateTime
                                            If Not IsDate(fil(i).Text) Then
                                                Param.Value = Date.MinValue
                                            Else
                                                Param.Value = CType(fil(i).Text, Date)
                                            End If
                                        Case SqlDbType.Bit
                                            If fil(i).Text = "" Then
                                                Param.Value = 0
                                            End If
                                        Case Else
                                            Param.Value = fil(i).Text
                                    End Select
                                    comm.Parameters.Add(Param)
                                End If
                            End If
                            Exit For
                        End If
                End Select
            Next
            anterior = Mid(Param.ParameterName, 2)
            'If Param.ParameterName = "@id_solicitante" Then
            '    Dim yo As Integer
            '    yo = 1
            'End If
        Next
        PFun.ParametrosConNombre(comm.Parameters)
        comm.CommandTimeout = 240
        Dim dr As SqlDataReader
        'Dim ad As New SqlDataAdapter(comm)
        Dim ds As New DataSet
        Try
            conn.Open()
            dr = comm.ExecuteReader
            dr.NextResult()

            'Dim gw As New System.Web.UI.WebControls.DataGrid
            Dim dcs As System.Web.UI.WebControls.DataGridColumn
            'gw.AllowPaging = False
            'gw.AllowSorting = False
            'gw.EnableViewState = False
            'gw.AutoGenerateColumns = False
            Dim ruta As String = FWPConfiguration.AppSettings("DirecSitio") & FWPConfiguration.AppSettings("MatPathUpload")
            'Dim ruta As String = Me.Request.PhysicalApplicationPath & FWPConfiguration.AppSettings("MatPathUpload")
            'IO.Directory.CreateDirectory(ruta)
            ruta &= MyBase.Session.SessionID & "_" & datagrid.Titulo & ".xls"
            Dim objStreamWriter As New System.IO.StreamWriter(ruta, False, System.Text.Encoding.Default)
            Dim Cr As Char = Convert.ToChar(13)
            Dim Sep As Char = vbTab
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim arr As New ArrayList
            For Each dcs In datagrid.Columns
                If dcs.GetType.FullName = "System.Web.UI.WebControls.BoundColumn" Then
                    If dcs.Visible Then
                        sb.Append(dcs.HeaderText) : sb.Append(Sep)
                        arr.Add(dcs.SortExpression)
                    End If
                End If
            Next
            sb.Append(vbCrLf)
            While dr.Read
                Dim rut As String
                Dim rut_ct As String
                Dim largo As Integer, largov As Integer
                Dim vigente As String

                'Dim dt As DataTable = ds.Tables(0)
                For j As Integer = 0 To arr.Count - 1
                    sb.Append(dr(arr(j))) : sb.Append(Sep)
                Next
                sb.Append(vbCrLf)
            End While
            dr.Close()
            objStreamWriter.AutoFlush = True
            objStreamWriter.WriteLine(sb.ToString)
            objStreamWriter.Close()
            comm.Connection.Close()
            comm.Connection.Dispose()
            conn.Close()
            conn.Dispose()
            ruta = FWPConfiguration.AppSettings("DirecBase") & FWPConfiguration.AppSettings("MatPathRead") & MyBase.Session.SessionID & "_" & datagrid.Titulo & ".xls"

            Return ruta
            'ad.Fill(ds)
            'ad.Dispose()
            'Return ds.Tables(1)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Private Function SPAveriguaParametros(ByVal sp As String) As SqlParameter()
        Dim myTrans As New FWPTransaction
        Dim conn As New SqlConnection(myTrans.MyConnection.ConnectionString)
        Dim cmd As New SqlCommand(sp, conn)
        cmd.CommandType = CommandType.StoredProcedure
        Dim discoveredParameters() As SqlParameter
        Try
            conn.Open()
            SqlCommandBuilder.DeriveParameters(cmd)
            conn.Close()
            cmd.Parameters.RemoveAt(0)
            discoveredParameters = New SqlParameter(cmd.Parameters.Count - 1) {}
            cmd.Parameters.CopyTo(discoveredParameters, 0)
            'inicialisa con bdnull
            Dim discoveredParameter As SqlParameter
            For Each discoveredParameter In discoveredParameters
                discoveredParameter.Value = DBNull.Value
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return discoveredParameters
    End Function

    Public Sub New()

    End Sub
End Class

