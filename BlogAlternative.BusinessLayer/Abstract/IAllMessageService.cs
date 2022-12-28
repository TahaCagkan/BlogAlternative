using BlogAlternative.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogAlternative.BusinessLayer.Abstract
{
    public interface IAllMessageService:IGenericService<AllMessage>
    {
        public List<AllMessage> GetInboxListByWriter(int Id);

    }
}
