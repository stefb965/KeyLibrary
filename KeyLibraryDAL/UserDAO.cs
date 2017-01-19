using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;

// Create User
// Update User
// Get User
// Get User List (Get All)
// Delete User

namespace KeyLibraryDAL
{
    public class UserDAO
    {
        KeyLibraryDB Db = new KeyLibraryDB();
        // Create a User object named member to use for the rest of the methods
        public UserDAO()
        {
            User member = new User();
        }

        public User Create(User newUser)
        {
            User member = new User();
            member.Username = newUser.Username;
            member.Password = newUser.Password;
            member.Email = newUser.Email;
            member.IsAdmin = newUser.IsAdmin;
            try
            {
                Db.CreateUser(member);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newUser;
        }

        public List<User> GetUserByName(string name)
        {
            List<User> list = new List<User>();
            try
            {
                list = Db.GetUserByName(name);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public List<User> GetAll()
        {
            List<User> list = new List<User>();
            try
            {
                list = Db.GetAll();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public long Delete(int userId)
        {
            try
            {
                Db.Delete(userId);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            return 1;
        }
    }
}
