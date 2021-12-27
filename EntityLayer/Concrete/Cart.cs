using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> cartLines
        {
            get { return _cartLines; }
        }
        public void AddProduct(Product p,int q)
        {
            var line = _cartLines.FirstOrDefault(i => i.product.Id == p.Id);
            if (line == null)
            {
                _cartLines.Add(new CartLine() { product = p, quantity = q });
            }
            else
            {
                line.quantity += q;
            }
        }
        public void RemoveProduct(Product p)
        {
            //_cartLines.RemoveAll(i => i.product.Id == p.Id);
            var line = _cartLines.FirstOrDefault(i => i.product.Id == p.Id);
            if (line.quantity == 1)
            {
                _cartLines.RemoveAll(i => i.product.Id == p.Id);
            }
            else
            {
                line.quantity -=1;
            }
        }
        public double Total()
        {
            return _cartLines.Sum(i => i.product.UnitPrice * i.quantity);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }
    }
    public class CartLine
    {
        public Product product { get; set; }
        public int quantity { get; set; }
    }
}
