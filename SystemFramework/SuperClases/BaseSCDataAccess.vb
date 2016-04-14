Imports Fwp.common
Imports Fwp.common.SCCommonIdDescripcion
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection

Public Class BaseSCDataAccess(Of T)
    Private _Trans As FWPTransaction
    Private _TotalPaginas As Integer
    Private _TotalRegistros As Integer



    Protected Function ConvertSqlDbType(ByVal Type As String) As SqlDbType
        Select Case Type.ToLower
            Case "SqlDbType.Bit".ToLower
                Return SqlDbType.Bit
            Case "SqlDbType.DateTime".ToLower
                Return SqlDbType.DateTime
            Case "SqlDbType.Decimal".ToLower
                Return SqlDbType.Decimal
            Case "SqlDbType.Int".ToLower
                Return SqlDbType.Int
            Case "SqlDbType.Money".ToLower
                Return SqlDbType.Money
            Case "SqlDbType.SmallDateTime".ToLower
                Return SqlDbType.SmallDateTime
            Case "SqlDbType.VarChar".ToLower
                Return SqlDbType.VarChar
            Case "SqlDbType.Char".ToLower
                Return SqlDbType.Char
            Case "SqlDbType.NVarChar".ToLower
                Return SqlDbType.NVarChar
            Case "SqlDbType.numeric".ToLower
                Return SqlDbType.Decimal
            Case "SqlDbType.image".ToLower
                Return SqlDbType.Image
        End Select
    End Function

    Protected Function IsSqlDbTypeNumeric(ByVal Type As String) As Boolean
        Select Case Type
            Case "SqlDbType.Bit"
                Return False
            Case "SqlDbType.DateTime"
                Return False
            Case "SqlDbType.Decimal"
                Return True
            Case "SqlDbType.Int"
                Return True
            Case "SqlDbType.Money"
                Return True
            Case "SqlDbType.SmallDateTime"
                Return False
            Case "SqlDbType.VarChar"
                Return False
            Case "SqlDbType.Char"
                Return False
            Case "SqlDbType.NVarChar"
                Return False
            Case "SqlDbType.image"
                Return False
        End Select
    End Function

    Protected Property Trans() As FWPTransaction
        Get
            Return _Trans
        End Get
        Set(ByVal value As FWPTransaction)
            _Trans = value
        End Set
    End Property

    'Protected Property Totalpaginas() As Integer
    '    Get
    '        Return _TotalPaginas
    '    End Get
    '    Set(ByVal value As Integer)
    '        _TotalPaginas = value
    '    End Set
    'End Property

    'Protected Property Totalregistros() As Integer
    '    Get
    '        Return _TotalRegistros
    '    End Get
    '    Set(ByVal value As Integer)
    '        _TotalRegistros = value
    '    End Set
    'End Property

    Protected Function Description(ByVal objeto As T, ByVal Propiedad As String) As String
        Dim resul As String = ""
        Dim prop As PropertyDescriptorCollection = TypeDescriptor.GetProperties(objeto)
        Dim pd As PropertyDescriptor = prop.Find(Propiedad, True)
        Dim listDesc As IList(Of String) = Split(pd.Description, ",")
        For index As Integer = 0 To listDesc.Count - 1
            Dim listResul As IList(Of String) = Split(listDesc(index), "=")
            If (listResul(0) = Propiedad) Then
                resul = listResul(1)
                Exit For
            End If
        Next
        Return resul
    End Function

    Protected Function Description(ByVal objeto As T, ByVal Propiedad As String, ByVal index As Integer) As String
        Dim prop As PropertyDescriptorCollection = TypeDescriptor.GetProperties(objeto)
        Dim pd As PropertyDescriptor = prop.Find(Propiedad, True)
        Dim listDesc As IList(Of String) = Split(pd.Description, ",")
        Dim listResul As IList(Of String) = Split(listDesc(index), "=")
        Return Trim(listResul(1))
    End Function

    Protected Function EvaluaValorPorDefecto(ByVal objeto As T, ByVal Propiedad As System.Reflection.PropertyInfo) As Boolean
        Dim Bool As Boolean = False
        Select Case Propiedad.PropertyType.Name
            Case TypeCode.Int32.ToString
                If DirectCast(Propiedad.GetValue(objeto, Nothing), Int32) = 0 Then
                    Bool = True
                End If
            Case TypeCode.Decimal.ToString
                If DirectCast(Propiedad.GetValue(objeto, Nothing), Decimal) = 0 Then
                    Bool = True
                End If
            Case TypeCode.Double.ToString
                If DirectCast(Propiedad.GetValue(objeto, Nothing), Double) = 0 Then
                    Bool = True
                End If
            Case TypeCode.String.ToString
                Dim valor As String = DirectCast(Propiedad.GetValue(objeto, Nothing), String)
                If valor = String.Empty Then
                    Bool = True
                End If
        End Select
        Return Bool
    End Function

    Protected Enum TipoCommand
        Read = 0
        Insert = 1
        Update = 2
        Delete = 3
    End Enum


    Protected Function CreateComman(ByVal objeto As T, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction, ByVal Tipo As TipoCommand) As SqlCommand
        Dim comm As SqlCommand
        Try
            'comm = New SqlCommand(StoreProcedureName, Transaccion.MyConnection)
            If (Transaccion.myTransaction Is Nothing) Then
                comm = New SqlCommand(StoreProcedureName, Transaccion.MyConnection)
            Else
                comm = New SqlCommand(StoreProcedureName, Transaccion.MyConnection, Transaccion.myTransaction)
            End If
            comm.CommandType = CommandType.StoredProcedure
            ' crea los parametros a partir de los datos en la estructura
            With comm.Parameters
                Dim Param As SqlParameter
                Dim propiedadesObj As System.Reflection.PropertyInfo() = objeto.GetType.GetProperties()
                For i As Integer = 0 To propiedadesObj.Length - 1
                    Dim propiedad As System.Reflection.PropertyInfo = objeto.GetType.GetProperty(propiedadesObj(i).Name)
                    Dim atts As Object() = propiedad.GetCustomAttributes(GetType(CategoryAttribute), False)
                    If atts.Length > 0 Then
                        Select Case DirectCast(atts(0), CategoryAttribute).Category
                            Case "Identity"
                                'Recupera solo por el id, si es <> 0
                                If IsNumeric(propiedad.GetValue(objeto, Nothing)) Then
                                    If propiedad.GetValue(objeto, Nothing) > 0 Then
                                        Param = New SqlParameter("@" & propiedadesObj(i).Name, ConvertSqlDbType(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.SqlDbType)), Integer.Parse(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.Size)))
                                        Param.Value = propiedad.GetValue(objeto, Nothing)
                                        .Add(Param)
                                        If Tipo = BaseSCDataAccess(Of T).TipoCommand.Read Or Tipo = BaseSCDataAccess(Of T).TipoCommand.Delete Then
                                            Exit For
                                        End If
                                    End If
                                Else
                                    If propiedad.GetValue(objeto, Nothing) <> "" Then
                                        Param = New SqlParameter("@" & propiedadesObj(i).Name, ConvertSqlDbType(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.SqlDbType)), Integer.Parse(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.Size)))
                                        Param.Value = propiedad.GetValue(objeto, Nothing)
                                        .Add(Param)
                                        If Tipo = BaseSCDataAccess(Of T).TipoCommand.Read Or Tipo = BaseSCDataAccess(Of T).TipoCommand.Delete Then
                                            Exit For
                                        End If
                                    End If
                                End If

                            Case "DataColumn"
                                Select Case propiedad.PropertyType.Name
                                    Case "EstadoRegistro"
                                        'Si es booleano lo maneja como entero para para poder considerar "TODOS"
                                        If Integer.Parse(propiedad.GetValue(objeto, Nothing)) <> Integer.Parse(EstadoRegistro.TODOS) Then
                                            Param = New SqlParameter("@" & propiedadesObj(i).Name, SqlDbType.Int, 0)
                                            Param.Value = Integer.Parse(propiedad.GetValue(objeto, Nothing))
                                            .Add(Param)
                                        End If
                                    Case "SCCommonIdDescripcion"
                                        Dim vsccID As SCCommonIdDescripcion = DirectCast(propiedad.GetValue(objeto, Nothing), SCCommonIdDescripcion)
                                        If vsccID.id > 0 Then
                                            'Manda el id del tipo SCCommonIdDescripcion
                                            Param = New SqlParameter("@" & Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.NombreId), ConvertSqlDbType(Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.SqlDbType)), Integer.Parse(Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.Size)))
                                            Param.Value = vsccID.id
                                            .Add(Param)
                                        Else
                                            If vsccID.descripcion <> String.Empty Then
                                                'Manda la descripcion del tipo SCCommonIdDescripcion
                                                Param = New SqlParameter("@" & Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.NombreDescripcion), ConvertSqlDbType(Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.NDSqlDbType)), Integer.Parse(Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.NDSize)))
                                                Param.Value = vsccID.descripcion
                                                .Add(Param)
                                            End If
                                        End If
                                    Case "SCCommonFecha"
                                        Dim vsccF As SCCommonFecha = DirectCast(propiedad.GetValue(objeto, Nothing), SCCommonFecha)
                                        If vsccF.FechaDesde <> Date.MinValue Then
                                            'Manda fechadesde de SCCommonFecha
                                            Param = New SqlParameter("@" & propiedadesObj(i).Name, SqlDbType.SmallDateTime)
                                            Param.Value = vsccF.FechaDesde
                                            .Add(Param)
                                        End If
                                        If vsccF.FechaHasta <> Date.MinValue Then
                                            'Manda fechahasta de SCCommonFecha
                                            'Param = New SqlParameter("@" & propiedadesObj(i).Name, ConvertSqlDbType(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.SqlDbType)), Integer.Parse(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.SqlDbType)))
                                            Param = New SqlParameter("@" & propiedadesObj(i).Name & "_hasta", SqlDbType.SmallDateTime)
                                            Param.Value = vsccF.FechaHasta
                                            .Add(Param)
                                        End If
                                    Case Else
                                        'recupera por cualquier columna
                                        If Not EvaluaValorPorDefecto(objeto, propiedad) Then
                                            If propiedadesObj(i).Name <> "ForceUpdate" Then
                                                Param = New SqlParameter("@" & propiedadesObj(i).Name, ConvertSqlDbType(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.SqlDbType)), Integer.Parse(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.Size)))
                                                Param.Value = propiedad.GetValue(objeto, Nothing)
                                                .Add(Param)
                                            Else
                                                If Right(StoreProcedureName, 3) = "_ac" Then
                                                    Param = New SqlParameter("@" & propiedadesObj(i).Name, ConvertSqlDbType(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.SqlDbType)), Integer.Parse(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.Size)))
                                                    Param.Value = propiedad.GetValue(objeto, Nothing).ToString
                                                    .Add(Param)
                                                End If
                                            End If
                                        End If
                                End Select
                        End Select
                    End If
                Next
            End With
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return comm
    End Function

    Protected Function CreateWhere(ByVal objeto As T) As String
        Dim StrWhere As String = ""
        Dim propiedadesObj As System.Reflection.PropertyInfo() = objeto.GetType.GetProperties()
        For i As Integer = 0 To propiedadesObj.Length - 1
            Dim propiedad As System.Reflection.PropertyInfo = objeto.GetType.GetProperty(propiedadesObj(i).Name)
            Dim atts As Object() = propiedad.GetCustomAttributes(GetType(CategoryAttribute), False)
            If atts.Length > 0 Then
                Select Case DirectCast(atts(0), CategoryAttribute).Category
                    Case "Identity"
                        'Existen Metodos especificos para recuperaciones y actualizaciones por ID
                    Case "DataColumn"
                        Select Case propiedad.PropertyType.Name
                            Case "EstadoRegistro"
                                'Si es booleano lo maneja como entero para para poder considerar "TODOS"
                                If Integer.Parse(propiedad.GetValue(objeto, Nothing)) <> Integer.Parse(EstadoRegistro.TODOS) Then
                                    If StrWhere <> "" Then StrWhere = " AND "
                                    StrWhere = propiedadesObj(i).Name & " = " & Integer.Parse(propiedad.GetValue(objeto, Nothing)).ToString
                                End If
                            Case "SCCommonIdDescripcion"
                                Dim vsccID As SCCommonIdDescripcion = DirectCast(propiedad.GetValue(objeto, Nothing), SCCommonIdDescripcion)
                                If vsccID.id <> 0 Then
                                    If StrWhere <> "" Then StrWhere = " AND "
                                    StrWhere = Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.NombreId) & " = " & vsccID.id.ToString
                                Else
                                    If vsccID.descripcion <> String.Empty Then
                                        If StrWhere <> "" Then StrWhere = " AND "
                                        StrWhere = Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.NombreDescripcion) & " = '%" & vsccID.descripcion & "%'"
                                    End If
                                End If
                            Case "SCCommonFecha"
                                Dim vsccF As SCCommonFecha = DirectCast(propiedad.GetValue(objeto, Nothing), SCCommonFecha)
                                If vsccF.FechaDesde <> Date.MinValue Then
                                    If StrWhere <> "" Then StrWhere = " AND "
                                    StrWhere = Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.NombreId) & " = '" & vsccF.FechaDesde.ToShortDateString & "'"
                                End If
                                If vsccF.FechaHasta <> Date.MinValue Then
                                    If StrWhere <> "" Then StrWhere = " AND "
                                    StrWhere = Description(objeto, propiedadesObj(i).Name, TipoDescripcionCompuesto.NombreDescripcion) & " = '" & vsccF.FechaDesde.ToShortDateString & "'"
                                End If
                            Case Else
                                'recupera por cualquier columna
                                If Not EvaluaValorPorDefecto(objeto, propiedad) Then
                                    If IsSqlDbTypeNumeric(Description(objeto, propiedadesObj(i).Name, TipoDescripcion.SqlDbType)) Then
                                        If StrWhere <> "" Then StrWhere = " AND "
                                        StrWhere = propiedadesObj(i).Name & " = " & propiedad.GetValue(objeto, Nothing).ToString
                                    Else
                                        If StrWhere <> "" Then StrWhere = " AND "
                                        StrWhere = propiedadesObj(i).Name & " = '" & propiedad.GetValue(objeto, Nothing).ToString & "'"
                                    End If
                                End If
                        End Select
                End Select
            End If
        Next
        Return StrWhere
    End Function

End Class
