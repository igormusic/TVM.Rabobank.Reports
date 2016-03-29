<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportPreview.aspx.cs" Inherits="Reports.ReportPreview" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .navigation-menu
        {
            font-size: 1.3em;
            font-weight: 600;
            color: #999;
            padding-left: 3px;
            padding-right: 3px;
            font-family: "Segoe UI", Verdana, Helvetica, Sans-Serif;
        }

        ul#menu
        {
            font-size: 1.3em;
            font-weight: 600;
            margin: 0 0 5px;
            padding: 0;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav>
            <ul id="menu">
                <li class="navigation-menu" ><a href="./">Reports</a></li>
            </ul>
        </nav>

        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server"   Height="50px" ReportSourceID="CrystalReportSource" ReuseParameterValuesOnRefresh="True" ToolPanelWidth="200px" Width="350px" />
            <CR:CrystalReportSource ID="CrystalReportSource" runat="server">
            </CR:CrystalReportSource>
        </div>
    </form>
</body>
</html>
