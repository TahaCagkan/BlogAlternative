using BlogAlternative.BusinessLayer.Abstract;
using BlogAlternative.DataAccessLayer.Abstract;
using BlogAlternative.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BlogAlternative.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public List<Comment> GetCommentListByID(int id)
        {
            return _commentDal.GetListAll(x => x.BlogID == id);
        }

        public List<Comment> GetListAll()
        {
            return _commentDal.GetListAll();
        }

        public void TAdd(Comment t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Comment t)
        {
            throw new NotImplementedException();
        }

        public Comment TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
