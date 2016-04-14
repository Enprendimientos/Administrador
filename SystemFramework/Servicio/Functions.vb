Imports System.Data.SqlClient
Imports System.Web
Imports System.Configuration
Imports Fwp.common.TiposBases

Public Class PFun
    Public Shared Function Parametros(ByVal param As SqlParameterCollection) As String
        Dim val As String = ""
        Try
            Dim pa As SqlParameterCollection = param
            Dim nom As String = ""
            For I As Integer = 0 To pa.Count - 1
                nom &= pa(I).ParameterName & ", "
                Dim valor As String = ""
                If pa(I).SqlDbType = SqlDbType.VarChar Then
                    If pa(I).Size = 20 Then
                        valor = IIf(PFun.elimina_nulo(pa(I).Value, "''") Is DBNull.Value, "null", pa(I).Value)
                    Else
                        valor = IIf(PFun.elimina_nulo(pa(I).Value, "''") Is DBNull.Value, "''", pa(I).Value)
                    End If
                Else
                    valor = PFun.elimina_nulo(pa(I).Value, 0)
                End If
                Val &= valor & ", "
            Next
            If val <> "" Then
                val = Left(Trim(val), Len(Trim(val)) - 1)
            End If
        Catch: End Try
        Return val
    End Function

    Public Shared Function RetornaDiaHabilAnterior(ByVal fecha As Date, ByVal dia As Integer) As String
        Dim valor As Integer = 0
        ' verifica si es Sabado
        If DatePart(DateInterval.Weekday, DateAdd(DateInterval.Day, -dia, fecha)) = 7 Then
            dia = dia + 1
        End If

        ' verifica si es Domingo
        If DatePart(DateInterval.Weekday, DateAdd(DateInterval.Day, -dia, fecha)) = 1 Then
            dia = dia + 2
        End If

        Return DateAdd(DateInterval.Day, -dia, fecha)

    End Function

    Public Shared Function RetornaDiaAnterior(ByVal fecha As Date, ByVal dia As Integer) As String
        Dim valor As Integer = 0
        ' verifica si es Sabado
        'If DatePart(DateInterval.Weekday, DateAdd(DateInterval.Day, -dia, fecha)) = 7 Then
        '    dia = dia + 1
        'End If

        '' verifica si es Domingo
        'If DatePart(DateInterval.Weekday, DateAdd(DateInterval.Day, -dia, fecha)) = 1 Then
        '    dia = dia + 2
        'End If

        Return DateAdd(DateInterval.Day, -dia, fecha)

    End Function

    Public Shared Function ParametrosConNombre(ByVal param As SqlParameterCollection) As String
        Dim val As String = ""
        Try
            Dim pa As SqlParameterCollection = param
            Dim nom As String = ""

            For I As Integer = 0 To pa.Count - 1
                nom &= pa(I).ParameterName & ", "
                Dim valor As String = ""
                If pa(I).SqlDbType = SqlDbType.VarChar Then
                    If pa(I).Size = 20 Then
                        valor = PFun.elimina_nulo(pa(I).ParameterName, "") & "=" & IIf(PFun.elimina_nulo(pa(I).Value, "''") Is DBNull.Value, "null", pa(I).Value)
                    Else
                        valor = PFun.elimina_nulo(pa(I).ParameterName, "") & "='" & PFun.elimina_nulo(pa(I).Value, "") & "'"
                    End If
                Else
                    valor = PFun.elimina_nulo(pa(I).ParameterName, "") & "=" & PFun.elimina_nulo(pa(I).Value, 0)
                End If
                val &= valor & ", "
            Next
            If val <> "" Then
                val = Left(Trim(val), Len(Trim(val)) - 1)
            End If
        Catch : End Try

        Return val
    End Function



    Public Shared Function elimina_nulo(ByVal campo As Object, ByVal retorno As Object) As Object
        If Not campo Is Nothing AndAlso campo.GetType Is GetType(String) Or campo.GetType Is GetType(ForceUpdateSP) Then
            Dim cam As String = campo
            Return IIf(campo Is System.DBNull.Value Or cam = "", retorno, campo)
        Else
            Return IIf(campo Is System.DBNull.Value, retorno, campo)
        End If
    End Function

    Public Shared Function elimina_cero(ByVal campo As Object, ByVal retorno As Object) As Object
        If Not campo Is Nothing AndAlso campo.GetType Is GetType(String) Then
            Dim cam As String = campo
            Return IIf(campo Is System.DBNull.Value Or cam = "0", retorno, campo)
        Else
            Return IIf(campo = "0", retorno, campo)
        End If
    End Function

    Public Shared Function Mes(ByVal campo As Integer) As String
        Select Case campo
            Case 1
                Mes = "Enero"
            Case 2
                Mes = "Febrero"
            Case 3
                Mes = "Marzo"
            Case 4
                Mes = "Abril"
            Case 5
                Mes = "Mayo"
            Case 6
                Mes = "Junio"
            Case 7
                Mes = "Julio"
            Case 8
                Mes = "Agosto"
            Case 9
                Mes = "Septiembre"
            Case 10
                Mes = "Octubre"
            Case 11
                Mes = "Noviembre"
            Case 12
                Mes = "Diciembre"
            Case Else
                Mes = ""
        End Select
        Return Mes
    End Function

    Public Shared Function elimina_nulo(ByVal campo As Date) As Date
        Return IIf(campo = Nothing, Nothing, campo)
    End Function

    Public Shared Function elimina_nulo(ByVal campo As Integer) As Integer
        Return IIf(campo = Nothing, 0, campo)
    End Function

    Public Shared Function elimina_nulo_valor(ByVal campo As Integer, ByVal valor As Integer) As Integer
        Return IIf(campo = Nothing, valor, campo)
    End Function

    Public Shared Function elimina_nulo(ByVal campo As String) As String
        Return IIf(campo = Nothing, "", campo)
    End Function

    Public Shared Function asigna_nulo_db(ByVal campo As Object) As Object
        Return IIf(campo = Nothing, System.DBNull.Value, campo)
    End Function



    Public Shared Function elimina_cero(ByVal campo As Integer) As Integer
        Return IIf(campo = 0, 0, campo)
    End Function

    Public Shared Function elimina_cero_valor(ByVal campo As Integer, ByVal valor As Integer) As Integer
        Return IIf(campo = 0, valor, campo)
    End Function

    Public Shared Function elimina_cero(ByVal campo As String) As String
        Return IIf(campo = 0, "", campo)
    End Function

    Public Shared Function asigna_cero_db(ByVal campo As Object) As Object
        Return IIf(campo = 0, System.DBNull.Value, campo)
    End Function

    Public Shared Function Fch_Convertir_AAAAMMDD(ByVal fecha) As Date
        If Not fecha = Nothing Then
            fecha = CType(Mid(fecha, 1, 4) & "-" & Mid(fecha, 5, 2) & "-" & Mid(fecha, 7, 2), Date)
        End If
        Return fecha
    End Function

    Public Shared Function RecuperaAcentos(ByVal txt As String) As String
        txt = Replace(txt, "((a))", "á")
        txt = Replace(txt, "((e))", "é")
        txt = Replace(txt, "((i))", "í")
        txt = Replace(txt, "((o))", "ó")
        txt = Replace(txt, "((u))", "ú")
        txt = Replace(txt, "((ñ))", "ñ")
        txt = Replace(txt, "((Ñ))", "Ñ")
    End Function

    Public Shared Function QuitaDecimalesenCero(ByVal Numero As String) As String
        Dim i As Integer
        Dim valpaso As String
        Dim valor As String
        Dim poscoma As Integer = InStr(Numero.ToString, ",")
        If poscoma > 0 Then
            valor = Numero.ToString
            For i = Numero.ToString.Length - 1 To 0 Step -1
                valpaso = Mid(valor, valor.Length, 1)
                If valpaso <> "," Then
                    If valpaso = 0 Then
                        valor = Left(valor, valor.Length - 1)
                    End If
                Else
                    valor = Left(valor, valor.ToString.Length - 1)
                    Exit For
                End If
            Next
        End If
        poscoma = InStr(valor, ",")
        If poscoma > 0 Then
            Dim entero As String = Mid(valor.ToString, 1, poscoma - 1)
            Dim decima As String = Mid(valor.ToString, poscoma + 1)
            valor = Format(CInt(entero), "##,##0") & "," & decima
        Else
            valor = Format(CInt(Numero), "##,##0")
        End If
        Return valor
    End Function

    ' Esta funcion no recupura el texto lo recibe y lo muestra
    Public Shared Function ImplementaFichaJuicioDatagrid(ByVal styleFont As String, ByVal TextoMostrar As String, ByVal ItemIndex As Integer, ByVal id_juicio As Integer, ByVal ver As Integer) As String
        Dim str As String

        str &= "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dg_item_acciones"" valign=""top""  >"
        str &= "  <tr>"
        str &= "  	<td width=""100%"" onclick=""javascript:window.top.CloseWindowEspecial('FichaJuicio');top.createWindow2('Ficha Juicio','FichaJuicio','juicios_web/juicios/wf_ju_fichajudicial.aspx?id_juicio=" & id_juicio & "&solover=" & ver & "',800,600,'FichaJuicio'); "">"
        str &= "        <font style=""" & styleFont & """>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        str &= "    </td>"
        str &= "    <td valign=""top"">"
        str &= "        <img name=""img_" & ItemIndex & """ src=""../../imagenes/comentarios.gif"" onclick=""javascript:window.top.CloseWindowEspecial('FichaJuicio');top.createWindow2('Ficha Juicio','FichaJuicio','juicios_web/juicios/wf_ju_fichajudicial.aspx?id_juicio=" & id_juicio & "&solover=" & ver & "',800,600,'FichaJuicio');"" >"
        str &= "    </td>"
        str &= "  </tr>"
        str &= "</table>"
        Return str
    End Function

    ' Esta funcion no recupura el texto lo recibe y lo muestra
    Public Shared Function ImplementaFichaPersonaDatagrid(ByVal styleFont As String, ByVal TextoMostrar As String, ByVal ItemIndex As Integer, ByVal id_persona As Integer, ByVal ver As Integer) As String
        Dim str As String

        str &= "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dg_item_acciones"" valign=""top""  >"
        str &= "  <tr>"
        str &= "  	<td width=""100%"" onclick=""javascript:window.top.CloseWindowEspecial('FichaPersona');top.createWindow2('Ficha Persona','FichaPersona','juicios_web/administracion/wf_ju_fichapersona.aspx?id_persona=" & id_persona & "&solover=" & ver & "',800,600,'FichaPersona'); "">"
        str &= "        <font style=""" & styleFont & """>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        str &= "    </td>"
        str &= "    <td valign=""top"">"
        str &= "        <img name=""img_" & ItemIndex & """ src=""../../imagenes/comentarios.gif"" onclick=""javascript:window.top.CloseWindowEspecial('FichaPersona');top.createWindow2('Ficha Persona','FichaPersona','juicios_web/administracion/wf_ju_fichapersona.aspx?id_persona=" & id_persona & "&solover=" & ver & "',800,600,'FichaPersona');"" >"
        str &= "    </td>"
        str &= "  </tr>"
        str &= "</table>"
        Return str
    End Function
    Public Shared Function ImplementaFichaDatagrid(ByVal styleFont As String, ByVal TextoMostrar As String, ByVal ItemIndex As Integer, ByVal id_juicio As Integer) As String
        Dim str As String

        str &= "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dg_item_acciones"" valign=""top""  >"
        str &= "  <tr>"
        str &= "  	<td width=""100%"" onclick=""javascript:window.top.CloseWindowEspecial('FichaJuicio');top.createWindow2('Ficha Juicio','FichaJuicio','juicios_web/juicios/wf_ju_fichajudicial.aspx?id_juicio=" & id_juicio & "',800,600,'FichaJuicio'); "">"
        str &= "        <font style=""" & styleFont & """>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        str &= "    </td>"
        str &= "    <td valign=""top"">"
        str &= "        <img name=""img_" & ItemIndex & """ src=""../../imagenes/comentarios.gif"" onclick=""javascript:window.top.CloseWindowEspecial('FichaJuicio');top.createWindow2('Ficha Juicio','FichaJuicio','juicios_web/juicios/wf_ju_fichajudicial.aspx?id_juicio=" & id_juicio & "',800,600,'FichaJuicio');"" >"
        str &= "    </td>"
        str &= "  </tr>"
        str &= "</table>"
        Return str
    End Function
    Public Shared Function ImplementaFichaOperacion(ByVal styleFont As String, ByVal TextoMostrar As String, ByVal ItemIndex As Integer, ByVal id_operacion As Integer) As String
        Dim str As String

        str &= "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dg_item_acciones"" valign=""top""  >"
        str &= "  <tr>"
        str &= "  	<td width=""100%"" onclick=""javascript:window.top.CloseWindowEspecial('FichaOperaciones');top.createWindow2('Ficha Operacion','FichaOperacion','juicios_web/operaciones/wf_op_operaciones_adm.aspx?id_op=" & id_operacion & "',800,600,'FichaOperaciones'); "">"
        str &= "        <font style=""" & styleFont & """>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        str &= "    </td>"
        str &= "    <td valign=""top"">"
        str &= "        <img name=""img_" & ItemIndex & """ src=""../../imagenes/comentarios.gif"" onclick=""javascript:window.top.CloseWindowEspecial('FichaOperaciones');top.createWindow2('Ficha Operacion','FichaOperacion','juicios_web/operaciones/wf_op_operaciones_adm.aspx?id_op=" & id_operacion & "',800,600,'FichaOperaciones');"" >"
        str &= "    </td>"
        str &= "  </tr>"
        str &= "</table>"
        Return str
    End Function


    ' Esta funcion es para implementar la ficha de juicios pero la imagen del comentario la saca 
    ' la raiz
    Public Shared Function ImplementaFichaDatagrid_nivelCarpeta(ByVal styleFont As String, ByVal TextoMostrar As String, ByVal ItemIndex As Integer, ByVal id_juicio As Integer) As String
        Dim str As String

        str &= "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dg_item_acciones"" valign=""top""  >"
        str &= "  <tr>"
        str &= "  	<td width=""100%"" onclick=""javascript:window.top.CloseWindowEspecial('FichaJuicio');top.createWindow2('Ficha Juicio','FichaJuicio','juicios_web/juicios/wf_ju_fichajudicial.aspx?id_juicio=" & id_juicio & "',800,600,'FichaJuicio'); "">"
        str &= "        <font style=""" & styleFont & """>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        str &= "    </td>"
        str &= "    <td valign=""top"">"
        str &= "        <img name=""img_" & ItemIndex & """ src=""../imagenes/comentarios.gif"" onclick=""javascript:window.top.CloseWindowEspecial('FichaJuicio');top.createWindow2('Ficha Juicio','FichaJuicio','juicios_web/juicios/wf_ju_fichajudicial.aspx?id_juicio=" & id_juicio & "',800,600,'FichaJuicio');"" >"
        str &= "    </td>"
        str &= "  </tr>"
        str &= "</table>"
        Return str
    End Function

    Public Shared Function ImplementaFichaPersonaDatagrid_nivelCarpeta(ByVal styleFont As String, ByVal TextoMostrar As String, ByVal ItemIndex As Integer, ByVal id_persona As Integer, ByVal ver As Integer) As String
        Dim str As String

        str &= "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dg_item_acciones"" valign=""top""  >"
        str &= "  <tr>"
        str &= "  	<td width=""100%"" onclick=""javascript:window.top.CloseWindowEspecial('FichaPersona');top.createWindow2('Ficha Persona','FichaPersona','juicios_web/administracion/wf_ju_fichapersona.aspx?id_persona=" & id_persona & "&solover=" & ver & "',800,600,'FichaPersona'); "">"
        str &= "        <font style=""" & styleFont & """>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        str &= "    </td>"
        str &= "    <td valign=""top"">"
        str &= "        <img name=""img_" & ItemIndex & """ src=""../imagenes/comentarios.gif"" onclick=""javascript:window.top.CloseWindowEspecial('FichaPersona');top.createWindow2('Ficha Persona','FichaPersona','juicios_web/administracion/wf_ju_fichapersona.aspx?id_persona=" & id_persona & "&solover=" & ver & "',800,600,'FichaPersona');"" >"
        str &= "    </td>"
        str &= "  </tr>"
        str &= "</table>"
        Return str
    End Function

    Public Shared Function ImplementaPoderJudicial_nivelCarpeta(ByVal styleFont As String, ByVal TextoMostrar As String, ByVal rol As String, ByVal ano As Integer, ByVal id As Integer) As String
        'Dim str As String

        'str &= "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dg_item_acciones"" valign=""top""  >"
        'str &= "  <tr>"
        'str &= "  	<td width=""100%"" onclick=""javascript:window.top.CloseWindowEspecial('PoderJudicial');top.createWindow2('PoderJudicial','PoderJudicial','juicios_web/juicios/wf_ju_poderjudicial.aspx?ju_rol=" & Trim(rol) & "&ju_ano=" & ano & "&ju_idpoderjudicial=" & id & "',800,600,'PoderJudicial'); "">"
        'str &= "        <font style=""" & styleFont & """>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        'str &= "    </td>"
        'str &= "    <td valign=""top"">"
        'str &= "        <img name=""img_tribunal"" src=""../../imagenes/comentarios.gif"" onclick=""javascript:window.top.CloseWindowEspecial('PoderJudicial');top.createWindow2('PoderJudicial','PoderJudicial','juicios_web/juicios/wf_ju_poderjudicial.aspx?ju_rol=" & Trim(rol) & "&ju_ano=" & ano & "&ju_idpoderjudicial=" & id & "',800,600,'PoderJudicial');"" >"
        'str &= "    </td>"
        'str &= "  </tr>"
        'str &= "</table>"
        'Return str

        Dim str As String
        str &= "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""dg_item_acciones"" valign=""top""  >"
        str &= "  <tr>"
        str &= "  	<td width=""100%"" onclick=""javascript:open_window_center('" & ConfigurationSettings.AppSettings("DirecBase") & "wf_ju_poderjudicial.aspx?ju_rol=" & Trim(rol) & "&ju_ano=" & ano & "&ju_idpoderjudicial=" & id & "','poder_judicial','scrollbars=yes,resizable=yes','780','400');"">"
        str &= "        <font style=""" & styleFont & """>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        str &= "    </td>"
        str &= "    <td valign=""top"">"
        str &= "        <img name=""img_tribunal"" src=""../../imagenes/comentarios.gif"" onclick=""javascript:open_window_center('" & ConfigurationSettings.AppSettings("DirecBase") & "wf_ju_poderjudicial.aspx?ju_rol=" & Trim(rol) & "&ju_ano=" & ano & "&ju_idpoderjudicial=" & id & "','poder_judicial','scrollbars=yes,resizable=yes','780','400');"">"
        str &= "    </td>"
        str &= "  </tr>"
        str &= "</table>"
        Return str
    End Function

    Public Shared Function Implementa_Acronym(ByVal styleFont As String, ByVal TextoMostrar As String, ByVal Descripcion As String) As String
        Dim str As String

        str &= "<table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0""  valign=""top"">"
        str &= "  <tr>"
        str &= "  	<td width=""100%"" align=""center"">"
        str &= "      <acronym title=""" & Descripcion & """>"
        str &= "         <font style=""" & styleFont & """>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        str &= "      </acronym>"
        str &= "    </td>"
        str &= "  </tr>"
        str &= "</table>"
        Return str
    End Function

    Public Shared Function ImplementaFichaDatagrid(ByVal styleFont As String, ByVal TextoMostrar As String, ByVal ItemIndex As Integer, ByVal id As String, ByVal funcion As String) As String
        Dim str As String
        Dim id_op As Integer = 0
        Dim id_abogado As Integer = 0
        Dim Indices
        Indices = Split(id, ",", -1, 1)
        id_op = NumInt.Init(Indices(0))
        id_abogado = NumInt.Init(Indices(1))
        str &= "<table width='100%' border='0' cellpadding='0' cellspacing='0' class='dg_item_acciones' valign='top'  >"
        str &= "  <tr>"
        str &= "  	<td width=""100%"" onclick=""javascript:window.top.CloseWindowEspecial('FichaOperaciones');top.createWindow2('Ficha Operaciones','FichaOperaciones','juicios_web/operaciones/wf_op_operaciones_adm.aspx?id_op=" & id_op & "&id_abogado=" & id_abogado & "',800,600,'FichaOperaciones'); "">"
        str &= "        <font style='" & styleFont & "'>" & HttpUtility.HtmlEncode(Html.ToHtml(TextoMostrar))
        str &= "    </td>"
        str &= "    <td valign=""top"">"
        str &= "        <img name=""img_" & ItemIndex & """ src=""../../imagenes/comentarios.gif"" onclick=""javascript:window.top.CloseWindowEspecial('FichaOperaciones');top.createWindow2('Ficha Operaciones','FichaOperaciones','juicios_web/operaciones/wf_op_operaciones_adm.aspx?id_op=" & id_op & "&id_abogado=" & id_abogado & "',800,600,'FichaOperaciones');"" >"
        str &= "    </td>"
        str &= "  </tr>"
        str &= "</table>"
        Return str
    End Function
    Public Shared Function Array2String(ByVal arr As ArrayList) As String
        Try
            Dim cadena As String
            For i As Integer = 0 To arr.Count - 1
                cadena &= arr(i)
                If i <> arr.Count - 1 Then
                    cadena &= ","
                End If
            Next
            Return cadena
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
End Class

