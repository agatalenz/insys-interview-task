using MovieLibrary.Core.DTOs;
using MovieLibrary.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddMovie(MovieCreateDTO movie)
        {
            return await _repository.CreateAsync(new Movie()
            {
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                ImdbRating = movie.ImdbRating,
            });
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            if (movie is null) return false;

            await _repository.DeleteAsync(movie);
            return true;
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IEnumerable<Movie> List()
        {
            return _repository.List();
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var m = await _repository.GetByIdAsync(movie.Id);
            if (m is null) return null;

            m.Title = movie.Title;
            m.Description = movie.Description;
            m.Year = movie.Year;
            m.ImdbRating = movie.ImdbRating;

            return await _repository.UpdateAsync(m);
        }
    }
}
