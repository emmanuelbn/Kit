using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Profilz.Models;
using System.Data.Entity;
using System.Linq;

namespace Profilz.Tests
{
    [TestClass]
    public class UnitTest1 
    {
        Repository<User> users = new Repository<User>();
        [TestMethod]
        public void Test_Create_Perso()
        {
            ;
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
        [TestMethod]
        public void test_update()
        {
            Test_Create_Perso();
            DbSet<User> users = Dal.Context.users;
            User u = Dal.Context.users.FirstOrDefault(x => x.Id == 1);
           // dal.users.Find(.Local. Dal.Context.users.Find();

            Dal.Context.SaveChanges();
        }
        [TestMethod]
        public void Test_retirer()
        {
            Test_Create_Perso();
            User user = new User() {
                
                Username ="jojo",
                Email = "a@a",
                Password = "12345678"
            };
            users.Add(user);
            Dal.Context.SaveChanges();
            Assert.IsNotNull( users.Add(user));
            
            Assert.IsFalse( Dal.Context.Retirer(user));
            Assert.IsNull(Dal.Context.users.FirstOrDefault( item => item.Id==1));

        }
    }
}
