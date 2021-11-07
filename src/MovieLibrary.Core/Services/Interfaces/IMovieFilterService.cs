using MovieLibrary.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services
{
    public interface IMovieFilterService
    {
        Task<IEnumerable<MovieDTO>> ListMoviesAsync(int page, int moviesPerPage, string text, int[] categories, double minImdb, double maxImdb);
        Task<IEnumerable<MovieDTO>> ListMoviesAsync(string text, int[] categories, double minImdb, double maxImdb);
    }
}
