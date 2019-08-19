using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Genres{ get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}
