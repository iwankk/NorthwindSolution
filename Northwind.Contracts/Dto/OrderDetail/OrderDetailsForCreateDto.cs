﻿using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Contracts.Dto.OrderDetail
{
    public class OrderDetailsForCreateDto
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual OrderDto OrderDto { get; set; }
        public virtual ProductDto ProductDto { get; set; }
    }
}
