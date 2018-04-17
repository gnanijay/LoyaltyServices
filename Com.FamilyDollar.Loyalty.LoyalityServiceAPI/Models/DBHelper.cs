using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models
{
    public class DBHelper
    {
        public static string GetLoyaltyConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["RDS_DB_NAME"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["RDS_USERNAME"];
            string password = appConfig["RDS_PASSWORD"];
            string hostname = appConfig["RDS_HOSTNAME"];
            string port = appConfig["RDS_PORT"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }

        /// <summary>
        /// GetLogDbConnection string is the method to retrive the connection strin from Web.Confg file. which is used to 
        /// connect the LogDB database.
        /// </summary>
        /// <returns></returns>
        public static string GetLogDBConnectionString()
        {
            string logDbConnectionString = string.Empty;
            if (ConfigurationManager.ConnectionStrings["LogDBContext"]!=null)
            {
                logDbConnectionString= ConfigurationManager.ConnectionStrings["LogDBContext"].ConnectionString;
            }
            return logDbConnectionString;
        }
    }
}