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
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;

        public ProductManager(IProductDal ProductDal)
        {
            _ProductDal = ProductDal;
        }

        public void ProductAddBL(Product p)
        {
            _ProductDal.Insert(p);
        }

        public void ProductDeleteBL(Product p)
        {
            _ProductDal.Delete(p);
        }

        public void ProductUpdateBL(Product p)
        {
            _ProductDal.Update(p);
        }

        public Product GetByID(int id)
        {
            return _ProductDal.Get(x => x.Id == id);
        }

        public List<Product> GetList()
        {
            return _ProductDal.List();
        }

        public List<Product> GetListByID(int id)
        {
            return _ProductDal.List(x => x.Id == id);
        }        
        public List<Product> GetByCategoroyId(int id)
        {
            return _ProductDal.List(x => x.CategoryId==id);
        }

        public List<Product> GetByUserId(int id)
        {
            return _ProductDal.List(x => x.UserId == id);
        }
    }
}