Public Class Conversor
    Public Shared Function ReaderADataset(ByVal Reader As SqlDataReader) As DataSet
        Dim ds As New DataSet
        ds.Tables.Add()
        Dim i As Integer, m As Integer
        For m = 0 To Reader.FieldCount - 1
            Dim col As New DataColumn(Reader.GetName(m), Reader.GetFieldType(m))
            ds.Tables(0).Columns.Add(col)
        Next
        Dim Drow As DataRow
        While Reader.Read
            Drow = ds.Tables(0).NewRow
            For i = 0 To Reader.FieldCount - 1
                If Reader(i) Is DBNull.Value Then
                    If Reader.GetFieldType(i) Is GetType(Int32) Or Reader.GetFieldType(i) Is GetType(Decimal) Then
                        Drow(i) = 0
                    ElseIf Reader.GetFieldType(i) Is GetType(Date) Then
                        Drow(i) = Reader(i)
                    Else
                        Drow(i) = ""
                    End If
                Else
                    Drow(i) = Reader(i)
                End If
            Next
            ds.Tables(0).Rows.Add(Drow)
        End While
        Return ds
    End Function
End Class

Public Class Html
    Public Shared Function ToHtml(ByVal txt As String) As String
        txt = Replace(txt, vbCrLf, "<br>")
        txt = Replace(txt, vbCr, "<br>")
        txt = Replace(txt, vbLf, "<br>")
        txt = Replace(txt, vbNewLine, "<br>")
        txt = Replace(txt, vbCr, "<br>")
        txt = Replace(txt, Chr(34), "")
        txt = Replace(txt, vbTab, " ")
        txt = Replace(txt, "'", "")
        Return txt
    End Function

    Public Overloads Shared Function ToString(ByVal txt As String) As String
        txt = Replace(txt, "<br>", "\n")
        Return txt
    End Function
