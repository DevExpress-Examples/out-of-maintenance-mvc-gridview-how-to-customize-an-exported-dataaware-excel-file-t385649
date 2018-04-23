Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace T385649.Models
    Public Class MyModel
        Public Property ID() As Integer
        Public Property Name() As String
        Public Property Position() As String

        Public Shared Function GetDataSource() As List(Of MyModel)
            Dim result As New List(Of MyModel)()
            Dim test1 As New MyModel()
            test1.ID = 0
            test1.Name = "Dave"
            test1.Position = "Manager"
            Dim test2 As New MyModel()
            test2.ID = 1
            test2.Name = "John"
            test2.Position = "Plumber"
            Dim test3 As New MyModel()
            test3.ID = 2
            test3.Name = "Jack"
            test3.Position = "Plumber"
            result.Add(test1)
            result.Add(test2)
            result.Add(test3)
            Return result
        End Function

        Public Shared Function GetPositionDataSource() As List(Of String)
            Dim temp As New List(Of String)()
            temp.Add("Manager")
            temp.Add("Plumber")
            Return temp
        End Function
    End Class
End Namespace