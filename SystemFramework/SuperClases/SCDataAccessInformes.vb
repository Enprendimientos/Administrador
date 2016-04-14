﻿Imports Fwp.common
Imports Fwp.common.SCCommonIdDescripcion
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection

Public Class SCDataAccessInformes(Of T)
    Inherits BaseSCDataAccess(Of T)

    ''' <summary>
    ''' Funcion de recuperacion generica de datos. Recupera por cualquier atributo del objeto Nomina
    ''' </summary>
    ''' <param name="objeto">El objeto especifico que contiene la información por la que recuperara</param>
    ''' <param name="StoreProcedureName">Nombre del procediento</param>
    ''' <param name="Transaccion">Transaccion asociada, se usa para recuperar la conexion.</param>
    ''' <returns>Retorna una nomina Nomina</returns>
    ''' <remarks>Envia solo los parametros que contengan informacion distinta a la por defecto del tipo de dato</remarks>
    Public Function ReadDataGeneric(ByVal objeto As T, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As IList(Of T)
        'ilist de resultado
        Dim IlistResult As New List(Of T)
        Dim comm As SqlCommand = Nothing
        Try
            ' inicializa el Commando
            comm = MyBase.CreateComman(objeto, StoreProcedureName, Transaccion, Global.BaseSCDataAccess(Of T).TipoCommand.Read)

            PFun.ParametrosConNombre(comm.Parameters)

            'llena ilist con resultado de la consulta
            Dim dr As SqlDataReader = comm.ExecuteReader
            While dr.Read
                Dim myObject As T = Activator.CreateInstance(Of T)()
                Dim propiedadesObj As System.Reflection.PropertyInfo() = myObject.GetType.GetProperties()
                For col As Integer = 0 To dr.FieldCount - 1
                    Dim propiedad As System.Reflection.PropertyInfo = myObject.GetType.GetProperty(dr.GetName(col))
                    If Not propiedad Is Nothing Then 'solo si la encuentra asigna el valor
                        'Si es NULL no asigna el valor
                        If Not dr(col) Is DBNull.Value Then
                            Select Case propiedad.PropertyType.Name
                                Case "EstadoRegistro"
                                    If Boolean.Parse(dr(col)) Then
                                        propiedad.SetValue(myObject, EstadoRegistro.ACT, Nothing)
                                    Else
                                        propiedad.SetValue(myObject, EstadoRegistro.DES, Nothing)
                                    End If
                                Case "SCCommonIdDescripcion"
                                    Dim vsccID As New SCCommonIdDescripcion
                                    vsccID.id = dr(MyBase.Description(objeto, propiedad.Name, TipoDescripcionCompuesto.NombreId))
                                    vsccID.descripcion = dr(MyBase.Description(objeto, propiedad.Name, TipoDescripcionCompuesto.NombreDescripcion))
                                    propiedad.SetValue(myObject, vsccID, Nothing)
                                Case "SCCommonFecha"
                                    Dim vsccF As New SCCommonFecha
                                    vsccF.Fecha = dr(MyBase.Description(objeto, propiedad.Name, TipoDescripcionCompuesto.NombreId))
                                    propiedad.SetValue(myObject, vsccF, Nothing)
                                Case Else
                                    propiedad.SetValue(myObject, dr(col), Nothing)
                            End Select
                        End If
                    End If
                Next
                IlistResult.Add(myObject)
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            'libera recursos
            If Not comm Is Nothing Then
                If Not comm.Connection Is Nothing And Transaccion.MyStates = FWPTransaction.States.Liberate Then
                    Transaccion.CloseConnection()
                    comm.Connection.Dispose()
                End If
                comm.Dispose()
            End If
        End Try
        ' retorna estructura llena
        Return IlistResult
    End Function

    Public Function ReadDataGeneric(ByVal SQLText As String, ByVal Transaccion As FWPTransaction) As Data.DataSet
        Dim comm As SqlCommand = Nothing
        Try
            comm = New SqlCommand(SQLText, Transaccion.MyConnection)
            comm.CommandType = CommandType.Text
            Dim ad As New SqlDataAdapter(comm)
            Dim ds As New DataSet
            ad.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            'libera recursos
            If Not comm Is Nothing Then
                If Not comm.Connection Is Nothing And Transaccion.MyStates = FWPTransaction.States.Liberate Then
                    Transaccion.CloseConnection()
                    comm.Connection.Dispose()
                End If
                comm.Dispose()
            End If
        End Try
    End Function

End Class
