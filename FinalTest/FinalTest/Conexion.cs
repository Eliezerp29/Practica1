using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FinalTest.Classes;
using Microsoft.EntityFrameworkCore;

namespace FinalTest
{
    public class Conexion<T> where T : class
    {
        public void Create(T obj)
        {
            using (var context = new AplicationDbContext())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
        }
        public List<T> GetAll()
        {
            using (var context = new AplicationDbContext())
            {
                return context.Set<T>().ToList();
            }
        }
        public List<T> GetByCondition(Expression<Func<T,bool>> expression)
        {
            using (var context = new AplicationDbContext())
            {
                return context.Set<T>().Where(expression).AsNoTracking().ToList();
            }
        }
        public void Update(T obj)
        {
            using (var context = new AplicationDbContext())
            {
                context.Set<T>().Update(obj);
                context.SaveChanges();
            }
        }
        public void Delete(T obj)
        {
            using (var context = new AplicationDbContext())
            {
                context.Set<T>().Remove(obj);
                context.SaveChanges();
            }
        }
    }
}


