using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());        
        IUserService us = new UserManager(new EfUserDal());        
        public ActionResult Index()
        {
            var list = pm.GetList();
            return View(list);
        }        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {            
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Add(Product p)
        {
            pm.ProductAddBL(p);            
            return RedirectToAction("add","product");
        }
        [HttpGet]
        [Authorize]
        public ActionResult AddByUser()
        {   
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddByUser(Product p)
        {
            var userMail = HttpContext.User.Identity.Name;
            var user = us.GetByMail(userMail);
            var userIdProductAdded = user.Id;
            p.UserId = userIdProductAdded;
            pm.ProductAddBL(p);
            return RedirectToAction("AddByUser", "product");
        }
        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userMail = HttpContext.User.Identity.Name;
            var user = us.GetByMail(userMail);
            var value = pm.GetByID(id);
            if (user.Id==value.UserId || userMail == "admin@admin.com")
            {
                return View(value);
            }
            return RedirectToAction("index", "product");
        }
        [HttpPost]
        [Authorize]
        public ActionResult Edit(Product p)
        {
            pm.ProductUpdateBL(p);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AllProduct()
        {            
            return View();
        }
        
        public ActionResult GetList()
        {
            var productList = pm.GetList();            
            return Json(new { data = productList }, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetListbyCategoryId(int id)
        {
            var productList = pm.GetByCategoroyId(id);
            return View(productList);
        }
        [HttpGet]
        [Authorize]
        public ActionResult MyProduct()
        {
            var UserMail = HttpContext.User.Identity.Name;
            var User = us.GetByMail(UserMail);
            var userId = User.Id;
            var List = pm.GetByUserId(userId);
            return View(List);
        }


    }
}