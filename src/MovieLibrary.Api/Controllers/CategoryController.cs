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
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
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

        [HttpPost]
        public async Task<ActionResult<int?>> AddCategory([FromBody] CategoryCreateDTO category)
        {
            int? id = await _service.AddCategory(category);

            if (id is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(id);
            }
        }

        [HttpDelete("{categoryId}")]
        public async Task<ActionResult> DeleteCategory([FromRoute] int categoryId)
        {
            bool result = await _service.DeleteCategory(categoryId);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpPut]
        //public async Task<ActionResult<CategoryDTO>> UpdateCategory([FromBody] CategoryDTO category)
        //{
        //    var c = await _service.UpdateCategory(category);

        //    if (c != null)
        //    {
        //        return Ok(c);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
    }
}