End Class

Public Class Js
    Public Shared AbreScript As String = "<script language=javascript>" & vbCrLf
    Public Shared CierraScript As String = "</script>"

    Public Shared Function alert(ByVal msg As String) As String
        Dim f As String = AbreScript & "alert('" & Replace(Replace(Replace(Replace(msg, "'", ""), vbCrLf, "\n"), Chr(10), "\n"), Chr(13), "\n") & "');" & CierraScript
        Return f
    End Function

    Public Shared Function alertClose(ByVal msg As String) As String
        Dim f As String = AbreScript & "alert('" & Replace(Replace(Replace(Replace(msg, "'", ""), vbCrLf, "\n"), Chr(10), "\n"), Chr(13), "\n") & "');window.close();" & CierraScript
        Return f
    End Function

    Public Shared Function alertClose(ByVal msg As String, ByVal reload As Boolean) As String
        Dim f As String = AbreScript & "alert('" & Replace(Replace(Replace(Replace(msg, "'", ""), vbCrLf, "\n"), Chr(10), "\n"), Chr(13), "\n") & "');window.close();" & vbCrLf
        If reload Then
            f &= "window.opener.location.reload();" & vbCrLf
        End If
        f &= "window.opener.focus();" & CierraScript
        Return f
    End Function

    Public Shared Function VentanaCerrar() As String
        Dim f As String
        f = "<script language=javascript>" & vbCrLf
        f &= "try{window.opener.focus();}catch(e){}window.close();"
        f &= vbCrLf & "</script>"
        Return f
    End Function

    Public Shared Function VentanaCerrar(ByVal nombreVentana As String) As String
        Dim f As String
        f = "<script language=javascript>" & vbCrLf
        f &= "  window.parent.CloseWindow('" & nombreVentana & "');" & vbCrLf
        f &= "</script>"
        Return f
    End Function

    Public Shared Function OpenerRefresh() As String
        Dim f As String
        f = "<script language=javascript>" & vbCrLf
        f &= "try{window.opener.__doPostBack('refrescar','');window.close();}catch(e){if (e.description == null){alert(e.message)}else{alert(e.description)}};"
        'f &= "window.opener.document.location.reload(true);window.close();"
        f &= vbCrLf & "</script>"
        Return f
    End Function

    Public Shared Function VentanaCerrar(ByVal RetornoPadre As Boolean) As String
        Dim f As String
        f = "<script language=javascript>" & vbCrLf
        f &= "window.close();"
        If RetornoPadre = True Then
            f &= "window.opener.focus();"
        End If
        f &= vbCrLf & "</script>"
        Return (f)
    End Function

    Public Shared Function VentanaCerrar(ByVal RetornoPadre As Boolean, ByVal ReloadPadre As Boolean) As String
        Dim f As String
        f = "<script language=javascript>" & vbCrLf
        If ReloadPadre = True Then
            f &= "window.opener.location.reload();" & vbCrLf
        End If
        f &= "window.close();" & vbCrLf
        If RetornoPadre = True Then
            f &= "window.opener.focus();" & vbCrLf
        End If
        f &= vbCrLf & "</script>"
        Return (f)
    End Function

    Public Shared Function Submitear() As String

        Dim Str As String = Js.AbreScript
        Str &= "	function __Submitear(eventTarget, eventArgument) {" & vbCrLf
        Str &= "		var theform;" & vbCrLf
        Str &= "		if (window.navigator.appName.toLowerCase().indexOf(""microsoft"") > -1) {" & vbCrLf
        Str &= "			theform = document.Form1;" & vbCrLf
        Str &= "		}" & vbCrLf
        Str &= "		else {" & vbCrLf
        Str &= "			theform = document.forms[""Form1""];" & vbCrLf
        Str &= "		}" & vbCrLf
        Str &= "		theform.__EVENTO.value = eventTarget.split(""$"").join("":"");" & vbCrLf
        Str &= "		theform.__ARGUMENTO.value = eventArgument;" & vbCrLf
        Str &= "		theform.submit();" & vbCrLf
        Str &= "	}" & vbCrLf
        Str &= Js.CierraScript & vbCrLf
        Str &= "        <input type=""hidden"" name=""__EVENTO""> <input type=""hidden"" name=""__ARGUMENTO"">" & vbCrLf

        Return Str
    End Function

    Public Shared Function script(ByVal texto As String) As String
        Return Js.AbreScript + texto + Js.CierraScript
    End Function

    Public Shared Function open_window_center() As String
        Dim f As String = Js.AbreScript
        f &= "function open_window_center(win_win, win_name, win_atrib, win_ancho, win_alto){" & vbCrLf
        f &= "  var w_config = win_atrib; " & vbCrLf
        f &= "  var ancho = (screen.width - win_ancho) / 2;" & vbCrLf
        f &= "  var largo = (screen.height - win_alto) / 2;" & vbCrLf
        f &= "  if (win_atrib != ''){" & vbCrLf
        f &= "    w_config = w_config + ','" & vbCrLf
        f &= "  }" & vbCrLf
        f &= "  w_config = w_config + ""width="" + win_ancho + "",height="" + win_alto + "",left="" + ancho + "",top="" + largo" & vbCrLf
        f &= "  var w_var = window.open(win_win,win_name,w_config); " & vbCrLf
        f &= "  w_var.focus(); " & vbCrLf
        f &= "}" & vbCrLf
        f &= Js.CierraScript & vbCrLf
        Return f
    End Function

    Public Shared Function open_window_center(ByVal window As String, ByVal nomWindow As String, ByVal width As Integer, ByVal height As Integer) As String
        Dim f As String = Js.AbreScript
        f &= "  var myLeft = (screen.width - " & width & ") / 2;" & vbCrLf
        f &= "  var myTop = (screen.height - " & height & ") / 2;" & vbCrLf
        f &= "  window.open('" & window & "', '" & nomWindow & "', 'scrollbars=yes,resizable=yes,width=" & width & ",height=" & height & ",top='+myTop+',left='+myLeft)" & vbCrLf
        f &= Js.CierraScript
        Return f
    End Function

