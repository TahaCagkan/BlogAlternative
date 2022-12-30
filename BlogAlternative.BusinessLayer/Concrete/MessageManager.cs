using BlogAlternative.BusinessLayer.Abstract;
using BlogAlternative.DataAccessLayer.Abstract;
using BlogAlternative.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BlogAlternative.BusinessLayer.Concrete
{
    public class MessageManager : IAllMessageService
    {
        IAllMessageDal _messageDal;
        public MessageManager(IAllMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<AllMessage> GetInboxListByWriter(int id)
        {
            //alıcının string değerini eşitledik
            return _messageDal.GetListWithMessageByWriter(id);
        }

        public List<AllMessage> GetListAll()
        {
            return _messageDal.GetListAll();
        }
       
        public void TAdd(AllMessage t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AllMessage t)
        {
            throw new NotImplementedException();
        }

        public AllMessage TGetById(int id)
        {
            return _messageDal.GetByID(id);
        }

        public void TUpdate(AllMessage t)
        {
            throw new NotImplementedException();
        }

 
    }
}
