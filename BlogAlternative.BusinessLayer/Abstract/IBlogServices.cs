using BlogAlternative.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogAlternative.BusinessLayer.Abstract
{
    public interface IBlogServices:IGenericService<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetThreeLastBlog();
        List<Blog> GetBlogListByID(int id);
        List<Blog> GetBlogListByWriterID(int id);
        List<Blog> GetListWithCategoryByWriterID(int id);

    }
}
