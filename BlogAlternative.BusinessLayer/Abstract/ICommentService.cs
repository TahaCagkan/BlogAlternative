using BlogAlternative.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogAlternative.BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);
        //void CategoryDelete(Category category);
        //void CategoryUpdate(Category category);
        List<Comment> GetCommentListByID(int id);
        //Category GetCategoryById(int id);
    }
}
