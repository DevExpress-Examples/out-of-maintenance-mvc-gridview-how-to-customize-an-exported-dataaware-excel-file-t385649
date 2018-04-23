using DevExpress.Spreadsheet;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using DevExpress.Web.Office;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T385649.Models;

namespace T385649.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(MyModel.GetDataSource());
        }

        public ActionResult ExcelDataAwareExportTo() {
            using (MemoryStream ms = new MemoryStream()) {
                GridViewExtension.WriteXlsx(GridViewExportHelper.ExcelDataAwareExportGridViewSettings(), MyModel.GetDataSource(), ms);
                MVCxSpreadsheet mySpreadsheet = new MVCxSpreadsheet();
                ms.Position = 0;
                mySpreadsheet.Open("myDoc", DocumentFormat.Xlsx, () => {
                    return ms;
                });
                Worksheet aw = mySpreadsheet.Document.Worksheets[0];
                aw.Protect("123456", DevExpress.Spreadsheet.WorksheetProtectionPermissions.Default);
                byte[] result = mySpreadsheet.SaveCopy(DocumentFormat.Xlsx);
                DocumentManager.CloseDocument("myDoc");
                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=test.xlsx");
                Response.BinaryWrite(result);
                Response.End();
            }
            return new EmptyResult();
        }

        public ActionResult GridViewPartialView() {
            return PartialView("GridViewPartialView", MyModel.GetDataSource());
        }
    }
    public class GridViewExportHelper {
        public static GridViewSettings ExcelDataAwareExportGridViewSettings() {
            GridViewSettings settings = new GridViewSettings();
            settings.Name = "GridView";
            settings.CallbackRouteValues = new { Controller = "Home", Action = "GridViewPartialView" };
            settings.KeyFieldName = "ID";
            settings.CommandColumn.Visible = true;
            settings.CommandColumn.ShowEditButton = true;
            settings.Columns.Add("ID");
            settings.Columns.Add("Name");
            settings.Columns.Add(c => {
                c.FieldName = "Position";
                c.ColumnType = MVCxGridViewColumnType.ComboBox;
                var properties = (ComboBoxProperties)c.PropertiesEdit;
                properties.ValueType = typeof(string);
                properties.DataSource = MyModel.GetPositionDataSource();
                properties.DropDownStyle = DropDownStyle.DropDown;
            });
            return settings;
        }
    }
}