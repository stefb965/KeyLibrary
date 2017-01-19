using System;
using KeyLibraryDAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeyLibTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestShouldConnectToDb()
        {
            KeyLibraryDB Db = new KeyLibraryDB();
            Db.DbConnect();
        }
        [TestMethod]
        public void TestShouldCreateUser()
        {
            User Mike = new User();
            Mike.Username = "mike";
            Mike.Password = "admin1234";
            Mike.Email = "mike.wildcats@gmail.com";
            Mike.IsAdmin = true;

            KeyLibraryDB Db = new KeyLibraryDB();
            Db.CreateUser(Mike);
        }
        [TestMethod]
        public void TestDAOShouldCreateUser()
        {
            UserDAO dao = new UserDAO();
            User Mike = new User();
            Mike.Username = "mike";
            Mike.Password = "admin1234";
            Mike.Email = "mike.wildcats@gmail.com";
            Mike.IsAdmin = true;
            dao.Create(Mike);
        }
        [TestMethod]
        public void TestShouldCreateUserAndFindIt()
        {
            UserDAO dao = new UserDAO();
            User Mike = new User();
            Mike.Username = "mike";
            Mike.Password = "admin1234";
            Mike.Email = "mike.wildcats@gmail.com";
            Mike.IsAdmin = true;
            dao.Create(Mike);

            dao.GetUserByName("Mike");
        }
       
    }
}
