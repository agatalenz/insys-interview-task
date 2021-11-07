using MovieLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary.Core.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal ImdbRating { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }

        public MovieDTO(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Description = movie.Description;
            Year = movie.Year;
            ImdbRating = movie.ImdbRating;
            Categories = movie.MovieCategories.Select(mc => new CategoryDTO() { Id = mc.CategoryId, Name = mc.Category.Name });
        }
    }
}
