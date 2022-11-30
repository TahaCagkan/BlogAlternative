using BlogAlternative.DataAccessLayer.Abstract;
using BlogAlternative.DataAccessLayer.Concrete;
using BlogAlternative.DataAccessLayer.Repositories;
using BlogAlternative.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogAlternative.DataAccessLayer.EntiyFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (var value = new BlogAlternativeContext())
            {
                return value.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var value = new BlogAlternativeContext())
            {
                return value.Blogs.Include(x => x.Category).Where(x => x.WriterID == id).ToList();
            }
        }
    }
}
