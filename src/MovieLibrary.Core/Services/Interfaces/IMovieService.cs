using MovieLibrary.Core.DTOs;
using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services
{
    public interface IMovieService
    {
        Task<Movie> GetMovieByIdAsync(int id);
        IEnumerable<Movie> List();
        Task<int> AddMovie(MovieCreateDTO movie);
        Task<bool> DeleteMovie(int id);
        Task<Movie> UpdateMovie(Movie movie);
    }
}