End Class



Public Class VS
    Public Shared Function ViewState(ByVal CampoBuscar As String, ByVal CadenaDatos As String) As String
        Dim hidden_datos_usuario As String = UCase(CadenaDatos)
        Dim indx_comienza As Short = InStr(hidden_datos_usuario, UCase(CampoBuscar))
        Dim indx_igual As Short = InStr(indx_comienza, hidden_datos_usuario, "=")
        Dim indx_termina As Short = InStr(indx_comienza, hidden_datos_usuario, "|")
        If indx_termina = 0 Then indx_termina = hidden_datos_usuario.Length + 1
        Dim len As Short = (indx_termina) - (indx_igual + 1)
        Dim Valor As String = Trim(Mid(hidden_datos_usuario, indx_igual + 1, len))
        Return Valor
    End Function

    Public Shared Function AccRetornaID(ByVal Constante As String) As String
        Return ConfigurationSettings.AppSettings(Constante)
    End Function

End Class

Public Class Token

    Public Shared Function ViewStateToken(ByVal Clave As String, ByVal _Token As String) As String
        Dim _Token_Decript = Decript(_Token)
        Dim strRetorno As String
        Select Case Clave
            Case "SessionID"
                strRetorno = Trim(Left(_Token_Decript, 48))
            Case "NomUsu"
                strRetorno = Trim(Mid(_Token_Decript, 49, 15))
            Case "Fecha"
                strRetorno = Trim(Mid(_Token_Decript, 64, 19))
            Case "Perfil"
                strRetorno = Trim(Mid(_Token_Decript, 83, 10))
            Case "Sistema"
                strRetorno = Trim(Mid(_Token_Decript, 93, 10))
            Case "IdUsuario"
                strRetorno = Trim(Mid(_Token_Decript, 103, 10))
            Case "SistemaHom"
                strRetorno = Trim(Mid(_Token_Decript, 113, 10))
        End Select
        Return strRetorno
    End Function

    Private Shared Function Decript(ByVal texto As String) As String
        'Dim sec As New Security
        'Return sec.psDecrypt(texto)
    End Function



