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

        public List<AllMessage> GetInboxListByWriter(int Id)
        {
            //alıcının string değerini eşitledik
            return _messageDal.GetListAll(x => x.ReceiverID == Id);
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
            throw new NotImplementedException();
        }

        public void TUpdate(AllMessage t)
        {
            throw new NotImplementedException();
        }

 
    }
}
