using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        List<Product> GetListByID(int id);
        void ProductAddBL(Product p);
        Product GetByID(int id);
        void ProductDeleteBL(Product p);
        void ProductUpdateBL(Product p);
        List<Product> GetByCategoroyId(int id);
        List<Product> GetByUserId(int id);
    }
}
