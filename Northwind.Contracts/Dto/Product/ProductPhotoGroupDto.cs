using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.Product
{
    public class ProductPhotoGroupDto
    {
        public ProductForCreateDto ProductForCreateDto { get; set; }
       /* [Required]
        public IFormFile Photo1 { get; set; }
        [Required]
        public IFormFile Photo2 { get; set; }
        [Required]
        public IFormFile Photo3 { get; set; }*/
        [Required]
        public List<IFormFile> AllPhoto { get; set; }

    }
}
