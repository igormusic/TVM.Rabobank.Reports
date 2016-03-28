using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Reports
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var reportsPath = Server.MapPath("~/Reports");
            var r = new System.IO.DirectoryInfo(reportsPath);
            foreach (var file in r.GetFiles("*.rpt"))
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlGenericControl h5 = new HtmlGenericControl("h5");
                HtmlGenericControl anchor = new HtmlGenericControl("a");

                li.Attributes.Add("class", "bullet");

                anchor.Attributes.Add("href", String.Format("ReportPreview.aspx?fileName={0}", Server.UrlEncode(file.Name)));
                anchor.InnerText = file.Name;

                li.Controls.Add(h5);
                h5.Controls.Add(anchor);

                ReportList.Controls.Add(li);



            }


        }
    }
}