End Class

#Region "   Predeterminacion de valores para atributos, tanto hacia la bd como desde la bd  "


Public Class Fechas
    Public Shared Function Db(ByVal fecha As DBNull) As Object
        Return DBNull.Value
    End Function

    ' devuelve la fecha en formato is 'AAAAMMDD hh:mm:ss'
    Public Shared Function Db(ByVal fecha As DateTime) As Object
        If fecha = "01-01-0001" Then
            Return DBNull.Value
        Else
            Return fecha
        End If
    End Function

    Public Shared Function Init(ByVal fecha As Date) As String
        Return IIf(fecha = "01-01-0001", "", fecha.ToShortDateString)
    End Function

    ' Inicializa la fecha 
    Public Shared Function Init(ByVal fecha As String) As Date
        If IsDate(fecha) Then
            Return CType(fecha, Date)
        Else
            Return Date.MinValue.ToString
        End If
        'Return IIf(fecha = "", Date.MinValue.ToString, fecha)
    End Function

    Public Shared Function InitDB(ByVal fecha As String) As Object
        Return IIf(fecha = "", DBNull.Value, fecha)
    End Function

    Public Shared Function InitDB(ByVal fecha As Date) As Object
        Return IIf(fecha = "01-01-0001", DBNull.Value, fecha)
    End Function

    ' Inicializa la fecha 
    Public Shared Function Init(ByVal fecha As Object) As Date
        Return IIf(fecha Is DBNull.Value, "01-01-0001", fecha)
    End Function

    ' Ultimo día del mes
    Public Shared Function UltimoDiaMes(ByVal mes As Short, ByVal ano As Short) As Date
        Dim fecha As Date
        fecha = CType("01-" & mes & "-" & ano, Date)
        fecha = fecha.AddMonths(1).AddDays(-1)
        Return fecha
    End Function

    ' Ultimo día del año
    Public Shared Function UltimoDiaAño(ByVal ano As Short) As Date
        Dim fecha As Date
        fecha = UltimoDiaMes(12, ano)
        Return fecha
    End Function

    Public Shared Function PrimerDiaAño(ByVal ano As Short) As Date
        Dim fecha As Date
        fecha = CType("01-01" & "-" & ano, Date)
        Return fecha
    End Function

    ' devuelve la fecha en formato is 'AAAAMMDD hh:mm:ss'
    Public Shared Function ISO(ByVal fecha As DateTime) As Object
        If fecha = "01-01-0001" Then
            Return DBNull.Value
        Else
            Return Year(fecha) & Right("0" & Month(fecha), 2) & Right("0" & Day(fecha), 2) & " " & Replace(fecha.ToShortTimeString, ".", "").ToUpper
        End If
    End Function
