using AutoMapper;
using Northwind.Contracts.Dto.Product;
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
    public class ProductPhotoService : IProductPhotoService
    {
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductPhotoService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(ProductPhotoDto productPhotoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges)
        {
            var categoryModel = await _repositoryManager.ProductPhotoRepository.GetAllProductPhoto(trackChanges);
            //source = Category model, target Category Dto
            var productPhotoDto = _mapper.Map<IEnumerable<ProductPhotoDto>>(categoryModel);
            return productPhotoDto;
        }

        public Task<ProductPhotoDto> GetProductPhotoById(string photoId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductPhotoForCreateDto productPhotoCreatDto)
        {
            var productPhotoModel = _mapper.Map<ProductPhoto>(productPhotoCreatDto);
            _repositoryManager.ProductPhotoRepository.Insert(productPhotoModel);
            _repositoryManager.Save();
        }

        public void Remove(ProductPhotoDto productPhotoDto)
        {
            throw new NotImplementedException();
        }
    }
}
