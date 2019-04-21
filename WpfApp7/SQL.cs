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
                        var updateString = "UPDATE dbo.Tube " +
                            "SET how_many_took = @how_many_took " +
                            "WHERE name_of_tube = @name_of_tube";
                        command = new SqlCommand(updateString, connection);
                        command.Parameters.AddWithValue("name_of_tube", nameOfTube);
                        command.Parameters.AddWithValue("how_many_took", count + howManyTook);
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
        public static void DeleteEmptyTubeAndTyreRows()
        {
            using (var connection = connectToDatabase())
            {
                string deleteString = "DELETE FROM dbo.Tyre " +
                    "WHERE how_many_took = 0";
                var command = new SqlCommand(deleteString, connection);
                command.ExecuteNonQuery();

                deleteString = "DELETE FROM dbo.Tube " +
                    "WHERE how_many_took = 0";
                command = new SqlCommand(deleteString, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void RefreshWithdrawInTables()
        {
            using (var connection = connectToDatabase())
            {
                string updateString = "UPDATE dbo.tyre " +
                    "SET withdraw = 0 " +
                    "WHERE withdraw > 0";
                var command = new SqlCommand(updateString, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void ChangeWithdrawInTyreTable(string nameOfTyre, int withdraw)
        {
            using (var connection = connectToDatabase())
            {
                string selectString = "SELECT how_many_took " +
                    "FROM dbo.Tyre " +
                    "WHERE name_of_tyre = @name_of_tyre";
                var command = new SqlCommand(selectString, connection);
                command.Parameters.AddWithValue("name_of_tyre", nameOfTyre);
                var reader = command.ExecuteReader();                
                int countTyres = 0;
                while (reader.Read())
                {
                    countTyres = int.Parse(reader[0].ToString());
                }
                reader.Close();

                string updateString = "UPDATE dbo.Tyre " +
                    "SET " +
                    "how_many_took = @how_many_took, " +
                    "withdraw = @withdraw " +
                    "WHERE name_of_tyre = @name_of_tyre";
                command = new SqlCommand(updateString, connection);
                command.Parameters.AddWithValue("how_many_took", countTyres - withdraw);
                command.Parameters.AddWithValue("withdraw", "-"+withdraw);
                command.Parameters.AddWithValue("name_of_tyre", nameOfTyre);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void ChangeWithdrawInTubeTable(string nameOfTube, int withdraw)
        {
            using (var connection = connectToDatabase())
            {
                string selectString = "SELECT how_many_took " +
                    "FROM dbo.Tube " +
                    "WHERE name_of_tube = @name_of_tube";
                var command = new SqlCommand(selectString, connection);
                command.Parameters.AddWithValue("name_of_tube", nameOfTube);
                var reader = command.ExecuteReader();
                int countTubes = 0;
                while (reader.Read())
                {
                    countTubes = int.Parse(reader[0].ToString());
                }
                reader.Close();

                string updateString = "UPDATE dbo.Tube " +
                    "SET " +
                    "how_many_took = @how_many_took, " +
                    "withdraw = @withdraw " +
                    "WHERE name_of_tube = @name_of_tube";
                command = new SqlCommand(updateString, connection);
                command.Parameters.AddWithValue("how_many_took", countTubes - withdraw);
                command.Parameters.AddWithValue("withdraw", "-" + withdraw);
                command.Parameters.AddWithValue("name_of_tube", nameOfTube);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void CompleteToTubeTypeWheels(string nameOfTyre, string nameOfTube)
        {
            using (var connection = connectToDatabase())
            {
                string selectString = "SELECT " +
                    "dbo.Tube.name_of_tube, dbo.Tube.how_many_took, " +
                    "dbo.Tyre.name_of_tyre, dbo.Tyre.how_many_took AS Expr1, dbo.Tyre.tube_for_tyre " +
                    "FROM " +
                    "dbo.Tube CROSS JOIN dbo.Tyre " +
                    "WHERE " +
                    "(dbo.Tube.name_of_tube = @nameOfTube) " +
                    "AND " +
                    "(dbo.Tyre.name_of_tyre = @nameOfTyre)";
                var command = new SqlCommand(selectString, connection);
                command.Parameters.AddWithValue("nameOfTube", nameOfTube);
                command.Parameters.AddWithValue("nameOfTyre", nameOfTyre);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int countTyre = int.Parse(reader[1].ToString());
                    int countTube = int.Parse(reader[3].ToString());
                    if (countTyre < countTube)
                    {
                        ChangeWithdrawInTyreTable(nameOfTyre, countTyre);
                        ChangeWithdrawInTubeTable(nameOfTube, countTyre);
                    }
                    else
                    {
                        ChangeWithdrawInTyreTable(nameOfTyre, countTube);
                        ChangeWithdrawInTubeTable(nameOfTube, countTube);
                    }
                }
                
                connection.Close();
            }
        }
    }
}
