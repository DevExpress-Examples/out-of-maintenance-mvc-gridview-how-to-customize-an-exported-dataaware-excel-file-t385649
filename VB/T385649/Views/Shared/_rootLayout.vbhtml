<!DOCTYPE html>

<html>
<head>
    <meta charset="UTF-8" />
    <title>@ViewBag.Title</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />


    @Html.DevExpress().GetStyleSheets(New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.PivotGrid}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.HtmlEditor}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.Chart}, New StyleSheet With {.ExtensionSuite = ExtensionSuite.Report})
    @Html.DevExpress().GetScripts(New Script With {.ExtensionSuite = ExtensionSuite.GridView}, New Script With {.ExtensionSuite = ExtensionSuite.PivotGrid}, New Script With {.ExtensionSuite = ExtensionSuite.HtmlEditor}, New Script With {.ExtensionSuite = ExtensionSuite.Editors}, New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout}, New Script With {.ExtensionSuite = ExtensionSuite.Chart}, New Script With {.ExtensionSuite = ExtensionSuite.Report})
</head>
<body>
    @Html.DevExpress().Splitter(Function(settings)
                                    settings.Name = "MainSplitter"
                                    settings.AllowResize = False
                                    settings.Orientation = System.Web.UI.WebControls.Orientation.Vertical
                                    settings.FullscreenMode = True
                                    settings.SeparatorVisible = False
                                    settings.Styles.Pane.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0)
                                    settings.Styles.Pane.Paddings.Padding = System.Web.UI.WebControls.Unit.Pixel(0)
                                    settings.Panes.Add(Function(pane)
                                                           pane.Name = "Content"
                                                           pane.PaneStyle.CssClass = "mainContentPane"
                                                           pane.MinSize = System.Web.UI.WebControls.Unit.Pixel(375)
                                                           pane.PaneStyle.BackColor = System.Drawing.Color.White
                                                           pane.PaneStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1)
                                                           pane.SetContent(RenderBody().ToHtmlString())

                                                       End Function)

                                End Function).GetHtml()
</body>
</html>