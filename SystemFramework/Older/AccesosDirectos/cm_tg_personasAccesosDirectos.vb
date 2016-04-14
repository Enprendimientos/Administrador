Imports System
Imports System.Data
Imports System.Runtime.Serialization

' remplazar 
' Administracion por el nombre del modulo correspondiente
' id_personaAccesoDirecto  por nombre del la llave principal
' tg_personasAccesosDirectos por el nombre de la tabla en la base de datos  Ej tg_bitacoras
' Administracion por el nombre logico de la tabla ej Bitacora

Namespace Fwp.SystemFramework.Menu
    Public Class cm_tg_personasAccesosDirectos
        Inherits SCDatos
        Public Const KEY As String = "id_personaAccesoDirecto"  ' corresponde al Id de la tabla que estamos creando
        Public Const TABLA As String = "tg_personasAccesosDirectos"  ' Corresponde al nombre de la tabla que respresenta esta estructura
        Public Const ESTRUCTURA As String = "EstructuraSQL_" + TABLA  ' esta propiedad se usa para almacenar el nombre del archivo con la estructura

        Public Const ID_PERSONAACCESODIRECTO_COLUMNA As String = "id_personaAccesoDirecto"
        Public Const ID_PERSONA_COLUMNA As String = "id_persona"
        Public Const ID_ACCESODIRECTO_COLUMNA As String = "id_accesoDirecto"

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
                    .Rows.Add(CreaFilaEstructura(_estable, KEY, SqlDbType.Int, 0, "id_personaAccesoDirecto", False))
                    .Rows.Add(CreaFilaEstructura(_estable, ID_PERSONA_COLUMNA, SqlDbType.Int, 0, "id_persona", False))
                    .Rows.Add(CreaFilaEstructura(_estable, ID_ACCESODIRECTO_COLUMNA, SqlDbType.Int, 0, "id_accesoDirecto", False))
                End With
                Me.Tables.Add(_estable)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
    End Class
End Namespace




