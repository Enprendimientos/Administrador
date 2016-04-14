Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports System.Runtime.Serialization

<System.ComponentModel.DesignerCategory("Code"), SerializableAttribute()> _
Public Class cm_estructuraSQL
    Inherits DataTable

    Private ESTRUCTURASQL_TABLA As String
    Public Const ID_COLUMNA As String = "id_columna"
    Public Const NOMBRE_COLUMNA As String = "nombreColumna"
    Public Const TIPO_COLUMNA As String = "tipoColumna"
    Public Const LARGO_COLUMNA As String = "largoColumna"
    Public Const DESCRIPCION_COLUMNA As String = "descripcionColumna"
    Public Const DIRECCION_COLUMNA As String = "DireccionParametros"
    Public Const SOPORTANULL_COLUMNA As String = "SoportaNulos"

    Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New(info, context)
    End Sub

    Public Sub New(ByVal NombreDataTable As String)
        MyBase.New()
        ESTRUCTURASQL_TABLA = "EstructuraSQL_" & NombreDataTable
        BuildDataTables()
    End Sub

    Private Sub BuildDataTables()
        Me.TableName = ESTRUCTURASQL_TABLA
        'Dim table As DataTable = New DataTable(ESTRUCTURASQL_TABLA)
        With Me.Columns
            With .Add(ID_COLUMNA, GetType(System.Int32))
                .AllowDBNull = False
                .AutoIncrement = True
            End With
            .Add(NOMBRE_COLUMNA, GetType(System.String))
            .Add(TIPO_COLUMNA, GetType(Data.SqlDbType))
            .Add(LARGO_COLUMNA, GetType(System.Int32))
            .Add(DIRECCION_COLUMNA, GetType(Data.ParameterDirection))
            .Add(DESCRIPCION_COLUMNA, GetType(System.String))
            .Add(SOPORTANULL_COLUMNA, GetType(System.Boolean))
        End With
    End Sub

End Class