End Class

Public Class Horas
    ' devuelve la fecha en formato is 'AAAAMMDD hh:mm:ss'
    Public Shared Function Db(ByVal Hora As DateTime) As Object
        If Hora.ToShortTimeString = "0:00" Then
            Return DBNull.Value
        Else
            Return Hora
        End If
    End Function
    ' Inicializa la fecha 
    Public Shared Function Init(ByVal Hora As String) As Date
        Return IIf(Hora = "", "01-01-0001", Now.ToShortTimeString)
    End Function

End Class

Public Class Txt
    Public Shared Function Db(ByVal Texto As String) As Object
        If Texto Is Nothing Then
            Return DBNull.Value
        Else
            Return Texto
        End If
    End Function

    Public Shared Function Init(ByVal Texto As Object) As String
        Return IIf(Texto Is DBNull.Value, "", Texto)
    End Function

End Class

Public Class Logic
    Public Shared Function Init(ByVal Logic As Object) As Boolean
        Return IIf(Logic Is DBNull.Value, False, Logic)
    End Function

    Public Shared Function Init(ByVal Logic As EstadoRegistro) As Boolean
        Select Case Logic
            Case EstadoRegistro.ACT
                Return True
            Case EstadoRegistro.DES
                Return False
        End Select
    End Function

    Public Shared Function Init(ByVal Logic As Boolean) As EstadoRegistro
        If Logic = True Then
            Return EstadoRegistro.ACT
        Else
            Return EstadoRegistro.DES
        End If
    End Function

    Public Shared Function Init(ByVal Logic As Byte) As EstadoRegistro
        If Logic = 0 Then
            Return EstadoRegistro.ACT
        ElseIf Logic = 1 Then
            Return EstadoRegistro.DES
        ElseIf Logic = 2 Then
            Return EstadoRegistro.TODOS
        End If
    End Function

