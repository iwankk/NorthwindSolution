using AutoMapper;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Northwind.Services
{
    public class ProductService : IProductService
    {
        //2 private dibawah kemudian di block kemudian ctrl + . (dot) generate constructor
        private IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        
        //defedency injection
        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetAllProduct(trackChanges);
            //source = Category model, target Category Dto
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public Task<ProductDto> GetProductById(int productId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProductForCreateDto categoryForCreateDto)
        {
            var productPhotoModel = _mapper.Map<Product>(categoryForCreateDto);
            _repositoryManager.ProductRepository.Insert(productPhotoModel);
            _repositoryManager.Save();
        }

        public void Remove(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductPaged(pageIndex,pageSize,trackChanges);
            //source = Category model, target Category Dto
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public ProductDto CreateProductDto(ProductForCreateDto productForCreateDto)
        {
            var productModel = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productModel);
            _repositoryManager.Save();
            var productDto = _mapper.Map<ProductDto>(productModel);
            return productDto;
        }

        public void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, List<ProductPhotoForCreateDto> productPhotoCreateDtos)
        {
            //1. Insert into table products
            var productModel = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productModel);
            _repositoryManager.Save();

            //2.  insert into table productphotos
            foreach (var item in productPhotoCreateDtos)
            {
                item.PhotoProductId = productModel.ProductId;
                var photoModel = _mapper.Map<ProductPhoto>(item);
                _repositoryManager.ProductPhotoRepository.Insert(photoModel);
            }
            _repositoryManager.Save();

        }

    }
}
