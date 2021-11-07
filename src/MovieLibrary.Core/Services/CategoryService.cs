using MovieLibrary.Core.DTOs;
using MovieLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int?> AddCategory(CategoryCreateDTO category)
        {
            var exist = await _repository.ExistAsync(category.Name);
            if (exist) return null;

            return await _repository.CreateAsync(new Category() 
            {
                Name = category.Name
            });
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null) return false;

            await _repository.DeleteAsync(category);
            return true;
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null) return null;

            return new CategoryDTO(category);
        }

        public async Task<IEnumerable<CategoryDTO>> ListAsync()
        {
            var categories = _repository.List();
            if (categories is null) return null;

            return await (from c in categories
                        select new CategoryDTO(c))
                        .ToListAsync();
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO c)
        {
            var category = await _repository.GetByIdAsync(c.Id);
            if (category is null) return null;

            var exist = await _repository.ExistAsync(c.Name);
            if (exist) return null;

            category.Name = c.Name;

            await _repository.UpdateAsync(category);
            return await GetCategoryByIdAsync(category.Id);
        }
    }
}
