using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.DTOs;
using MovieLibrary.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers
{
    [Route("v1/Movie/Filter")]
    [ApiController]
    public class MovieFilterController : ControllerBase
    {
        private readonly IMovieFilterService _service;

        public MovieFilterController(IMovieFilterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies(int page = 0, int moviesPerPage = 5, string text = "", [FromQuery] int[] categories = null, double minImdb = 0, double maxImdb = 10 )
        {
            var movies = await _service.ListMoviesAsync(page, moviesPerPage, text, categories, minImdb, maxImdb);

            if (movies is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movies);
            }
        }
    }
}
