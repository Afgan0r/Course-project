using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7
{
    class SQL
    {
        public static SqlConnection connectToDatabase()
        {
            string connectionString = @"Data Source=DESKTOP-DB58EN5\MSSQLSERVER01;" +
                "Initial Catalog=Workshop_Equipment;" +
                "Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
