using MovieLibrary.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Services
{
    public interface IMovieService
    {
        Task<MovieDTO> GetMovieByIdAsync(int id);
        Task<IEnumerable<MovieDTO>> ListAsync();
        Task<int> AddMovie(MovieCreateDTO movie);
        Task<bool> DeleteMovie(int id);
        Task<MovieDTO> UpdateMovie(MovieDTO movie);
    }
}
