using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCApp.Data;
using System;
using System.Linq;

namespace MVCApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<MVCAppContext>>()))
            {
                //Look for any Movies
                if (context.Movie.Any())
                {
                    return; //Db has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Iron Man",
                        ReleaseDate = DateTime.Parse("2006-05-04"),
                        Genre = "Action",
                        Price = 7.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "The king lion",
                        ReleaseDate = DateTime.Parse("1992-05-04"),
                        Genre = "Animete",
                        Price = 1.88M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Toy Story",
                        ReleaseDate = DateTime.Parse("1999-01-01"),
                        Genre = "Animete",
                        Price = 2.75M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-04-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "R"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
