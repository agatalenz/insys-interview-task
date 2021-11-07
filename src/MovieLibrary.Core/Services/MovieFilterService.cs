using Microsoft.EntityFrameworkCore;
using MovieLibrary.Core.DTOs;
using MovieLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services
{
    public class MovieFilterService : IMovieFilterService
    {
        private readonly IMovieRepository _repository;

        public MovieFilterService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var movie = await _repository
                                .List()
                                .Include(mc => mc.MovieCategories)
                                .ThenInclude(c => c.Category)
                                .SingleOrDefaultAsync(m => m.Id == id);

            return new MovieDTO(movie);
        }

        public async Task<IEnumerable<MovieDTO>> ListMoviesAsync()
        {
            var movies = await _repository
                                .List()
                                .Include(mc => mc.MovieCategories)
                                .ThenInclude(c => c.Category)
                                .ToListAsync();

            return from m in movies
                   select new MovieDTO(m);
        }
    }
}
