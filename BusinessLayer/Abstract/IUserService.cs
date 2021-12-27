using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<User> GetList();
        List<User> GetListByID(int id);
        void AddBL(User content);
        User GetByID(int id);
        User GetByMail(string mail);
        void ContentDeleteBL(User content);
        void ContentUpdateBL(User content);
        User GetLogin(string mail,string password);
        User GetRoles(string mail);
    }
}
