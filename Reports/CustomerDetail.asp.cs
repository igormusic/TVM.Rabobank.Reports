using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reports
{
    public partial class CustomerDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string customerId = Request["CustomerId"];

            if(String.IsNullOrWhiteSpace(customerId))
            {
                Response.Write ("No Customer id supplied. Please go back and try again.");
		        Response.End();
                return;
            }

        }
    }
}