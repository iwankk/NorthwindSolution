﻿using Northwind.Domain.Base;
using Northwind.Domain.Repositories;
using Northwind.Domain.Repository;
using Northwind.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Base
{
    public class RepositoryManager : IRepositoryManager
    {
        private NorthwindContext _dbContext;
        private ICategoryRepository _categoryRepository;
        private ICustomerRepository _customerRepository;
        private IProductRepository _productRepository;
        private IProductPhotoRepository _productPhotoRepository;

        public RepositoryManager(NorthwindContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_dbContext);
                }
                return _categoryRepository;
            }
        }

        /// <summary>
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                {
                    _customerRepository = new CustomerRepository(_dbContext);
                }
                return _customerRepository;
            }
        }
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_dbContext);
                }
                return _productRepository;
            }
        }

        public IProductPhotoRepository ProductPhotoRepository
        {
            get
            {
                if (_productPhotoRepository == null)
                {
                    _productPhotoRepository = new ProductPhotoRepository(_dbContext);
                }
                return _productPhotoRepository;
            }
        }

        public void Save() => _dbContext.SaveChanges();

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}