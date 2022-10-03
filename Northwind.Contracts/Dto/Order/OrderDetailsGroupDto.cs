using Northwind.Contracts.Dto.OrderDetail;
using Northwind.Contracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.Order
{
    public class OrderDetailsGroupDto
    {
        public OrderForCreateDto OrderForCreateDto { get; set; }
        public OrderDetailsForCreateDto orderDetailsForCreateDto { get; set; }
        public ProductDto productDto { get; set; }
    }
}
