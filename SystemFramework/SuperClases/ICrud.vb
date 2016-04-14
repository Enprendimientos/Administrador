Imports System.Collections.Generic
Public Interface ICrud(Of T)
    Function GetData(ByVal id As Integer) As T
    Function GetData(ByVal oficina As T) As IList(Of T)
    Function Insert(ByVal oficina As T) As T
    Function Insert(ByVal oficinas As IList(Of T)) As IList(Of T)
End Interface


