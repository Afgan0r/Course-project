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
                string insertString = "INSERT dbo.Tyre ([name_of_tyre],[how_many_took],[is_need_tube],[tube_for_tyre],[withdraw]) " +
                    "VALUES (@name_of_tyre, @how_many_took, @is_need_tube, @tube_for_tyre, @withdraw) ";
                command = new SqlCommand(insertString, connection);
                command.Parameters.AddWithValue("@name_of_tyre", nameOfTyre);
                command.Parameters.AddWithValue("@how_many_took", howManyTook);
                command.Parameters.AddWithValue("@is_need_tube", isNeedTube);
                command.Parameters.AddWithValue("@tube_for_tyre", tubeForTyre);
                command.Parameters.AddWithValue("@withdraw", 0);
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
                string insertString = "INSERT dbo.Tube ([name_of_tube],[how_many_took],[withdraw])" +
                    "VALUES (@name_of_tube,@how_many_took, @withdraw)";
                command = new SqlCommand(insertString, connection);
                command.Parameters.AddWithValue("@name_of_tube", nameOfTube);
                command.Parameters.AddWithValue("@how_many_took", howManyTook);
                command.Parameters.AddWithValue("@withdraw", 0);
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
                string updateString = "UPDATE dbo.Tyre " +
                    "SET withdraw = 0 " +
                    "WHERE withdraw != 0";
                var command = new SqlCommand(updateString, connection);
                command.ExecuteNonQuery();

                updateString = "UPDATE dbo.Tube " +
                    "SET withdraw = 0 " +
                    "WHERE withdraw != 0";
                command = new SqlCommand(updateString, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public static void ChangeWithdrawInTyreTable(string nameOfTyre, int withdraw, string nameOfWheel)
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

                MoveWheelsToCells(nameOfWheel, withdraw);
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
        public static void CompleteToTubeTypeWheels(string nameOfTyre, string nameOfTube, string nameOfWheel)
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
                    "(dbo.Tyre.name_of_tyre = @nameOfWheel)";
                var command = new SqlCommand(selectString, connection);
                command.Parameters.AddWithValue("nameOfTube", nameOfTube);
                command.Parameters.AddWithValue("nameOfWheel", nameOfTyre);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int countTyre = int.Parse(reader[1].ToString());
                    int countTube = int.Parse(reader[3].ToString());
                    if (countTyre < countTube)
                    {
                        ChangeWithdrawInTyreTable(nameOfTyre, countTyre, nameOfWheel);
                        ChangeWithdrawInTubeTable(nameOfTube, countTyre);
                    }
                    else
                    {
                        ChangeWithdrawInTyreTable(nameOfTyre, countTube, nameOfWheel);
                        ChangeWithdrawInTubeTable(nameOfTube, countTube);
                    }
                }
                
                connection.Close();
            }
        }
        public static void MoveWheelsToCells(string nameOfWheel, int count)
        {
            using (var connection = connectToDatabase())
            {
                string selectString = "SELECT contains_wheel " +
                    "FROM dbo.Cell " +
                    "WHERE specification = @specification";
                var command = new SqlCommand(selectString, connection);
                command.Parameters.AddWithValue("specification", nameOfWheel);
                var reader = command.ExecuteReader();
                int countTyres = 0;
                while (reader.Read())
                {
                    countTyres = int.Parse(reader[0].ToString());
                }
                reader.Close();

                string updateString = "UPDATE dbo.Cell " +
                    "SET contains_wheel = @contains_wheel " +
                    "WHERE specification = @specification";
                command = new SqlCommand(updateString, connection);
                command.Parameters.AddWithValue("contains_wheel", count + countTyres);
                command.Parameters.AddWithValue("specification", nameOfWheel);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void InsertIntoRealizationTable(string nameOfWheel, int withdraw)
        {
            using (var connection = connectToDatabase())
            {
                string selectString = "SELECT contains_wheel " +
                "FROM dbo.Cell " +
                "WHERE specification = @specification";
                var command = new SqlCommand(selectString, connection);
                command.Parameters.AddWithValue("specification", nameOfWheel);
                var reader = command.ExecuteReader();
                int countWheel = 0;
                while (reader.Read())
                {
                    countWheel = int.Parse(reader[0].ToString());
                }
                if (withdraw>countWheel)
                    return;
                reader.Close();

                string updateString = "UPDATE dbo.Cell " +
                    "SET contains_wheel = @contains_wheel " +
                    "WHERE specification = @specification";
                command = new SqlCommand(updateString, connection);
                command.Parameters.AddWithValue("contains_wheel", countWheel - withdraw);
                command.Parameters.AddWithValue("specification", nameOfWheel);
                command.ExecuteNonQuery();

                string insertString = "INSERT dbo.Realization (name_of_wheel, how_many_took) " +
                    "VALUES (@name_of_wheel, @how_many_took)";
                command = new SqlCommand(insertString, connection);
                command.Parameters.AddWithValue("@name_of_wheel", nameOfWheel);
                command.Parameters.AddWithValue("@how_many_took", "-"+withdraw);
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        public static void DeleteAllRowsInRealizationTable ()
        {
            using (var connection = connectToDatabase())
            {
                string truncateString = "TRUNCATE TABLE dbo.Realization";
                var command = new SqlCommand(truncateString, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
