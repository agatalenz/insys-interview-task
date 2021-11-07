﻿using System;
using System.Collections.Generic;
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
    }
}
