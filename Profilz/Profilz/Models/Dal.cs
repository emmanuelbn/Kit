using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Profilz.Models
{
    public class Dal : DbContext
    {
        #region Tables
        public DbSet<User> users { get; protected set; }

        #endregion
        private static Dal _context;

        public static Dal Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new Dal();
                }
                return _context;
            }




        }
        public Dal() : base("mainContext")
        {

        }
        public Dal(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
        public void ajouter(User user)
        {
            users.Add(user);
        }
        public void retirer(User user)
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Dal>());

        }
        public User Find(int? id)
        {
            if (id.HasValue)
            {
                return users.FirstOrDefault(item => item.Id == id);
            }
            return null;
        }
        public List<User> FindAll()
        {
            return users.ToList();
        }
        public override T Add(T source)
        {
            try
            {
                return base.Add(source);
            }
            catch
            {
                return null;
            }

        }
    }
}