﻿using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repository
{
    public interface IProductPhotoRepository
    {
        Task<IEnumerable<ProductPhoto>> GetAllProductPhoto(bool trackChanges);

        Task<ProductPhoto> GetProductPhotoById(int photoId, bool trackChanges);

        void Insert(ProductPhoto productPhoto);

        void Edit(ProductPhoto productPhoto);

        void Remove(ProductPhoto productPhoto);
    }
}