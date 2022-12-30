using BlogAlternative.EntityLayer.Concrete;
using System.Collections.Generic;

namespace BlogAlternative.DataAccessLayer.Abstract
{
    public interface IAllMessageDal:IGenericDal<AllMessage>
    {
        List<AllMessage> GetListWithMessageByWriter(int id);

    }
}
