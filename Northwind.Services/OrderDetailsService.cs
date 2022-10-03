using AutoMapper;
using Northwind.Contracts.Dto.OrderDetail;
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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public OrderDetailsService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(OrderDetailsDto orderDetailsDto)
        {
            var edit = _mapper.Map<OrderDetail>(orderDetailsDto);
            _repositoryManager.OrderDetailsRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<OrderDetailsDto>> GetAllOrderDetail(bool trackChanges)
        {
            var orderModel = await _repositoryManager.OrderDetailsRepository.GetAllOrderDetail(trackChanges);
            var orderDetailDto = _mapper.Map<IEnumerable<OrderDetailsDto>>(orderModel);
            return orderDetailDto;
        }

        public async Task<OrderDetailsDto> GetOrderDetailById(int orderId, bool trackChanges)
        {
            var orderModel = await _repositoryManager.OrderDetailsRepository.GetOrderDetailById(orderId, trackChanges);
            var orderDetailDto = _mapper.Map<OrderDetailsDto>(orderModel);
            return orderDetailDto;
        }

        public void Insert(OrderDetailsForCreateDto orderDetailsForCreateDto)
        {
            var insert = _mapper.Map<OrderDetail>(orderDetailsForCreateDto);
            _repositoryManager.OrderDetailsRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(OrderDetailsDto orderDetailsDto)
        {
            var remove = _mapper.Map<OrderDetail>(orderDetailsDto);
            _repositoryManager.OrderDetailsRepository.Remove(remove);
            _repositoryManager.Save();
        }
    }
}
