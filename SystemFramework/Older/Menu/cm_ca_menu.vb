Imports System
Imports System.Data
Imports System.Runtime.Serialization

' remplazar 
' Administracion por el nombre del modulo correspondiente
' id_menu  por nombre del la llave principal
' ca_menu por el nombre de la tabla en la base de datos  Ej tg_bitacoras
' Administracion por el nombre logico de la tabla ej Bitacora

Namespace Fwp.SystemFramework.Menu

    Public Class cm_ca_menu

        Inherits SCDatos
        Public Const KEY As String = "id_menu"  ' corresponde al Id de la tabla que estamos creando
        Public Const TABLA As String = "ca_menu"  ' Corresponde al nombre de la tabla que respresenta esta estructura
        Public Const ESTRUCTURA As String = "EstructuraSQL_" + TABLA  ' esta propiedad se usa para almacenar el nombre del archivo con la estructura

        Public Const ID_MENU_COLUMNA As String = "id_menu"
        Public Const ID_MENUPADRE_COLUMNA As String = "id_menupadre"
        Public Const MEN_NOMBRE_COLUMNA As String = "men_nombre"
        Public Const MEN_URL_COLUMNA As String = "men_url"
        Public Const ID_TIPOVENTANA_COLUMNA As String = "id_tipoventana"
        Public Const ID_OPCION_COLUMNA As String = "id_opcion"
        Public Const ID_SISTEMA_COLUMNA As String = "id_sistema"
        Public Const MEN_OPCIONES_COLUMNA As String = "men_opciones"
        Public Const MEN_ANCHO_COLUMNA As String = "men_ancho"
        Public Const MEN_ALTO_COLUMNA As String = "men_alto"
        Public Const MEN_ORDEN_COLUMNA As String = "men_orden"
        Public Const MEN_ACTIVO_COLUMNA As String = "men_activo"
        Public Const MEN_NOMBREVENTANA_COLUMNA As String = "men_nombreventana"
        Public Const ID_PERFIL_COLUMNA As String = "id_perfil"


        Private _estable As DataTable

        Public Sub New()
            MyBase.New()
            Try
                ' llama a metodo en la Super Clase SCDATOS que crea tabla con los datos de la estructura
                BuildStructureTableSQL()
                ' crea la estructura de la tabla con los datos de la estructura sql
                MyBase.Tables.Add(MyBase.CreaEstructuraRegistros(TABLA, CType(_estable, cm_estructuraSQL)))
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        Public Sub BuildStructureTableSQL()
            _estable = New cm_estructuraSQL(TABLA)
            Try
                With _estable
                    .Rows.Add(CreaFilaEstructura(_estable, KEY, SqlDbType.Int, 0, "id_menu", False))
                    .Rows.Add(CreaFilaEstructura(_estable, ID_MENUPADRE_COLUMNA, SqlDbType.Int, 0, "id_menupadre", False))
                    .Rows.Add(CreaFilaEstructura(_estable, MEN_NOMBRE_COLUMNA, SqlDbType.VarChar, 50, "men_nombre", False))
                    .Rows.Add(CreaFilaEstructura(_estable, MEN_URL_COLUMNA, SqlDbType.VarChar, 1000, "men_url", False))
                    .Rows.Add(CreaFilaEstructura(_estable, ID_TIPOVENTANA_COLUMNA, SqlDbType.Int, 0, "id_tipoventana", False))
                    .Rows.Add(CreaFilaEstructura(_estable, ID_OPCION_COLUMNA, SqlDbType.Int, 0, "id_opcion", False))
                    .Rows.Add(CreaFilaEstructura(_estable, ID_SISTEMA_COLUMNA, SqlDbType.Int, 0, "id_sistema", False))
                    .Rows.Add(CreaFilaEstructura(_estable, MEN_OPCIONES_COLUMNA, SqlDbType.VarChar, 100, "men_opciones", False))
                    .Rows.Add(CreaFilaEstructura(_estable, MEN_ANCHO_COLUMNA, SqlDbType.Int, 0, "men_ancho", False))
                    .Rows.Add(CreaFilaEstructura(_estable, MEN_ALTO_COLUMNA, SqlDbType.Int, 0, "men_alto", False))
                    .Rows.Add(CreaFilaEstructura(_estable, MEN_ORDEN_COLUMNA, SqlDbType.Int, 0, "men_orden", False))
                    .Rows.Add(CreaFilaEstructura(_estable, MEN_ACTIVO_COLUMNA, SqlDbType.Bit, 0, "men_activo", False))
                    .Rows.Add(CreaFilaEstructura(_estable, MEN_NOMBREVENTANA_COLUMNA, SqlDbType.VarChar, 50, "men_nombreventana", False))
                    .Rows.Add(CreaFilaEstructura(_estable, ID_PERFIL_COLUMNA, SqlDbType.Int, 0, "id_perfil", False))
                End With
                Me.Tables.Add(_estable)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
    End Class
End Namespace




