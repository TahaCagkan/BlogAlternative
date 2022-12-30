using BlogAlternative.DataAccessLayer.Abstract;
using BlogAlternative.DataAccessLayer.Concrete;
using BlogAlternative.DataAccessLayer.Repositories;
using BlogAlternative.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogAlternative.DataAccessLayer.EntiyFramework
{
    public class EfAllMessageRepository : GenericRepository<AllMessage>, IAllMessageDal
    {
        public List<AllMessage> GetListWithMessageByWriter(int id)
        {
            using (var value = new BlogAlternativeContext())
            {
                //Recevier kullanıcı recevier id olana listele
                return value.AllMessages.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }

       
    }
}
