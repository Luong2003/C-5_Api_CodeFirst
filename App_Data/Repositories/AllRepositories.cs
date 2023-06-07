using App_Data.IRepositories;
using App_Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Repositories
{
    public class AllRepositories<T> : IAllRepositories<T> where T : class
    {
        private NHOM5_C5Context _context;
        private DbSet<T> _dbSet;

        public AllRepositories(NHOM5_C5Context context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public NHOM5_C5Context Context => _context;
        public DbSet<T> DbSet => _dbSet;

        public bool AddItem(T item)
        {
            try
            {
                DbSet.Add(item);   // Thêm vào Dbset
                Context.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditItem(T item)
        {
            try
            {
                DbSet.Update(item);   // Sửa trong Dbset
                Context.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }
        public IEnumerable<T> GetProductById(Guid id)
        {
            return DbSet.ToList();
        }
        public bool RemoveItem(T item)
        {
            try
            {
                DbSet.Remove(item);   // Sửa trong Dbset
                Context.SaveChanges();  // Lưu lại trạng thái thay đổi DbContext
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
