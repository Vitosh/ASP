using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry met Sally",
                        ReleaseDate = DateTime.Parse("1989-01-01"),
                        Genre = "Romantic Comedy",
                        Price = 7
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1994-01-01"),
                        Genre = "Comedy",
                        Price = 10
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1996-01-01"),
                        Genre = " Comedy",
                        Price = 12
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1999-01-01"),
                        Genre = "Western",
                        Price = 6
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
