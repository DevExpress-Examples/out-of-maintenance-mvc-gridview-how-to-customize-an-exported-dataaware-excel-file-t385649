@ModelType System.Collections.IEnumerable

@Html.DevExpress().GridView(T385649.Controllers.GridViewExportHelper.ExcelDataAwareExportGridViewSettings()).Bind(Model).GetHtml()