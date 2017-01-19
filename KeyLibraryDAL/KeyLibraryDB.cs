using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Sql;

namespace KeyLibraryDAL
{
    public class KeyLibraryDB
    {
        // Global class fields
        string sql;
        
        static DbConfig config = new DbConfig();

        // Declare MySQL client object
        public MySql.Data.MySqlClient.MySqlConnection Db = new MySql.Data.MySqlClient.MySqlConnection(config.BuildConn());

        public void DbConnect()
        {   
            //Try to connect, catch MySQL exception on fail
            try
            {   
                // Pass connection string to a newly instantiated Connection object
                Db.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                // Print errors to console
                Console.WriteLine(ex.Message);
                // There was an error, close the connection
                Db.Close();
            }
        }

        public void DbClose()
        {
            //If the Db is never explicitly closed, run this method.
            Db.Close();
        }
        /**
         * CreateUser
         * Params: newUser object
         * Returns: void
         * Note: Create a user with a temporary passed User object and insert the data to the database using the prepopulated fields
         */
        public void CreateUser(User newUser)
        {
            try
            {
                // Open the connection to the database
                Db.Open();
                sql = "INSERT INTO users (Username, Password, Email, Admin) VALUES(" + newUser.Username + ", " + newUser.Password + ", " + newUser.Email + ", " + newUser.IsAdmin + ");";
                // Create a Command object and pass the SQL command and Db connection object
                MySqlCommand Command = new MySqlCommand(sql, Db);
                // Execute the SQL command - NonQuery for non SELECT commands
                Command.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                // There was an error, close the connection
                Db.Close();
            }
        }
         /**
         * GetUserByName
         * Params: name string
         * Returns: List of User objects
         * Note: pass a string to the method to query the database with. If result is found, populate a User object with the retrieved data and return it.
         */
        public List<User> GetUserByName(string name)
        {
            var list = new List<User>();
            try
            {
                // Open the connection to the database
                Db.Open();
                // Let's query the database for this name
                sql = "SELECT UserID, Username, Email FROM users WHERE Username = " + name + ";";
                MySqlCommand Command = new MySqlCommand(sql, Db);
                var run = Command.ExecuteReader();
                while (run.Read())
                    list.Add(new User { UserID = run.GetInt32(0), Username = run.GetString(1), Email = run.GetString(2) });
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Db.Close();
            } 
            return list;
        }
        public List<User> GetAll()
        {
            var list = new List<User>();
            try
            {
                Db.Open();
                sql = "SELECT UserID, Username, Email FROM users;";
                MySqlCommand Command = new MySqlCommand(sql, Db);
                var run = Command.ExecuteReader();
                while (run.Read())
                    list.Add(new User { UserID = run.GetInt32(0), Username = run.GetString(1), Email = run.GetString(2) });
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Db.Close();
            }
            return list;
        }
        public long Delete(int userId)
        {
            try
            {
                Db.Open();
                sql = "DELETE FROM users WHERE UserID = " + userId + ";";
                MySqlCommand Command = new MySqlCommand(sql, Db);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Db.Close();
                return 0;
            }
            return 1;
        }
    }
}
