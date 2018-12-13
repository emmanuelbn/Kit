using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Profilz.Models
{
    public class Repository<T> : DbSet<T> where T : Model
    {
        /// <summary>
        /// find lelement de num id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find(int? id)
        {
            if (id.HasValue)
            {
                return Local.FirstOrDefault(item => item.Id == id);
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<T> FindAll()
        {
            return Local.ToList();
        }
        /// <summary>
        /// ajoute un element
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
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
        public bool Update(T source)
        {
            T dbItem = Find(source.Id);
            if (dbItem != null)
            {
                dbItem.UpdateFrom(source);
                return true;
            }
            return false;
        }

        public bool Remove(int? id)
        {
            if (id.HasValue)
            {
                T dbItem = Find(id);
                if (dbItem!=null)
                {
                    Remove(dbItem);
                    return true;
                }

            }

            return false;
        }

        public new bool Remove(T source)
        {
            try
            {
                base.Remove(source);
                return true;
            }
            catch
            {
return false;
            }
            
        }
    }
}