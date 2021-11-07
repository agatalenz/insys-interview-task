using MovieLibrary.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryDTO>> ListAsync();
        Task<int?> AddCategory(CategoryCreateDTO category);
        Task<bool> DeleteCategory(int id);
        Task<CategoryDTO> UpdateCategory(CategoryDTO category);
    }
}
