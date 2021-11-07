using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieLibrary.Data.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            this.MovieCategories = new List<MovieCategory>();
        }

        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
