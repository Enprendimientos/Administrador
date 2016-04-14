Imports Fwp.common
Imports Fwp.common.SCCommonIdDescripcion
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection

Public Class SCDataAccess(Of T)
    Inherits BaseSCDataAccess(Of T)

    ''' <summary>
    ''' funcion de recuperacion generica de datos. Recupera por el PK del objeto
    ''' </summary>
    ''' <param name="id">Valor del PK del objeto</param>
    ''' <param name="StoreProcedureName">Nombre del procediento</param>
    ''' <param name="Transaccion">Transaccion asociada, se usa para recuperar la conexion.</param>
    ''' <returns>Objeto con la coincidencia encontrada</returns>
    ''' <remarks></remarks>
    Protected Function ReadDataGeneric(Of T1)(ByVal id As T1, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As T
        Try
            Dim objeto As T = Activator.CreateInstance(Of T)()
            Dim propiedad As System.Reflection.PropertyInfo = objeto.GetType.GetProperty("id")
            propiedad.SetValue(objeto, id, Nothing)
            Dim IlistResult As IList(Of T) = ReadDataGeneric(objeto, StoreProcedureName, Transaccion)
            If IlistResult.Count > 0 Then
                objeto = IlistResult(0)
            Else
                objeto = Nothing
            End If
            Return objeto
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' Funcion de recuperacion generica de datos. Recupera por cualquier atributo del objeto
    ''' </summary>
    ''' <param name="objeto">El objeto especifico que contiene la información por la que recuperara</param>
    ''' <param name="StoreProcedureName">Nombre del procediento</param>
    ''' <param name="Transaccion">Transaccion asociada, se usa para recuperar la conexion.</param>
    ''' <returns>Lista de objetos con las coincidencias encontradas</returns>
    ''' <remarks>Envia solo los parametros que contengan informacion distinta a la por defecto del tipo de dato</remarks>
  Protected Function ReadDataGeneric(ByVal objeto As T, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As IList(Of T)
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
                  vsccID.descripcion = Txt.Init(dr(MyBase.Description(objeto, propiedad.Name, TipoDescripcionCompuesto.NombreDescripcion)))
                  propiedad.SetValue(myObject, vsccID, Nothing)
                Case "SCCommonFecha"
                  Dim vsccF As New SCCommonFecha
                  vsccF.Fecha = dr(propiedad.Name)
                  propiedad.SetValue(myObject, vsccF, Nothing)
                Case Else
                  If (dr(col).GetType.Name.ToLower = "byte[]") Then
                    propiedad.SetValue(myObject, CType(dr(col), Byte()), Nothing)
                  Else
                    propiedad.SetValue(myObject, dr(col), Nothing)
                  End If

              End Select
            End If
          End If
        Next
        IlistResult.Add(myObject)
      End While
      dr.Close()
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


    Protected Function CreateDataGeneric(ByVal objeto As T, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As T
        ' inicializa el Commando
        Dim comm As SqlCommand = Nothing
        Try
            comm = MyBase.CreateComman(objeto, StoreProcedureName, Transaccion, Global.BaseSCDataAccess(Of T).TipoCommand.Insert)

      PFun.ParametrosConNombre(comm.Parameters)

            Dim SCOPE_IDENTITY As SqlParameter = New SqlParameter("@SCOPE_IDENTITY", SqlDbType.Int)
            SCOPE_IDENTITY.Direction = ParameterDirection.ReturnValue
            comm.Parameters.Add(SCOPE_IDENTITY)



            comm.ExecuteNonQuery()
            Dim propiedad As System.Reflection.PropertyInfo = objeto.GetType.GetProperty("id")
            propiedad.SetValue(objeto, Integer.Parse(SCOPE_IDENTITY.Value), Nothing)

        Catch sqlex As SqlException
            Throw New Exception(sqlex.Message)
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
        Return objeto
    End Function

    Protected Function CreateDataGeneric(ByVal objeto As IList(Of T), ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As List(Of T)
        Dim IlistResult As New List(Of T)
        Try
            For Each it As T In objeto
                IlistResult.Add(CreateDataGeneric(it, StoreProcedureName, Transaccion))
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return IlistResult
    End Function

    Protected Sub UpdateDataGeneric(ByVal objeto As T, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction)
        ' inicializa el Commando
        Dim comm As SqlCommand = Nothing
        Try
            comm = MyBase.CreateComman(objeto, StoreProcedureName, Transaccion, Global.BaseSCDataAccess(Of T).TipoCommand.Update)
            PFun.ParametrosConNombre(comm.Parameters)
            comm.ExecuteNonQuery()
        Catch sqlex As SqlException
            Throw New Exception(sqlex.Message)
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
    End Sub

    Protected Sub UpdateDataGeneric(ByVal objeto As IList(Of T), ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction)
        Try
            For Each it As T In objeto
                UpdateDataGeneric(it, StoreProcedureName, Transaccion)
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub DeleteDataGeneric(ByVal id As Integer, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction)
        Dim comm As SqlCommand = Nothing
        Try
            Dim objeto As T = Activator.CreateInstance(Of T)()
            Dim propiedad As System.Reflection.PropertyInfo = objeto.GetType.GetProperty("id")
            propiedad.SetValue(objeto, id, Nothing)
            ' inicializa el Commando
            comm = MyBase.CreateComman(objeto, StoreProcedureName, Transaccion, Global.BaseSCDataAccess(Of T).TipoCommand.Delete)
            comm.ExecuteNonQuery()
        Catch sqlex As SqlException
            Throw New Exception(sqlex.Message)
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
    End Sub


    Protected Function DeleteDataGeneric(ByVal objeto As T, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As Integer
        Dim comm As SqlCommand = Nothing
        Dim RecordDeleted As Integer = 0
        Try
            Dim StrWhere As String = CreateWhere(objeto)
            comm = New SqlCommand(StoreProcedureName, Transaccion.MyConnection)
            comm.CommandType = CommandType.StoredProcedure

            With comm.Parameters
                Dim Param As SqlParameter
                Param = New SqlParameter("@p_where_str", SqlDbType.VarChar, 4000)
                Param.Value = StrWhere
                .Add(Param)
                Param = New SqlParameter("@p_num_deleted", SqlDbType.Int, 0)
                Param.Direction = ParameterDirection.Output
                .Add(Param)
            End With
            comm.ExecuteNonQuery()
            RecordDeleted = Integer.Parse(comm.Parameters("@p_num_deleted").Value)
        Catch sqlex As SqlException
            Throw New Exception(sqlex.Message)
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
        Return RecordDeleted
    End Function

  ''' <summary>
  ''' Funcion de recuperacion generica de datos. Recupera por cualquier atributo del objeto
  ''' </summary>
  ''' <param name="objeto">El objeto especifico que contiene la información por la que recuperara</param>
  ''' <param name="StoreProcedureName">Nombre del procediento</param>
  ''' <param name="Transaccion">Transaccion asociada, se usa para recuperar la conexion.</param>
  ''' <returns>Lista de objetos con las coincidencias encontradas</returns>
  ''' <remarks>Envia solo los parametros que contengan informacion distinta a la por defecto del tipo de dato</remarks>
  Public Function ReadData(ByVal objeto As T, ByVal StoreProcedureName As String, ByVal Transaccion As FWPTransaction) As IList(Of T)
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
                  vsccID.descripcion = Txt.Init(dr(MyBase.Description(objeto, propiedad.Name, TipoDescripcionCompuesto.NombreDescripcion)))
                  propiedad.SetValue(myObject, vsccID, Nothing)
                Case "SCCommonFecha"
                  Dim vsccF As New SCCommonFecha
                  vsccF.Fecha = dr(propiedad.Name)
                  propiedad.SetValue(myObject, vsccF, Nothing)
                Case Else
                  If (dr(col).GetType.Name.ToLower = "byte[]") Then
                    propiedad.SetValue(myObject, CType(dr(col), Byte()), Nothing)
                  Else
                    propiedad.SetValue(myObject, dr(col), Nothing)
                  End If

              End Select
            End If
          End If
        Next
        IlistResult.Add(myObject)
      End While
      dr.Close()
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

End Class
