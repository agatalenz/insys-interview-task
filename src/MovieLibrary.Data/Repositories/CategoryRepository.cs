using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(MovieLibraryContext context) : base(context) { }

        public async Task<bool> ExistAsync(string name)
            => await _context.Categories.AnyAsync(c => c.Name == name);
    }
}
