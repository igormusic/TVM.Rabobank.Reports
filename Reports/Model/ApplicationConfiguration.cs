using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reports.Model
{
    public class ApplicationConfiguration
    {
        private static System.Data.SqlClient.SqlConnectionStringBuilder  _sqlConnect;

        public static System.Data.SqlClient.SqlConnectionStringBuilder SQLConnectInfo{
            get{
                if(_sqlConnect == null)
                {
                    var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ReportConnection"].ConnectionString;

                     _sqlConnect = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
                }

                return _sqlConnect;
            }
        }


               }
}