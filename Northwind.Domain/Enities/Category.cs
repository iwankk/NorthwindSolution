using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Enities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Required]
        [StringLength (50, ErrorMessage ="Description Canot be longer than 50")]

        public string Description { get; set; } 
        
        public string Photo { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
