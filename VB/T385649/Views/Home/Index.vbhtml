@ModelType System.Collections.IEnumerable
@Using (Html.BeginForm("ExcelDataAwareExportTo", "Home"))
    @Html.Partial("GridViewPartialView", Model)
    @<input type="submit" />
End Using