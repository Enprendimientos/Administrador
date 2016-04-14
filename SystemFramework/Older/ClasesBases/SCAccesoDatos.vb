Option Strict Off
Imports System.Reflection
Imports System.Data.SqlClient
Imports Fwp.SystemFramework
Imports Fwp.Common
Imports System.ComponentModel

Public MustInherit Class SCAccesoDatos
    Inherits System.Web.UI.Page
    Protected _identity As Integer
    Protected _Trans As FWPTransaction
    Protected _TotalPaginas As Integer
    Protected _TotalRegistros As Integer

    Public strconn As String
    Public cons_user As String
    Public Const DefaultInteger As Integer = Integer.MinValue
    Public Const DefaultDecimal As Decimal = Decimal.MinValue
    Public Const DefaultShort As Short = Short.MinValue
    Public Const DefaultByte As Byte = 2

    Private DataAdapter As SqlDataAdapter
    Private _Transaccion As FWPTransaction

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

    ' funcion de recuperacion generica de datos, recibe 
    ' ObjDatos : estructura que viene llena con los datos para recuperar
    ' data: estructura del tipo del objeto a recuperar que se usa para llenar los datos recuperados
    ' StoreProcedureName: Nombre del procedimiento a ejecutar
    ' Transaccion : Transaccion asociada, se usa para recuperar la conexion.
    Protected Function GetDataGenerico(ByVal ObjDatos As Object, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As DataSet
        Dim dtEstructura As New DataTable
        Dim NombreESTRUCTURA As String = ObjDatos.ESTRUCTURA
        Dim NombreTabla As String = ObjDatos.TABLA
        dtEstructura = CType(ObjDatos.Tables(NombreESTRUCTURA), DataTable)
        DataAdapter = New SqlDataAdapter
        _Transaccion = Transaccion
        With DataAdapter
            Try
                ' inicializa el Commando

                Dim comm As New SqlCommand(StoreProcedureName, Transaccion.MyConnection)
                comm.CommandType = CommandType.StoredProcedure
                ' crea los parametros a partir de los datos en Objdatos
                With comm.Parameters
                    Dim Param As SqlParameter
                    For Each drow As DataRow In dtEstructura.Rows
                        Param = New SqlParameter("@" & CType(drow(1), String), CType(drow(2), SqlDbType), CType(drow(3), Integer))
                        Param.Value = ObjDatos.Tables(NombreTabla).Rows(0)(CType(drow(1), String))
                        .Add(Param)
                        If CType(drow(1), String) = ObjDatos.KEY AndAlso CInt(PFun.elimina_nulo(ObjDatos.Tables(NombreTabla).Rows(0)(CType(drow(1), String)), 0)) > 0 Then
                            Exit For
                        End If
                    Next
                End With
                PFun.ParametrosConNombre(comm.Parameters)

                'Dim strParam As String = PFun.Parametros(comm.Parameters)

                ' asigna el commando al datareader
                .SelectCommand = comm

                ' BOrra el registro inicial con los parametros de lectura para que quede la informacion consistente
                ObjDatos.tables(NombreTabla).rows.remove(ObjDatos.tables(NombreTabla).rows(0))

                ' llena la tabla con el resultado del commando, los datos estan a partir de la fila 1
                ' por que en la fila 0 quedan los filtros que se usaron para llamar al procedimiento
                ' de recuperacion
                comm.Transaction = _Transaccion.myTransaction
                .Fill(ObjDatos, NombreTabla)

                ' agrega columna para saber si el tipo de registro es leido de la base de datos, 
                ' por defecto son todos leidos menos el 0 que es donde vienen los filtros 
                '                ObjDatos.tables(NombreTabla).Columns.Add("FWP_tiporegistro", GetType(System.Int32), 1)
                ' debe marcar los registros que leyó como originales desde la base de datos para efectos de guardar los cambios
                '               ObjDatos.tables(NombreTabla).rows(0).item("FWP_tiporegistro") = 0

            Catch ex As Exception
                Throw New Exception(ex.Message)
                'Finally
                '    ' libera los recursos
                '    If Not .SelectCommand Is Nothing Then
                '        If Not .SelectCommand.Connection Is Nothing Then
                '            .SelectCommand.Connection.Dispose()
                '        End If
                '        .SelectCommand.Dispose()
                '    End If
                '    .Dispose()
            End Try
        End With

        ' retorna estructura llena
        Return ObjDatos

    End Function

    Protected Function DeleteGenerico(ByVal ObjDatos As Object, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As Boolean
        Dim rd As SqlDataReader
        _Transaccion = Transaccion
        Try
            Dim NombreTabla As String = ObjDatos.TABLA
            Dim NombreESTRUCTURA As String = ObjDatos.ESTRUCTURA
            Dim comm As New SqlCommand(StoreProcedureName, Transaccion.MyConnection)
            comm.CommandType = CommandType.StoredProcedure
            comm.Transaction = Transaccion.myTransaction

            Dim dtEstructura As DataTable = ObjDatos.Tables(NombreESTRUCTURA)
            Dim drow As DataRow = dtEstructura.Rows(0)
            Dim Param As New SqlParameter("@" & CType(drow(1), String), CType(drow(2), SqlDbType), CType(drow(3), Integer))
            Param.Value = ObjDatos.Tables(NombreTabla).Rows(0)(CType(drow(1), String))
            comm.Parameters.Add(Param)

            rd = comm.ExecuteReader
            If rd.Read Then
                If CInt(rd(0)) < 0 Then
                    Throw New Exception(CStr(rd(1)))
                Else
                    rd.Close()
                    'Para control de cambios
                    Dim cc As New ControlCambios(Transaccion)
                    cc.ControlDeCambiosDelete(ObjDatos)
                    '-----------------------------------
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return True
    End Function

    Protected Function InsertGenerico(ByVal ObjDatos As Object, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As Integer
        Dim rd As SqlDataReader
        _Transaccion = Transaccion
        Dim identity As Integer
        Try
            ' crea una tabla con la estructura de la tabla a insertar (1 fila por campo)
            Dim NombreESTRUCTURA As String = ObjDatos.ESTRUCTURA
            Dim NombreTabla As String = ObjDatos.TABLA
            Dim dtEstructura As DataTable = ObjDatos.Tables(NombreESTRUCTURA)
            Dim comm As SqlCommand
            comm = New SqlCommand(StoreProcedureName, Transaccion.MyConnection)
            comm.CommandType = CommandType.StoredProcedure
            comm.Transaction = Transaccion.myTransaction
            ' recorre cada fila para llamar al procedimiento de inserción
            For Each dr As DataRow In ObjDatos.Tables(NombreTabla).Rows
                ' borra los parametros de la llamada para que se llenen nuevamente con los del nuevo registro
                comm.Parameters.Clear()
                ' crear los parametros del StoreProcedure a partir de la estructura
                With comm.Parameters
                    Dim Param As SqlParameter
                    For Each drow As DataRow In dtEstructura.Rows
                        ' se salta el campo ID ya que en la insercion no lo necesitamos
                        If CType(drow(1), String) <> ObjDatos.KEY Then
                            Param = New SqlParameter("@" & CType(drow(1), String), CType(drow(2), SqlDbType), CType(drow(3), Integer))
                            Param.Value = dr(CType(drow(1), String))
                            .Add(Param)
                        End If
                    Next
                End With
                ' le asigna la transaccion al objeto command
                ' ejecuta el Procedimiento
                rd = comm.ExecuteReader
                rd.Read()

                ' Retorna el ID del último registro insertado
                ' si el campo 0 del registro resultado > 0 fue exitosa
                If CInt(rd(0)) >= 0 Then
                    identity = CInt(rd(0))
                    rd.Close()
                    'Para control de cambios
                    Dim cc As New ControlCambios(Transaccion)
                    cc.ControlDeCambiosInsert(ObjDatos, identity)
                    '-----------------------------------
                Else ' si no da error           
                    Throw New Exception(CStr(rd(1)))
                End If
            Next


        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            If Not rd.IsClosed Then
                rd.Close()
            End If
        End Try

        ' retorna el Identity del ultimo registro
        Return identity
    End Function



    ' actualizacion generica
    Protected Function UpdateGenerico(ByVal ObjDatos As Object, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As Integer
        'Para control de cambios
        Dim cc As New ControlCambios(Transaccion)
        cc.ControlDeCambiosAntesUpdate(ObjDatos)
        '----------------------------------------------------------
        Dim rd As SqlDataReader
        _Transaccion = Transaccion
        Dim identity As Integer
        Try
            Dim NombreTabla As String = ObjDatos.TABLA
            Dim NombreESTRUCTURA As String = ObjDatos.ESTRUCTURA
            Dim dtEstructura As DataTable = ObjDatos.Tables(NombreESTRUCTURA)
            Dim comm As New SqlCommand(StoreProcedureName, Transaccion.MyConnection)
            comm.CommandType = CommandType.StoredProcedure
            With comm.Parameters
                Dim Param As SqlParameter
                For Each drow As DataRow In dtEstructura.Rows
                    Param = New SqlParameter("@" & CType(drow(1), String), CType(drow(2), SqlDbType), CType(drow(3), Integer))
                    Param.Value = ObjDatos.Tables(NombreTabla).Rows(0)(CType(drow(1), String))
                    .Add(Param)
                Next
            End With
            PFun.ParametrosConNombre(comm.Parameters)
            comm.Transaction = Transaccion.myTransaction
            rd = comm.ExecuteReader
            rd.Read()
            If CInt(rd(0)) > -1 Then
                identity = CInt(ObjDatos.Tables(NombreTabla).Rows(0)(ObjDatos.KEY))
                rd.Close()
                'Para control de cambios
                cc.ControlDeCambiosUpdate()
                '----------------------------------------------------------
            Else
                Throw New Exception(CStr(rd(1)))
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            If Not rd.IsClosed Then
                rd.Close()
            End If
            'Dispose(True)
        End Try
        Return identity
    End Function

    Protected Function GetNominaGenerico(ByVal pn As SCNominas, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As DataSet
        DataAdapter = New SqlDataAdapter
        _Transaccion = Transaccion
        With DataAdapter
            Try
                Dim comm As SqlCommand = New SqlCommand(StoreProcedureName, Transaccion.MyConnection)
                comm.CommandType = CommandType.StoredProcedure
                With comm.Parameters
                    Dim param As SqlParameter
                    param = New SqlParameter
                    param.ParameterName = "@pagina"
                    param.Value = pn.Pagina
                    param.Direction = ParameterDirection.Input
                    .Add(param)
                    param = New SqlParameter
                    param.ParameterName = "@regpag"
                    param.Value = pn.RegistrosPorPaginas
                    param.Direction = ParameterDirection.Input
                    .Add(param)
                    param = New SqlParameter
                    param.ParameterName = "@criterioorden"
                    param.Value = pn.Orden
                    param.Direction = ParameterDirection.Input
                    .Add(param)
                    param = New SqlParameter
                    param.ParameterName = "@criterioname"
                    param.Value = pn.ColumnaOrden
                    param.Direction = ParameterDirection.Input
                    .Add(param)
                    For Each di As DictionaryEntry In pn.Filtros
                        Dim dt As cm_estructuraSQL = pn.Tables(0)
                        For Each dr As DataRow In dt.Rows
                            If LCase(dr(dt.NOMBRE_COLUMNA)) = LCase(di.Key) Then
                                Select Case dr(dt.TIPO_COLUMNA)
                                    ' tipo entero
                                Case SqlDbType.Int
                                        param = New SqlParameter(CStr("@" & CStr(di.Key)), SqlDbType.Int)
                                        param.Value = NumInt.Init(di.Value)

                                    Case SqlDbType.SmallDateTime ' tipo Fecha
                                        param = New SqlParameter(CStr("@" & CStr(di.Key)), SqlDbType.VarChar, 20)
                                        param.Value = Fechas.ISO(di.Value)

                                    Case SqlDbType.DateTime ' tipo Fecha completa
                                        param = New SqlParameter(CStr("@" & CStr(di.Key)), SqlDbType.VarChar, 20)
                                        param.Value = Fechas.ISO(di.Value)

                                    Case SqlDbType.VarChar ' Tipo varchar
                                        param = New SqlParameter(CStr("@" & CStr(di.Key)), SqlDbType.VarChar, dr(dt.LARGO_COLUMNA))
                                        param.Value = Txt.Db(di.Value)

                                    Case SqlDbType.Decimal ' Tipo Decimal
                                        param = New SqlParameter(CStr("@" & CStr(di.Key)), SqlDbType.Decimal)
                                        param.Value = NumDec.Init(di.Value)

                                    Case SqlDbType.Money ' Tipo Moneda
                                        param = New SqlParameter(CStr("@" & CStr(di.Key)), SqlDbType.Money)
                                        param.Value = NumDec.Init(di.Value)

                                    Case SqlDbType.Bit ' Tipo Bit
                                        param = New SqlParameter(CStr("@" & CStr(di.Key)), SqlDbType.Int)
                                        param.Value = NumInt.Init(di.Value)
                                        'Case SqlDbType
                                        '    param = New SqlParameter(CStr("@" & CStr(di.Key)), )
                                        '    param.Value = 
                                End Select
                            End If
                        Next
                        If Not comm.Parameters.Contains(param.ParameterName) Then
                            param.Direction = ParameterDirection.Input
                            .Add(param)
                        End If
                    Next
                    PFun.ParametrosConNombre(comm.Parameters)

                End With
                PFun.ParametrosConNombre(comm.Parameters)
                .SelectCommand = comm
                ' cuando hace el fill crea 2 tabla adicionales a la tabla de estructura existente
                ' por lo tanto en la tabla(1) queda el total de registros y registros por pagina
                ' y en la tabla(2) queda la tabla con la nomina de resultado propiamente tal
                .Fill(pn)

                'Dim ds As DataSet = pn
                'ds.Clear()

                'Dim dta As DataTable = ds.Tables(0)
                'Dim al As New ArrayList

                'For Each dc As DataColumn In dta.Columns
                '    If dc.DataType Is GetType(Boolean) Then
                '        dta.Columns(dc.ColumnName).DataType = GetType(String)
                '        al.Add(CStr(dc.ColumnName))
                '    End If
                'Next

                'Dim drow As DataRow
                'For Each dr As DataRow In pn.Tables(0).Rows
                '    For Each dc As DataColumn In pn.Tables(0).Columns
                '        drow = dta.NewRow
                '        If al.Contains(dc.ColumnName) Then
                '            If Logic.Init(dr(dc.ColumnName)) Then
                '                dr(dc.ColumnName) = "Si"
                '            Else
                '                dr(dc.ColumnName) = "No"
                '            End If
                '        End If
                '        drow(dc.ColumnName) = dr(dc.ColumnName)
                '        dta.Rows.Add(drow)
                '    Next
                'Next
                'pn = ds
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                If Not .SelectCommand Is Nothing Then
                    If Not .SelectCommand.Connection Is Nothing Then
                        .SelectCommand.Connection.Dispose()
                    End If
                    .SelectCommand.Dispose()
                End If
                .Dispose()
            End Try
        End With
        Return pn
    End Function


    'Public Sub Dispose() Implements System.IDisposable.Dispose
    '    Dispose(True)
    '    GC.SuppressFinalize(True)
    'End Sub

    'Protected Sub Dispose(ByVal disposing As Boolean)
    '    If (Not disposing) Then
    '        Exit Sub
    '    End If

    '    If Not DataAdapter Is Nothing Then
    '        If Not DataAdapter.SelectCommand Is Nothing Then
    '            If Not DataAdapter.SelectCommand.Connection Is Nothing Then
    '                DataAdapter.SelectCommand.Connection.Dispose()
    '            End If
    '            DataAdapter.SelectCommand.Dispose()
    '        End If
    '        DataAdapter.Dispose()
    '        DataAdapter = Nothing
    '    End If
    'End Sub



    Protected Sub InicializaClases(ByVal Objeto As Object)
        'Sub New(ByVal Objeto As Object)
        Dim t As Type = Objeto.GetType
        Dim flags As BindingFlags = BindingFlags.Instance _
                        Or BindingFlags.Public
        Dim cs As FieldInfo() = t.GetFields(flags)
        For Each m As FieldInfo In cs
            If m.FieldType Is GetType(Integer) Then
                m.SetValue(Objeto, DefaultInteger)
            ElseIf m.FieldType Is GetType(Decimal) Then
                m.SetValue(Objeto, DefaultDecimal)
            ElseIf m.FieldType Is GetType(Short) Then
                m.SetValue(Objeto, DefaultShort)
            ElseIf m.FieldType Is GetType(Byte) Then
                m.SetValue(Objeto, DefaultByte)
            End If
        Next
    End Sub

    Protected Sub RowToClass(ByVal fila As DataRow, ByVal Objeto As Object)
        Dim t As Type = Objeto.GetType
        Dim flags As BindingFlags = BindingFlags.Instance _
                        Or BindingFlags.Public
        Dim cs As FieldInfo() = t.GetFields(flags)
        For Each m As FieldInfo In cs
            Try
                m.SetValue(Objeto, fila(m.Name))
            Catch ex As Exception
            End Try
        Next
    End Sub

    Protected Sub DataReaderToClass(ByVal fila As System.Data.SqlClient.SqlDataReader, ByVal Objeto As Object)
        Dim t As Type = Objeto.GetType
        Dim flags As BindingFlags = BindingFlags.Instance _
                        Or BindingFlags.Public
        Dim cs As FieldInfo() = t.GetFields(flags)
        For Each m As FieldInfo In cs
            Try
                m.SetValue(Objeto, fila(m.Name))
            Catch ex As Exception
            End Try
        Next
    End Sub

    ' Function que pasa un data reader a una fila
    Protected Function DatareaderToRow(ByVal fila As System.Data.SqlClient.SqlDataReader, ByVal dt As DataTable) As DataRow
        Dim drow As DataRow
        drow = dt.NewRow
        Dim i As Integer
        For i = 0 To fila.FieldCount - 1
            Try
                drow(fila.GetName(i)) = fila(i)
            Catch ex As Exception
            End Try
        Next
        Return drow
    End Function

    ' Function que pasa un data reader a una hashtable
    Protected Function DatareaderTohashtable(ByVal fila As System.Data.SqlClient.SqlDataReader) As Hashtable
        Dim Arr As New Hashtable
        Dim i As Integer
        For i = 0 To fila.FieldCount - 1
            Try
                Arr(LCase(fila.GetName(i))) = fila(i)
            Catch ex As Exception
            End Try
        Next
        Return Arr
    End Function

    Protected MC_id_field As Integer
    Protected MC_RawUrl As String
    Protected MC_NombreTablaBase As String



    Protected Function EvaluaAsignacionValor(ByVal ht As Hashtable, ByVal CampArr As Hashtable)
        ''ht: Valores actuales en la bd
        ''CampArr: Valores enviados desde el usuario
        'Dim td As New TransportaDatos
        'td.Realizado = True
        'Dim de As DictionaryEntry
        'For Each de In CampArr 'CampArr: Valores enviados desde el usuario
        '    If Not ht.Item(de.Key) Is DBNull.Value Then
        '        If de.Value <> ht.Item(de.Key) AndAlso Not de.Value Is DBNull.Value AndAlso Not de.Value Is Nothing Then
        '            If de.Value.GetType Is GetType(String) Then
        '                If Not de.Value Is Nothing Then
        '                    ht.Item(de.Key) = de.Value
        '                    If de.Key <> "doc_texto" Then
        '                        td = SaveChange(MC_RawUrl, MC_id_field, MC_NombreTablaBase, de.Key, Strings.Left(de.Value.ToString, 500))
        '                    End If
        '                    If td.Realizado = False Then Exit For
        '                End If
        '            ElseIf de.Value.GetType Is GetType(Decimal) Then
        '                If de.Value <> DefaultDecimal Then
        '                    ht.Item(de.Key) = de.Value
        '                    td = SaveChange(MC_RawUrl, MC_id_field, MC_NombreTablaBase, de.Key, Strings.Left(de.Value.ToString, 500))
        '                    If td.Realizado = False Then Exit For
        '                End If
        '            ElseIf de.Value.GetType Is GetType(Integer) Then
        '                If de.Value <> DefaultInteger Then
        '                    ht.Item(de.Key) = de.Value
        '                    td = SaveChange(MC_RawUrl, MC_id_field, MC_NombreTablaBase, de.Key, Strings.Left(de.Value.ToString, 500))
        '                    If td.Realizado = False Then Exit For
        '                End If
        '            ElseIf de.Value.GetType Is GetType(Date) Then
        '                If de.Value <> CDate("01-01-0001") Then
        '                    ht.Item(de.Key) = de.Value
        '                    td = SaveChange(MC_RawUrl, MC_id_field, MC_NombreTablaBase, de.Key, Strings.Left(de.Value.ToString, 500))
        '                    If td.Realizado = False Then Exit For
        '                End If
        '            ElseIf de.Value.GetType Is GetType(Boolean) Then
        '                ht.Item(de.Key) = de.Value
        '                td = SaveChange(MC_RawUrl, MC_id_field, MC_NombreTablaBase, de.Key, Strings.Left(de.Value.ToString, 500))
        '                If td.Realizado = False Then Exit For
        '            ElseIf de.Value.GetType Is GetType(Byte) Then
        '                'Reevaluo sabiendo que es byte
        '                If CType(de.Value, Boolean) <> ht.Item(de.Key) Then
        '                    ht.Item(de.Key) = de.Value
        '                    td = SaveChange(MC_RawUrl, MC_id_field, MC_NombreTablaBase, de.Key, Strings.Left(de.Value.ToString, 500))
        '                    If td.Realizado = False Then Exit For
        '                End If
        '            End If
        '        End If
        '    Else
        '        If Not de.Value Is Nothing Then
        '            If de.Value.GetType Is GetType(String) Then
        '                If Not de.Value Is Nothing Then
        '                    ht.Item(de.Key) = de.Value
        '                End If
        '            ElseIf de.Value.GetType Is GetType(Decimal) Then
        '                If de.Value <> DefaultDecimal Then
        '                    ht.Item(de.Key) = de.Value
        '                End If
        '            ElseIf de.Value.GetType Is GetType(Integer) Then
        '                If de.Value <> DefaultInteger Then
        '                    ht.Item(de.Key) = de.Value
        '                End If
        '            ElseIf de.Value.GetType Is GetType(Date) Then
        '                If de.Value <> CDate("01-01-0001") Then
        '                    ht.Item(de.Key) = de.Value
        '                End If
        '            ElseIf de.Value.GetType Is GetType(Boolean) Then
        '                ht.Item(de.Key) = de.Value
        '            ElseIf de.Value.GetType Is GetType(Byte) Then
        '                ht.Item(de.Key) = de.Value
        '            End If
        '        End If
        '    End If
        'Next
        'td.Objeto = ht
        'Return td
    End Function

    Public Enum Orden
        ASC = 0
        DESC = 1
    End Enum

    Public Class Criterios
        Public Old As Integer
        Public Nombre As String
        Public Orden As Orden
    End Class

    Private _CriterioOrden As New Criterios

    Public Property CriterioOrden() As Criterios
        Get
            Return _CriterioOrden
        End Get
        Set(ByVal Value As Criterios)
            _CriterioOrden = Value
        End Set
    End Property
End Class


