using MovieLibrary.Core.DTOs;
using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryByIdAsync(int id);
        IQueryable<Category> List();
        //Task<IEnumerable<Category>> ListAsync();
        Task<int?> AddCategory(string name);
        Task<bool> DeleteCategory(int id);
        Task<Category> UpdateCategory(Category category);
    }
}
