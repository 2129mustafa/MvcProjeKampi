using BusinessLayer.Abstract;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        SHA1 sha = new SHA1CryptoServiceProvider();
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void AdminAdd(Admin admin)
        {
            string pass = admin.AdminPassword;
            string email = admin.AdminUserName;
            string key = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(pass)));
            string mail = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(email)));
            admin.AdminPassword = key;
            admin.AdminUserName = mail;
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public Admin GetByUserName(string UserName)
        {
            return _adminDal.Get(x => x.AdminUserName == UserName);
        }

        public Admin GetByUserNamePassword(string UserName, string Password)
        {
            return _adminDal.Get(x => x.AdminUserName == UserName && x.AdminPassword == Password);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public bool log(string user, string password)
        {
            var admin = _adminDal.Get(x => x.AdminUserName == user && x.AdminPassword == password);
            return admin == null ? false : true;
        }
    }
}
