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
        public static void InsertIntoTyreTable(string nameOfTyre, int howManyTook,bool isNeedTube, string tubeForTyre)
        {   //TODO Check if tyre alredy exists
            using (var connection = connectToDatabase())
            {
                string insertString = "INSERT dbo.Tyre ([name_of_tyre],[how_many_took],[is_need_tube],[tube_for_tyre]) " +
                    "VALUES (@name_of_tyre, @how_many_took, @is_need_tube, @tube_for_tyre) ";
                var command = new SqlCommand(insertString, connection);
                command.Parameters.AddWithValue("@name_of_tyre", nameOfTyre);
                command.Parameters.AddWithValue("@how_many_took", howManyTook);
                command.Parameters.AddWithValue("@is_need_tube", isNeedTube);
                command.Parameters.AddWithValue("@tube_for_tyre", tubeForTyre);
                command.ExecuteNonQuery();
                connection.Close();
            }            
        }
        public static void InsertIntoTubeTable(string nameOfTube, int howManyTook)
        {   //TODO Check if tyre alredy exists
            using (var connection = connectToDatabase())
            {
                string insertString = "INSERT dbo.Tube ([name_of_tube],[how_many_took])" +
                    "VALUES (@name_of_tube,@how_many_took)";
                var command = new SqlCommand(insertString, connection);
                command.Parameters.AddWithValue("@name_of_tube", nameOfTube);
                command.Parameters.AddWithValue("@how_many_took", howManyTook);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
