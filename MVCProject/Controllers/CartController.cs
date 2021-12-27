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
    [Authorize]
    public class CartController : Controller
    {
        IProductService ps = new ProductManager(new EfProductDal());
        public ActionResult Index()
        {
            var totalMoney =GetCart().Total();
            ViewBag.total = totalMoney;
            return View(GetCart());
        }
        public ActionResult AddToCart(int id)   
        {
            var product = ps.GetByID(id);
            if (product!=null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("index", "product");
        }
        public ActionResult RemoveFromCart(int id)
        {
            var product = ps.GetByID(id);
            if (product != null)
            {
                GetCart().RemoveProduct(product);
            }
            return RedirectToAction("index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}