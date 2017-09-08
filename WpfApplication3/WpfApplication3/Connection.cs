using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WpfApplication3
{
    public static class Connection
    {
        public static string connectionstring = @"Data Source=tcp:193.136.175.33\SQLSERVER2012,8293; Initial Catalog = p2g7; uid = p2g7; password = filipes2";
        public static SqlConnection Conn = new SqlConnection(connectionstring);
    }
}
