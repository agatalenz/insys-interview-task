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
            var m = await _repository.GetByIdAsync(id);
            if (m is null) return null;

            return new MovieDTO()
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Year = m.Year,
                ImdbRating = m.ImdbRating,
                Categories = from mc in m.MovieCategories
                             select new CategoryDTO()
                             {
                                 Id = mc.CategoryId,
                                 Name = mc.Category.Name
                             },
            };
        }

        public async Task<IEnumerable<MovieDTO>> ListAsync()
        {
            var movies = await _repository.ListAsync();
            if (movies is null) return null;

            return from m in movies
                   select new MovieDTO()
                   {
                        Id = m.Id,
                        Title = m.Title,
                        Description = m.Description,
                        Year = m.Year,
                        ImdbRating = m.ImdbRating,
                        Categories = from mc in m.MovieCategories
                                     select new CategoryDTO()
                                     {
                                         Id = mc.CategoryId,
                                         Name = mc.Category.Name
                                     },
                   };
        }
    }
}
