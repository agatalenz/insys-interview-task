using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repositories
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(MovieLibraryContext context) : base(context) { }

        public async override Task<Movie> GetByIdAsync(int id)
            => await List()
                    .Include(mc => mc.MovieCategories)
                    .ThenInclude(c => c.Category)
                    .SingleOrDefaultAsync(m => m.Id == id);

        public async Task<IEnumerable<Movie>> ListAsync()
        => await List()
                .Include(mc => mc.MovieCategories)
                .ThenInclude(c => c.Category)
                .ToListAsync();
    }
}
