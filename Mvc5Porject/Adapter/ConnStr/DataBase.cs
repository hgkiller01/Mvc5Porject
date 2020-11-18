using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace Mvc5Porject.Adapter.ConnStr
{
    public class DataBase
    {
        protected string ConnStr;
        protected SqlConnection conn;
        public DataBase()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["Shop"].ConnectionString;
        }
    }
}