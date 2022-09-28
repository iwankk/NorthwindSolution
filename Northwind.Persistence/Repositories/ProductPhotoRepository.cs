using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Models;
using Northwind.Domain.Repositories;
using Northwind.Domain.Repository;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    public class ProductPhotoRepository : RepositoryBase<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(NorthwindContext dbContext) : base(dbContext)
        {
        }

        public void Edit(ProductPhoto productPhoto)
        {
            Update(productPhoto);
        }

        public async Task<IEnumerable<ProductPhoto>> GetAllProductPhoto(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.PhotoId)
                .Include(p =>p.PhotoProduct)
                .ToListAsync();
        }

        public async Task<ProductPhoto> GetProductPhotoById(int photoId, bool trackChanges)
        {
            return await FindByCondition(c => c.PhotoId.Equals(photoId), trackChanges)
                .Include(p => p.PhotoProduct)
                .SingleOrDefaultAsync();
        }

        public void Insert(ProductPhoto productPhoto)
        {
            Create(productPhoto);
        }

        public void Remove(ProductPhoto productPhoto)
        {
            Delete(productPhoto);
        }
    }
}
