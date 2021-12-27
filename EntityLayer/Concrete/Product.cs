using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageFile { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }        
        public int  CategoryId { get; set; }
        public Category Category { get; set; }
        public int  UserId { get; set; }        
    }
}
