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

        public async Task<int?> AddCategory(string name)
        {
            var exist = await _repository.ExistAsync(name);
            if (exist) return null;

            return await _repository.CreateAsync(new Category() 
            {
                Name = name
            });
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null) return false;

            await _repository.DeleteAsync(category);
            return true;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IQueryable<Category> List()
        {
            return _repository.List();
        }

        public async Task<Category> UpdateCategory(Category c)
        {
            var category = await _repository.GetByIdAsync(c.Id);
            if (category is null) return null;

            var exist = await _repository.ExistAsync(c.Name);
            if (exist) return null;

            category.Name = c.Name;
            return await _repository.UpdateAsync(category);
        }
    }
}
