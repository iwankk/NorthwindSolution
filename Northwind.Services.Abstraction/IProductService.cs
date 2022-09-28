using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Contracts.Dto.Product;


namespace Northwind.Services.Abstraction
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges);

        Task<ProductDto> GetProductById(int ProductId, bool trackChanges);

        Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize,bool trackChanges);

        ProductDto CreateProductDto(ProductForCreateDto productForCreateDto);
        void Insert(ProductForCreateDto productForCreateDto);
        void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, List<ProductPhotoForCreateDto> productPhotoCreateDtos);

        void Edit(ProductDto productDto);

        void Remove(ProductDto productDto);
    }
}
