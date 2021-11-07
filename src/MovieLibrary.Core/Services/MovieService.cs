using MovieLibrary.Core.DTOs;
using MovieLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieLibrary.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            if (movie is null) return null;

            return new MovieDTO(movie);
        }

        public async Task<IEnumerable<MovieDTO>> ListAsync()
        {
            var movies = await _repository.ListAsync();
            if (movies is null) return null;

            return from m in movies
                   select new MovieDTO(m);
        }
    }
}
