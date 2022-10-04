﻿using AutoMapper;
using Northwind.Contracts.Dto.Product;
using Northwind.Contracts.Dto.Supplier;
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
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public ProductDto CreateProductId(ProductForCreateDto productForCreateDto)
        {
            var productModel = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productModel);
            _repositoryManager.Save();
            var productDto = _mapper.Map<ProductDto>(productModel);
            return productDto;
        }

        public void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, 
            List<ProductPhotoCreateDto> productPhotoCreateDtos)
        {
            //throw new NotImplementedException();
            var productModel = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(productModel);
            _repositoryManager.Save();
            foreach (var item in productPhotoCreateDtos)
            {
                item.PhotoProductId = productModel.ProductId;
                var photoModel = _mapper.Map<ProductPhoto>(item);
                _repositoryManager.ProductPhotoRepository.Insert(photoModel);
            }
            _repositoryManager.Save();
        }

        public void Edit(ProductDto productDto)
        {
            var edit = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetAllProduct(trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public async Task<ProductDto> GetProductById(int productId, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductById(productId, trackChanges);
            var productDto = _mapper.Map<ProductDto>(productModel);
            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges)
        {
            var productModel = await _repositoryManager.ProductRepository.GetProductPaged(pageIndex, pageSize, trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        

        //tambahan edit
        public async Task<ProductPhotoGroupDto> GetProductPhotoGroupById(int productId, bool trackChange)
        {
            //throw new NotImplementedException();
            var productModel = await _repositoryManager.ProductPhotoRepository.GetProductPhotoById(productId, trackChange);
            var productDto = _mapper.Map<ProductPhotoGroupDto>(productModel);
            return productDto;
        }

        public async Task<ProductPhotoDto> GetProductPhotoById(int productId, bool trackChange)
        {
            // throw new NotImplementedException();
            var productModel = await _repositoryManager.ProductPhotoRepository.GetProductPhotoById(productId, trackChange);
            var productDto = _mapper.Map<ProductPhotoDto>(productModel);
            return productDto;
        }
        //batas tambahan edit

        public void Insert(ProductForCreateDto productForCreateDto)
        {
            var insert = _mapper.Map<Product>(productForCreateDto);
            _repositoryManager.ProductRepository.Insert(insert);
            _repositoryManager.Save();
        }

        public void Remove(ProductDto productDto)
        {
            var remove = _mapper.Map<Product>(productDto);
            _repositoryManager.ProductRepository.Remove(remove);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<ProductDto>> GetProductOneSales(bool trackChanges)
        {
            //throw new NotImplementedException();
            var productModel = await _repositoryManager.ProductRepository.GetProductsOnSales(trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(productModel);
            return productDto;
        }

        public async Task<ProductDto> GetProductSalesById(int productId, bool trackChanges)
        {
            //throw new NotImplementedException();
            var productDto = await _repositoryManager.ProductRepository.GetProductSalesById(productId,trackChanges);
            var productModel =  _mapper.Map<ProductDto>(productDto);
            return productModel;
        }
    }
}
