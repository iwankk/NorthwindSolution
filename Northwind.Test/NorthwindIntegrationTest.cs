using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Contracts.Dto.Category;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Persistence;
using Northwind.Persistence.Base;
using Northwind.Services;
using Northwind.Services.Abstraction;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Northwind.Test.Mapping
{
    public class NorthwindIntegrationTest
    {
        private static IConfigurationRoot Configuration;
        private static DbContextOptionsBuilder<NorthwindContext> optionsBuilder;
        private static MapperConfiguration mapperConfig;
        private static IMapper mapper;
        private static IServiceProvider serviceProvider;
        private static IRepositoryManager _reporitoryManager;

        public NorthwindIntegrationTest()
        {
            BuildConfiguration();
            setupOption();
        }


        /// Testing Layer Service Create
        [Fact]
        public void TestGetCategoryServiceInsert()
        {
            using (var context = new NorthwindContext(optionsBuilder.Options))
            {
                //act
                _reporitoryManager = new RepositoryManager(context);
                IServiceManager serviceManager = new ServiceManager(_reporitoryManager, mapper);
                
                //define category
                var categoryDto = new CategoryForCreateDto
                {
                    CategoryName = "Bleace",
                    Description = "History Movie"
                };

                serviceManager.CategoryService.Insert(categoryDto);
                _reporitoryManager.Save();



                //define category
                var category = serviceManager.CategoryService.GetAllCategory(false);

                //asset
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(13);

            }
        }
        /// Testing Layer Repo Get All
        [Fact]
        public void TestGetCategoryRepo()
        {
            using (var context = new NorthwindContext(optionsBuilder.Options))
            {
                //act
                _reporitoryManager = new RepositoryManager(context);
                var category = _reporitoryManager.CategoryRepository.GetAllCategory(false);


                //asset
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(8);
            }
        }

        /// Testing Layer Repo Insert
        [Fact]
        public void TestGetCategoryRepoInsert()
        {
            using (var context = new NorthwindContext(optionsBuilder.Options))
            {
                //act
                _reporitoryManager = new RepositoryManager(context);

                //define category
                var categoryModel = new Category
                {
                    CategoryName = "Jujutsu Kaizen",
                    Description = "Adventure Movie"
                };

                _reporitoryManager.CategoryRepository.Insert(categoryModel);
                _reporitoryManager.Save();

                //asset
                var category = _reporitoryManager.CategoryRepository.GetAllCategory(false);
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(16);

            }
        }


        /// Testing Layer Service Get All
        [Fact]
        public void TestGetCategoryService()
        {
            using (var context = new NorthwindContext(optionsBuilder.Options))
            {
                //act
                _reporitoryManager = new RepositoryManager(context); 
                IServiceManager serviceManager = new ServiceManager(_reporitoryManager, mapper);

                //define category
                var category = serviceManager.CategoryService.GetAllCategory(false);

                //asset
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(13);

            }
        }

        private void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        private void setupOption()
        {
            optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("NorthwindDB"));

            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(MappingProfile));
            serviceProvider = services.BuildServiceProvider();

            mapperConfig = new MapperConfiguration(cfg =>
             {
                 cfg.AddProfile<MappingProfile>();

             });
            mapperConfig.AssertConfigurationIsValid();
            mapper = mapperConfig.CreateMapper();

        }

    }
}
