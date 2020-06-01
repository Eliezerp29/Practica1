    using System.Collections.Generic;
using System.Linq;
using PrimerParcial.Context;

namespace PrimerParcial
{
    public class Conexion<T> where T : class
    {
        public void Create(T obj) {
            using (var context = new DatabaseNominaContext())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
        }
        public List<T> GetAll() {
            using (var context = new DatabaseNominaContext())
            {
                return context.Set<T>().ToList();
            }
        }
        public void Update(T obj) {
            using (var context = new DatabaseNominaContext())
            {
                context.Set<T>().Update(obj);
                context.SaveChanges();
            }
        }
        public void Delete(T obj) {
            using (var context = new DatabaseNominaContext())
            {
                context.Set<T>().Remove(obj);
                context.SaveChanges();
            }
        }
    }
}
