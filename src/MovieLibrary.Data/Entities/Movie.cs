using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieLibrary.Data.Entities
{
    public class Movie : EntityBase
    {
        public Movie()
        {
            this.MovieCategories = new List<MovieCategory>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public decimal ImdbRating { get; set; }

        [JsonIgnore]
        public virtual ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
