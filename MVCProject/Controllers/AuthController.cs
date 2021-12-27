using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProject.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {        
        IUserService us = new UserManager(new EfUserDal());
        [HttpGet]        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            var loginUser = us.GetLogin(u.Email,u.Password);
             
            if (loginUser!=null)
            {
                ViewBag.LoginUserName = loginUser.Name;
                FormsAuthentication.SetAuthCookie(u.Email, u.RememberMe);
                if (loginUser.Authority=="Admin")
                {
                    return RedirectToAction("index", "Dashboard");
                }
                return RedirectToAction("index", "Product");
            }
            else
            {
                ViewBag.ErrorLogin = "E-mail veya şifre hatalı!";
                return View();
            }            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User u)
        {
            u.Authority = "User";
            us.AddBL(u);
            return RedirectToAction("Login", "Auth");
        }
    }
}