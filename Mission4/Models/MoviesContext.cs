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
        public DbSet<Category> categories { get; set; }
        //public DbSet<Director> directors { get; set; }
        public DbSet<Rating> ratings { get; set; }
            protected override void OnModelCreating(ModelBuilder mb)
            {
                //seed categories
                mb.Entity<Category>().HasData(
                    new Category
                    {
                        CategoryId = 1,
                        cName = "Action / Adventure"
                    },
                    new Category
                    {
                        CategoryId = 2,
                        cName = "War"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        cName = "Comedy"
                    },
                    new Category
                    {
                        CategoryId = 4,
                        cName = "Drama"
                    },
                    new Category
                    {
                        CategoryId = 5,
                        cName = "Family"
                    },
                    new Category
                    {
                        CategoryId = 6,
                        cName = "Horror / Suspense"
                    },
                    new Category
                    {
                        CategoryId = 7,
                        cName = "Miscellaneous"
                    },
                    new Category
                    {
                        CategoryId = 8,
                        cName = "Television"
                    },
                    new Category
                    {
                        CategoryId = 9,
                        cName = "VHS"
                    }
                );
                //mb.Entity<Director>().HasData(
                //    new Director
                //    {
                //        DirectorId = 1,
                //        dFirstName = "Christopher",
                //        dLastName = "Nolan"
                //    },
                //    new Director
                //    {
                //        DirectorId = 2,
                //        dFirstName = "Jon",
                //        dLastName = "Watts"
                //    },
                //    new Director
                //    {
                //        DirectorId = 3,
                //        dFirstName = "Sam",
                //        dLastName = "Mendes"
                //    }
                //);

                //seed ratings
                mb.Entity<Rating>().HasData(
                    new Rating
                    {
                        RatingId = 1,
                        rateName = "G"
                    },
                    new Rating
                    {
                        RatingId = 2,
                        rateName = "PG"
                    },
                    new Rating
                    {
                        RatingId = 3,
                        rateName = "PG-13"
                    },
                    new Rating
                    {
                        RatingId = 4,
                        rateName = "R"
                    }
                );


                //seed 3 movies
                mb.Entity<Movies>().HasData(
                    new Movies
                    {
                        MovieId = 1,
                        Title = "Inception",
                        CategoryId = 1,
                        Year = 2010,
                        Director = "Christopher Nolan",
                        RatingId = 3
                    },
                    new Movies
                    {
                        MovieId = 2,
                        Title = "Spiderman No Way Home",
                        CategoryId = 1,
                        Year = 2021,
                        Director = "Jon Watts",
                        RatingId = 3
                    },
                    new Movies
                    {
                        MovieId = 3,
                        Title = "1917",
                        CategoryId = 2,
                        Year = 2019,
                        Director = "Sam Mendes",
                        RatingId = 4
                    }
                );
        }
    }
}
