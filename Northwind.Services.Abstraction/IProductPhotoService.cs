using Northwind.Contracts.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface IProductPhotoService
    {
        Task<IEnumerable<ProductPhotoDto>> GetAllProductPhoto(bool trackChanges);

        Task<ProductPhotoDto> GetProductPhotoById(string photoId, bool trackChanges);

        void Insert(ProductPhotoForCreateDto productPhotoCreatDto);

        void Edit(ProductPhotoDto productPhotoDto);

        void Remove(ProductPhotoDto productPhotoDto);
    }
}
