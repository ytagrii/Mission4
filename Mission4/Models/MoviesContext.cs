using System;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
            //leave blank fo rnow
        }

        public DbSet<Movies> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //seed 3 movies
            mb.Entity<Movies>().HasData(
                new Movies
                {
                    MovieId = 1,
                    Title = "Inception",
                    Category = "Action/Adventure",
                    Year = 2010,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new Movies
                {
                    MovieId = 2,
                    Title = "Spiderman No Way Home",
                    Category = "Action/Adventure",
                    Year = 2021,
                    Director = "Jon Watts",
                    Rating = "PG-13"
                },
                new Movies
                {
                    MovieId = 3,
                    Title = "1917",
                    Category = "War",
                    Year = 2019,
                    Director = "Sam Mendes",
                    Rating = "R"
                }
            );
        }
    }
}
