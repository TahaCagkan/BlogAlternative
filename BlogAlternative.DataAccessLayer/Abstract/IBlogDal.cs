using BlogAlternative.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogAlternative.DataAccessLayer.Abstract
{
    public interface IBlogDal: IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
