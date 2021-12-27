using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }        
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool RememberMe { get; set; }
        [Required]
        public string Password { get; set; }
        public string Authority { get; set; }
        [NotMapped]
        public string FullName { get { return $"{Name} {LastName}"; } set { } }
        public List<Product> Products { get; set; }       
    }
}
