using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Profilz.Models;

namespace Profilz.Tests
{
    [TestClass]
    public class UnitTest1 
    {
        Repository<User> users = new Repository<User>();
        [TestMethod]
        public void Test_Create_Perso()
        {
            Dal dal = Dal.Context;
            User user = new User()
            {
                Username ="micke",
                Email="a@a",
                Password= "12345678"
            };
            users.Add(user);
            
            
            //Dal.Context.users.Add(user);
            Dal.Context.SaveChanges();
           Assert.IsNotNull(user);
          Assert.AreEqual(user.Username, "micke");
        }

    }
}
