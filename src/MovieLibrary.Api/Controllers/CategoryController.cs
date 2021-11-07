using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.DTOs;
using MovieLibrary.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers
{
    [Route("v1/CategoryManagement")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById([FromRoute] int categoryId)
        {
            var category = await _service.GetCategoryByIdAsync(categoryId);

            if (category is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetMovies()
        {
            var categories = await _service.ListAsync();

            if (categories is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(categories);
            }
        }
    }
}
