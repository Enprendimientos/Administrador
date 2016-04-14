Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports System.Runtime.Serialization

' remplazar 
' Administracion por el nombre del modulo correspondiente
' id_personaAccesoDirecto  por nombre del la llave principal
' tg_personasAccesosDirectos por el nombre de la tabla en la base de datos  Ej tg_bitacoras
' Administracion por el nombre logico de la tabla ej Bitacora

Namespace Fwp.SystemFramework.Menu

    Public Class cm_tg_personasAccesosDirectos_no

        Inherits SCNominas ' Hereda de la super clase de nominas

        ' estos atributos deben estar en todas las definiciones ya que se usan para el manejo
        ' generico de los getdata
        Public Const KEY As String = "id_personaAccesoDirecto"  ' corresponde al Id de la tabla que estamos creando
        Public Const TABLA As String = "nomina_tg_personasAccesosDirectos"  ' Corresponde al nombre de la tabla que respresenta esta estructura
        '       Public Const ESTRUCTURA As String = "EstructuraSQL_" + TABLA  ' esta propiedad se usa para almacenar el nombre del archivo con la estructura



        'Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        '    MyBase.New(info, context)
        'End Sub

        Public Sub New(ByVal pn As ParametrosNomina)
            MyBase.New()
            MyBase.Pagina = pn.Pagina
            MyBase.Orden = pn.Orden
            MyBase.RegistrosPorPaginas = pn.RegistrosPorPaginas
            MyBase.ColumnaOrden = pn.ColumnaOrden
            MyBase.Filtros = pn.Filtros
            BuildStructureTableSQL()
            MyBase.ESTRUCTURA = Tables(0).TableName
        End Sub

        Public Sub BuildStructureTableSQL()
            'Dim ds As New cm_estructuraSQL(BITACORAS_TABLA)
            Dim esTable As DataTable = New cm_estructuraSQL(ESTRUCTURA)
            Dim drow As DataRow
            With esTable
                .Rows.Add(CreaFilaEstructura(esTable, "id_personaAccesoDirecto", SqlDbType.Int, 0))
                .Rows.Add(CreaFilaEstructura(esTable, "id_persona", SqlDbType.Int, 0))
                .Rows.Add(CreaFilaEstructura(esTable, "id_accesoDirecto", SqlDbType.Int, 0))

            End With
            MyBase.Tables.Add(esTable)
        End Sub

    End Class
End Namespace