End Class
Public Class NumInt

    Public Shared Function Db(ByVal Numero As Integer) As Object
        If Numero = 0 Or Numero = Integer.MinValue Then
            Return DBNull.Value
        Else
            Return Numero
        End If
    End Function

    Public Shared Function Db(ByVal Numero As Object) As Object
        If Numero Is DBNull.Value Then
            Return DBNull.Value
        Else
            If Numero = 0 Or Numero = Integer.MinValue Then
                Return DBNull.Value
            Else
                Return Numero
            End If
        End If
    End Function

    Public Shared Function Init(ByVal Numero As String) As Integer
        Return IIf(IsNumeric(Numero) = False, 0, Numero)
    End Function

    Public Shared Function Init(ByVal Numero As Object) As Integer
        Return IIf(Numero Is DBNull.Value, 0, Numero)
    End Function

End Class

Public Class NumDec
    Public Shared Function Db(ByVal Numero As Decimal) As Object
        If Numero = 0 Or Numero = Decimal.MinValue Then
            Return DBNull.Value
        Else
            Return Numero
        End If
    End Function

    Public Shared Function Init(ByVal Numero As Object) As Decimal
        Return IIf(Numero Is DBNull.Value, 0, Numero)
    End Function

    ' funcion que redondea de acuerdo al criterio de la cantidad de decimales en el WEB Config
    Public Shared Function Redondear(ByVal Numero As Decimal) As Decimal
        Return Math.Round(Numero, CInt(ConfigurationSettings.AppSettings("CONFIG_DECIMALES")))
    End Function

    Public Shared Function Init(ByVal Numero As String) As Decimal
        Return IIf(IsNumeric(Numero) = False, 0, Numero)
    End Function

End Class

#End Region

#Region "   Manipulación de datos Numéricos para despliegue y almacenamiento    "

