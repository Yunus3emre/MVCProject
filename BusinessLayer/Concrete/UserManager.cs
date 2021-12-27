using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal UserDal)
        {
            _userDal = UserDal;
        }
        public void AddBL(User u)
        {
            _userDal.Insert(u);
        }

        public void ContentDeleteBL(User content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdateBL(User content)
        {
            throw new NotImplementedException();
        }

        public User GetByID(int id)
        {
            return _userDal.Get(x => x.Id == id);
        }

        public User GetByMail(string mail)
        {
            return _userDal.Get(x => x.Email == mail);
        }

        public List<User> GetList()
        {
            throw new NotImplementedException();
        }

        public List<User> GetListByID(int id)
        {
            throw new NotImplementedException();
        }

        public User GetLogin(string mail, string password)
        {
            return _userDal.Get(x => x.Email == mail && x.Password == password);
        }

        public User GetRoles(string mail)
        {
            return _userDal.Get(x => x.Email == mail);
        }
    }
}
