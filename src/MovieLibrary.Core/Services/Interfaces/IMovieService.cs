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
    }
}
