using Northwind.Contracts.Dto.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface IOrderDetailsService
    {
        Task<IEnumerable<OrderDetailsDto>> GetAllOrderDetail(bool trackChanges);

        Task<OrderDetailsDto> GetOrderDetailById(int orderId, bool trackChanges);

        void Insert(OrderDetailsForCreateDto orderDetailsForCreateDto);

        void Edit(OrderDetailsDto orderDetailsDto);

        void Remove(OrderDetailsDto orderDetailsDto);
    }
}
