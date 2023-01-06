using BlogAlternative.BusinessLayer.Abstract;
using BlogAlternative.DataAccessLayer.Abstract;
using BlogAlternative.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BlogAlternative.BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public List<Admin> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void TAdd(Admin t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Admin t)
        {
            throw new NotImplementedException();
        }

        public Admin TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Admin t)
        {
            throw new NotImplementedException();
        }
    }
}
