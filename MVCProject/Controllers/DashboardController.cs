using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class DashboardController : Controller
    {
        IProductService pm = new ProductManager(new EfProductDal());
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllProduct()
        {
            return View();
        }        

        public ActionResult GetList()
        {
            var productList = pm.GetList();
            return Json(new { data = productList }, JsonRequestBehavior.AllowGet);
        }
    }
}