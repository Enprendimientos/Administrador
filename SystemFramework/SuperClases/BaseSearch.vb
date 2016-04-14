Imports Fwp.common
Imports System.ComponentModel
Imports Fwp.common.TiposBases
Imports System.Collections.Generic

Public Class BaseSearch(Of T)
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
        Return listResul(1)
    End Function

    Public Function Search(ByVal Columna As String, ByVal Valor As Object) As IList(Of T)
        Dim Columnas() As String, Valores() As String
        ReDim Columnas(0)
        ReDim Valores(0)
        Columnas(0) = Columna
        Valores(0) = Valor
        Return Search(Columnas, Valores)
    End Function

    Public Function Search(ByVal Columnas() As String, ByVal Valores() As Object) As T 'IList(Of T)
        Dim Columna As String = ""
        Dim Valor As Object = Nothing
        Dim myObject As T = Activator.CreateInstance(Of T)()
        Dim propiedadesObj As System.Reflection.PropertyInfo() = myObject.GetType.GetProperties()
        For i As Integer = 0 To Columnas.Length - 1
            Columna = Columnas(i)
            Valor = Valores(i)
            Dim propiedad As System.Reflection.PropertyInfo = myObject.GetType.GetProperty(Columnas(i))
            If Not propiedad Is Nothing Then 'solo si la encuentra asigna el valor
                'Si es NULL no asigna el valor
                Select Case propiedad.PropertyType.Name
                    Case "EstadoRegistro"
                        If Boolean.Parse(Valor) Then
                            propiedad.SetValue(myObject, EstadoRegistro.ACT, Nothing)
                        Else
                            propiedad.SetValue(myObject, EstadoRegistro.DES, Nothing)
                        End If
                    Case "SCCommonIdDescripcion"
                        Dim vsccID As New SCCommonIdDescripcion
                        If Description(myObject, propiedad.Name, TipoDescripcionCompuesto.NombreId) = Columna Then
                            vsccID.id = Integer.Parse(Valor)
                        ElseIf Description(myObject, propiedad.Name, TipoDescripcionCompuesto.NombreDescripcion) = Columna Then
                            vsccID.descripcion = Convert.ToString(Valor)
                        End If
                        propiedad.SetValue(myObject, vsccID, Nothing)
                    Case Else
                        propiedad.SetValue(myObject, Valor, Nothing)
                End Select
            End If
        Next
        'Return GetData(myObject)
        Return myObject
    End Function

    Public Function Search(ByVal Columna As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date) As T 'IList(Of co_or_oficinas)
        Dim myObject As T = Activator.CreateInstance(Of T)()
        Dim propiedadesObj As System.Reflection.PropertyInfo() = myObject.GetType.GetProperties()
        Dim propiedad As System.Reflection.PropertyInfo = myObject.GetType.GetProperty(Columna)
        If Not propiedad Is Nothing Then 'solo si la encuentra asigna el valor
            'Si es NULL no asigna el valor
            Select Case propiedad.PropertyType.Name
                Case "SCCommonFecha"
                    Dim vsccF As New SCCommonFecha
                    vsccF.FechaDesde = FechaDesde
                    vsccF.FechaHasta = FechaHasta
                    propiedad.SetValue(myObject, vsccF, Nothing)
            End Select
        End If
        'Return GetData(myObject)
        Return myObject
    End Function
End Class
