using BlogAlternative.BusinessLayer.Abstract;
using BlogAlternative.DataAccessLayer.Abstract;
using BlogAlternative.DataAccessLayer.EntiyFramework;
using BlogAlternative.DataAccessLayer.Repositories;
using BlogAlternative.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAlternative.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //EfCategoryRepository _efCategoryRepository;
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetCategoryById(int id)
        {
            return _categoryDal.GetByID(id);
        }

        public List<Category> ListAllCategory()
        {
            return _categoryDal.GetListAll();
        }
    }
}
