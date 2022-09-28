using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Northwind.Contracts.Dto.Category;


namespace Northwind.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategory(bool trackChanges);

        Task<CategoryDto> GetCategoryById(string customerId, bool trackChanges);

        void Insert(CategoryForCreateDto categoryForCreateDto);

        void Edit(CategoryDto categoryDto);

        void Remove(CategoryDto categoryDto);
    }
}
