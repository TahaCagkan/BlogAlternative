using BlogAlternative.DataAccessLayer.Abstract;
using BlogAlternative.DataAccessLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BlogAlternative.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var context = new BlogAlternativeContext();
            context.Remove(t);
            context.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var context = new BlogAlternativeContext();
            return context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var context = new BlogAlternativeContext();
            return context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var context = new BlogAlternativeContext();
            context.Add(t);
            context.SaveChanges();
        }

        public void Update(T t)
        {
            using var context = new BlogAlternativeContext();
            context.Update(t);
            context.SaveChanges();
        }
    }
}
