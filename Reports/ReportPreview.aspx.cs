using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Reports.Model;

namespace Reports
{
    public partial class ReportPreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var fileName = Request.QueryString["fileName"];
            var filePath = String.Format("{0}\\{1}", Server.MapPath("~/Reports"), fileName);

            var fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists == false)
            {

                ReturnErrorStatusAndShowMessage(fileName);

                return;
            }


            var connectionInfo = GetConnectionInfo();


            CrystalDecisions.Web.Report webReport= new CrystalDecisions.Web.Report();
            webReport.FileName = filePath;
            CrystalReportSource.Report = webReport;

            SetDBLogonForReport(connectionInfo, CrystalReportSource.ReportDocument);
            
            CrystalReportViewer.Error += new CrystalDecisions.Web.ErrorEventHandler(delegate(Object o, CrystalDecisions.Web.ErrorEventArgs errorArgs)
            {
                //ignore missing parameters error (not an error)
                if (!errorArgs.ErrorMessage.Contains("Missing parameter values"))
                    ShowFeaturedText(String.Format("Error {0}", errorArgs.ErrorMessage));
            });

            //CrystalReportViewer.ReportSource = report;

            CrystalReportViewer.RefreshReport();

        }

        private static ConnectionInfo GetConnectionInfo()
        {

            var builder = ApplicationConfiguration.SQLConnectInfo;

            var connectionInfo = new ConnectionInfo();
            connectionInfo.DatabaseName = builder.InitialCatalog;
            connectionInfo.IntegratedSecurity = builder.IntegratedSecurity;
            connectionInfo.UserID = builder.UserID;
            connectionInfo.Password = builder.Password;
            connectionInfo.ServerName = builder.DataSource;
            
            return connectionInfo;
        }

        private void ReturnErrorStatusAndShowMessage(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Response.StatusCode = 404;
                ShowFeaturedText("Required fileName query string is missing");
            }
            else
            {
                Response.StatusCode = 404;
                ShowFeaturedText(string.Format("Report {0} not found", Request.QueryString["fileName"]));
            }
        }

        private void SetDBLogonForReport(ConnectionInfo connectionInfo, ReportDocument reportDocument)
        {
            Tables tables = default(Tables);
            tables = reportDocument.Database.Tables;


            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogonInfo = new TableLogOnInfo();

                tableLogonInfo = table.LogOnInfo;
                tableLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(tableLogonInfo);

            }


        }

        private void ShowFeaturedText(string text)
        {

            var h5 = new HtmlGenericControl("h5");
            var p = new HtmlGenericControl("p");

            h5.InnerText = text;

            p.Controls.Add(h5);

            //featuredContent.Controls.Add(p);
        }
    }
}