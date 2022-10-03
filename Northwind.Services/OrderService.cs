using AutoMapper;
using Northwind.Contracts.Dto.Order;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(OrderDto orderDto)
        {
            var edit = _mapper.Map<Order>(orderDto);
            _repositoryManager.OrdersRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrder(bool trackChanges)
        {
            var orderModel = await _repositoryManager.OrdersRepository.GetAllOrder(trackChanges);
            var orderDto = _mapper.Map<IEnumerable<OrderDto>>(orderModel);
            return orderDto;
        }
    

        public async Task<OrderDto> GetOrderById(int orderId, bool trackChanges)
        {
            var orderModel = await _repositoryManager.OrdersRepository.GetOrderById(orderId, trackChanges);
            var orderDto = _mapper.Map<OrderDto>(orderModel);
            return orderDto;
            
        }

        public void Insert(OrderForCreateDto orderForCreateDto)
        {
            var insert = _mapper.Map<Order>(orderForCreateDto);
            _repositoryManager.OrdersRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(OrderDto orderDto)
        {
            var remove = _mapper.Map<Order>(orderDto);
            _repositoryManager.OrdersRepository.Remove(remove);
            _repositoryManager.Save();
        }
    }
}