Public Class Numeros
    Public Shared Function quitaDecimalesCero(ByVal Num As Decimal) As Decimal
        If InStr(Num.ToString, ",") = 0 Then Return Num
        Dim i As Short
        For i = Num.ToString.Length To 1 Step -1
            If IsNumeric(Mid(Num.ToString, i, 1)) Then
                If Mid(Num.ToString, i, 1) > 0 Then
                    Return Mid(Num.ToString, 1, i)
                End If
            Else
                Return Mid(Num.ToString, 1, i - 1)
            End If
        Next
    End Function

    Public Shared Function quitaDecimalesCero_DB(ByVal Num As Decimal) As String
        Return Replace(CStr(quitaDecimalesCero(Num)), ",", ".")
    End Function

    Public Shared Function quitaDecimalesCero(ByVal Num As String) As String
        If (Num = 0) Then
            Return Num
        End If
        If Num.Length = 0 Then Return Num 'Or InStr(Num.ToString, ",") = 0 
        Dim i As Short
        For i = Num.ToString.Length To 1 Step -1
            If IsNumeric(Mid(Num.ToString, i, 1)) Then
                If Mid(Num.ToString, i, 1) > 0 Then
                    Return Mid(Num.ToString, 1, i)
                End If
            Else
                Return Mid(Num.ToString, 1, i - 1)
            End If
        Next
    End Function


    Public Shared Function QuitaPunteo(ByVal Num As String) As String
        'Return Replace(Replace(Num, ".", ""), "$", "")
        If Num.Length = 0 Then Return Num 'Or InStr(Num.ToString, ",") = 0 
        Dim acum As String
        Dim constante As String = "0123456789,"
        Dim i As Short
        For i = 1 To Num.ToString.Length
            If InStr(constante, Mid(Num.ToString, i, 1)) > 0 Then
                acum &= Mid(Num.ToString, i, 1)
            End If
        Next
        Return acum
    End Function

    Public Shared Function punteaCifra(ByVal Num As String) As String
        Dim Numero As String = quitaDecimalesCero(Num)
        If (Numero Is Nothing) Then
            Numero = Num
        End If
        Dim i As Short
        Dim deci As String = ""
        Dim resto As String = ""
        Dim numeroFormateado As String = ""
        If InStr(Numero, ",") > 0 Then
            deci = Mid(Numero, InStr(Numero, ","))
            resto = Mid(Numero, 1, InStr(Numero, ",") - 1)
        Else
            resto = Numero
        End If
        Dim pasos As Short = 1
        For i = resto.Length To 1 Step -1
            If (pasos Mod 3) = 0 Then
                numeroFormateado = "." & Mid(resto, i, 1) & numeroFormateado
            Else
                numeroFormateado = Mid(resto, i, 1) & numeroFormateado
            End If
            pasos += 1
        Next
        If Left(numeroFormateado, 1) = "." Then
            numeroFormateado = Mid(numeroFormateado, 2)
        End If
        If Left(numeroFormateado, 2) = "-." Then
            numeroFormateado = "-" & Mid(numeroFormateado, 3)
        End If
        Return numeroFormateado & deci
    End Function

End Class

#End Region

Public Class Validaciones
    Public Shared Function validacionRut(ByVal rutref As String) As Boolean
        Dim i As Integer
        Dim Ind As Integer
        Dim j As Integer
        Dim k As Integer
        Dim l As Integer
        Dim dv As String
        Dim rut As String
        'Función para dig_validar el Rut de una Persona
        j = 0
        dv = Right(Trim(rutref.ToUpper), 1)
        rut = Trim(Mid(rutref, 1, Trim(rutref.Length) - 1))
        rut = Right("00000000" & rut, 8)

        Ind = Len(rut) - 5

        For i = 1 To Len(rut)
            j = j + Val(Mid(rut, i, 1)) * Ind
            If Ind = 2 Then
                Ind = 7
            Else
                Ind = Ind - 1
            End If
        Next i

        k = 11 - (j - (11 * (Int(j / 11))))

        If dv = "K" Then
            l = 10
        ElseIf dv = "0" Then
            l = 11
        Else
            l = Val(dv)
        End If

        If l = k Then
            Return True
        Else
            Return False
        End If
    End Function

End Class



Public Class Utilitarios
    ' Clona y devuelve una tabla ordenada por el defaulview
    Shared Function ClonaOrdenamiento(ByVal dv As DataView) As DataTable
        Dim dtN As DataTable
        dtN = dv.Table.Clone

        Dim drow As DataRow

        For i As Integer = 0 To dv.Count - 1
            drow = dtN.NewRow
            For Each dc As DataColumn In dtN.Columns
                drow(dc.ColumnName) = dv(i).Row.Item(dc.ColumnName)
            Next
            dtN.Rows.Add(drow)
        Next

        Return dtN
    End Function

    Public Shared Function SpParameter(ByVal spName As String, ByVal connection As SqlConnection) As SqlParameter()

        If (connection Is Nothing) Then Throw New ArgumentNullException("connection")
        If (spName Is Nothing OrElse spName.Length = 0) Then Throw New ArgumentNullException("spName")
        Dim cmd As New SqlCommand(spName, connection)
        cmd.CommandType = CommandType.StoredProcedure
        Dim Parameters() As SqlParameter
        If connection.State <> ConnectionState.Open Then
            connection.Open()
        End If
        SqlCommandBuilder.DeriveParameters(cmd)
        connection.Close()
        cmd.Parameters.RemoveAt(0)
        Parameters = New SqlParameter(cmd.Parameters.Count - 1) {}
        cmd.Parameters.CopyTo(Parameters, 0)
        cmd = Nothing
        Return Parameters
    End Function


End Class
