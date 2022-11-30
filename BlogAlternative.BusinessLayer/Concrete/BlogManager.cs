using BlogAlternative.BusinessLayer.Abstract;
using BlogAlternative.DataAccessLayer.Abstract;
using BlogAlternative.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BlogAlternative.BusinessLayer.Concrete
{
	public class BlogManager : IBlogServices
	{
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
    
		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}
		//id ye göre listeleme işlemi
        public List<Blog> GetBlogListByID(int id)
        {
			return _blogDal.GetListAll(x => x.BlogID == id);
		}

		public List<Blog> GetBlogListByWriterID(int id)
		{
			return _blogDal.GetListAll(x => x.WriterID == id);
		}
        public List<Blog> GetListWithCategoryByWriterID(int id)
        {
			return _blogDal.GetListWithCategoryByWriter(id);
        }

        public List<Blog> GetThreeLastBlog()
		{
			return _blogDal.GetListAll().Take(3).ToList();
		}

		public void TAdd(Blog t)
		{
			_blogDal.Insert(t);
		}

		public void TDelete(Blog t)
		{
			_blogDal.Delete(t);
		}

		public void TUpdate(Blog t)
		{
			_blogDal.Update(t);
		}

		public List<Blog> GetListAll()
		{
            return _blogDal.GetListAll();
        }

        public Blog TGetById(int id)
		{
			return _blogDal.GetByID(id);
		}
	}
}
