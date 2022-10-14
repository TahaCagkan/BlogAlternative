using BlogAlternative.DataAccessLayer.Abstract;
using BlogAlternative.DataAccessLayer.Repositories;
using BlogAlternative.EntityLayer.Concrete;

namespace BlogAlternative.DataAccessLayer.EntiyFramework
{
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
    }
}
