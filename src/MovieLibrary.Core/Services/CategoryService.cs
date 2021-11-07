using MovieLibrary.Core.DTOs;
using MovieLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MovieLibrary.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var c = await _repository.GetByIdAsync(id);
            if (c is null) return null;

            return new CategoryDTO()
            {
                Id = c.Id,
                Name = c.Name,
            };
        }

        public async Task<IEnumerable<CategoryDTO>> ListAsync()
        {
            var categories = _repository.List();
            if (categories is null) return null;

            return await (from c in categories
                    select new CategoryDTO()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToListAsync();
        }
    }
}
