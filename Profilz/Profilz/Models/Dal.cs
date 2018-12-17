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

        public Repository<User> monDepot;

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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Dal>());

        }
        public User Find(int? id)
        {
            if (id.HasValue)
            {
                // return monDepot.FirstOrDefault(item => item.Id==id);
                return users.FirstOrDefault(item => item.Id == id);
            }
            return null;
        }
        public List<User> FindAll()
        {
            return users.ToList();
        }
        public User Ajouter(User source)
        {
            try
            {
                return users.Add(source);
            }
            catch
            {
                return null;
            }
        }
        public bool Retirer(User user)
        {
            try
            {
                users.Remove(user);
            }
            catch (Exception exc)
            {

                return false;
            }
            return true;
        }
        public bool Update<T>(Model source) where T : Model
        {
            try
            {
                DbSet<T> table = this.Set<T>();
                Model dbItem = source;
            }
            catch
            {
                return false;
            }
            return true;

        }
        public bool Update(Model source)
        {
            Model dbItem = Find(source.Id);
            if (dbItem != null)
            {
                dbItem.UpdateFrom(source);
                return true;
            }
            return false;
        }

    }
}