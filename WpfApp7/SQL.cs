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
        {   
            using (var connection = connectToDatabase())
            {
                var selectString = "select name_of_tyre, how_many_took from dbo.Tyre";
                var command = new SqlCommand(selectString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString().Equals(nameOfTyre))
                    {                        
                        int count = int.Parse(reader[1].ToString());
                        var updateString = "UPDATE dbo.Tyre " +
                            "SET how_many_took = @how_many_took " +
                            "WHERE name_of_tyre = @name_of_tyre";
                        command = new SqlCommand(updateString, connection);
                        command.Parameters.AddWithValue("@how_many_took", count + howManyTook);
                        command.Parameters.AddWithValue("@name_of_tyre", nameOfTyre);
                        reader.Close();
                        command.ExecuteNonQuery();
                        connection.Close();
                        return;
                    }
                }
                reader.Close();
                string insertString = "INSERT dbo.Tyre ([name_of_tyre],[how_many_took],[is_need_tube],[tube_for_tyre]) " +
                    "VALUES (@name_of_tyre, @how_many_took, @is_need_tube, @tube_for_tyre) ";
                command = new SqlCommand(insertString, connection);
                command.Parameters.AddWithValue("@name_of_tyre", nameOfTyre);
                command.Parameters.AddWithValue("@how_many_took", howManyTook);
                command.Parameters.AddWithValue("@is_need_tube", isNeedTube);
                command.Parameters.AddWithValue("@tube_for_tyre", tubeForTyre);
                command.ExecuteNonQuery();
                connection.Close();
                return;
            }            
        }
        public static void InsertIntoTubeTable(string nameOfTube, int howManyTook)
        { 
            using (var connection = connectToDatabase())
            {
                var selectString = "select name_of_tube, how_many_took from dbo.Tube";
                var command = new SqlCommand(selectString, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[0].ToString().Equals(nameOfTube))
                    {
                        int count = int.Parse(reader[1].ToString());
                        var updateString = "UPDATE dbo.Tube" +
                            "SET how_many_took = @name_of_tyre";
                        command = new SqlCommand(updateString, connection);
                        reader.Close();
                        command.ExecuteNonQuery();
                        connection.Close();
                        return;
                    }
                }
                string insertString = "INSERT dbo.Tube ([name_of_tube],[how_many_took])" +
                    "VALUES (@name_of_tube,@how_many_took)";
                command = new SqlCommand(insertString, connection);
                command.Parameters.AddWithValue("@name_of_tube", nameOfTube);
                command.Parameters.AddWithValue("@how_many_took", howManyTook);
                reader.Close();
                command.ExecuteNonQuery();
                connection.Close();
                return;
            }
        }
    }
}
