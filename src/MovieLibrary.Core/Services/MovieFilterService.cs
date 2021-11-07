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

        public async Task<IEnumerable<MovieDTO>> ListMoviesAsync(int page, int moviesPerPage, string text, int[] categories, double minImdb, double maxImdb)
        {
            var movies = await ListMoviesAsync(text, categories, minImdb, maxImdb);
            if (page < 1) return movies;

            try
            {
                return movies.Skip((page - 1) * moviesPerPage).Take(moviesPerPage);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<MovieDTO>> ListMoviesAsync(string text, int[] categories, double minImdb, double maxImdb)
        {
            var movies = await _repository
                .List()
                .OrderByDescending(m => (double)m.ImdbRating)
                .Include(mc => mc.MovieCategories)
                .ThenInclude(c => c.Category)
                .Select(m => new MovieDTO(m))
                .ToListAsync();

            return movies.Where(m =>
                                m.Title.Contains(text) && 
                                (!categories.Any() || m.Categories.Any(c => categories.Contains(c.Id))) && 
                                (double)m.ImdbRating >= minImdb && (double)m.ImdbRating <= maxImdb);
        }
    }
}
