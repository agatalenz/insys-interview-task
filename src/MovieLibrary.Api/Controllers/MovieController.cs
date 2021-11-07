using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.DTOs;
using MovieLibrary.Core.Services;
using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers
{

    [Route("v1/MovieManagement")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<Movie>> GetMovieById([FromRoute] int movieId)
        {
            var movie = await _service.GetMovieByIdAsync(movieId);

            if (movie is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            var movies = _service.List();

            if (movies is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movies);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int?>> AddMovie([FromBody] MovieCreateDTO movie)
        {
            int? id = await _service.AddMovie(movie);

            if (id is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(id);
            }
        }

        [HttpDelete("{movieId}")]
        public async Task<ActionResult> DeleteMovie([FromRoute] int movieId)
        {
            bool result = await _service.DeleteMovie(movieId);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<ActionResult<Movie>> UpdateMovie([FromBody] Movie movie)
        {
            var c = await _service.UpdateMovie(movie);

            if (c != null)
            {
                return Ok(c);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
