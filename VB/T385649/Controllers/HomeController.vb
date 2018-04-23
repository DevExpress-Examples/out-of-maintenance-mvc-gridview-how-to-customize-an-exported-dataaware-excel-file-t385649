Imports DevExpress.Spreadsheet
Imports DevExpress.Web
Imports DevExpress.Web.Mvc
Imports DevExpress.Web.Office
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports T385649.Models

Namespace T385649.Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View(MyModel.GetDataSource())
        End Function

        Public Function ExcelDataAwareExportTo() As ActionResult
            Using ms As New MemoryStream()
                GridViewExtension.WriteXlsx(GridViewExportHelper.ExcelDataAwareExportGridViewSettings(), MyModel.GetDataSource(), ms)
                Dim mySpreadsheet As New MVCxSpreadsheet()
                ms.Position = 0
                mySpreadsheet.Open("myDoc", DocumentFormat.Xlsx, Function() ms)
                Dim aw As Worksheet = mySpreadsheet.Document.Worksheets(0)
                aw.Protect("123456", DevExpress.Spreadsheet.WorksheetProtectionPermissions.Default)
                Dim result() As Byte = mySpreadsheet.SaveCopy(DocumentFormat.Xlsx)
                DocumentManager.CloseDocument("myDoc")
                Response.Clear()
                Response.ContentType = "application/force-download"
                Response.AddHeader("content-disposition", "attachment; filename=test.xlsx")
                Response.BinaryWrite(result)
                Response.End()
            End Using
            Return New EmptyResult()
        End Function

        Public Function GridViewPartialView() As ActionResult
            Return PartialView("GridViewPartialView", MyModel.GetDataSource())
        End Function
    End Class
    Public Class GridViewExportHelper
        Public Shared Function ExcelDataAwareExportGridViewSettings() As GridViewSettings
            Dim settings As New GridViewSettings()
            settings.Name = "GridView"
            settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartialView"}
            settings.KeyFieldName = "ID"
            settings.CommandColumn.Visible = True
            settings.CommandColumn.ShowEditButton = True
            settings.Columns.Add("ID")
            settings.Columns.Add("Name")
            settings.Columns.Add(Sub(c)
                c.FieldName = "Position"
                c.ColumnType = MVCxGridViewColumnType.ComboBox
                Dim properties = CType(c.PropertiesEdit, ComboBoxProperties)
                properties.ValueType = GetType(String)
                properties.DataSource = MyModel.GetPositionDataSource()
                properties.DropDownStyle = DropDownStyle.DropDown
            End Sub)
            Return settings
        End Function
    End Class
End Namespace