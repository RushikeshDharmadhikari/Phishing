<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Selenium.PerformanceDisplay.Models.Performance>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Index</title>
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
        }
    </style>
</head>
<body>
    <div>
    <h1 class="style1">Page Performance History</h1>
    <br />
    <div align="center">
    <img src="https://chart.googleapis.com/chart?cht=lc&chs=500x500&chd=<%= Model.FullyLoadedTimeData %>&chxt=x,y&chxl=<%= Model.ChartLabels %>&chxr=1,0,<%= Model.LargestValue %>&chds=0,<%= Model.LargestValue %>" />
    </div>
    </div>
</body>
</html>
