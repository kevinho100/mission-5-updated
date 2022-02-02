using System;
using Microsoft.EntityFrameworkCore;

namespace FilmCollection.Models
{
    public class MovieApplicationContext : DbContext
    {
        //constructor
        public MovieApplicationContext(DbContextOptions<MovieApplicationContext> options) :base(options)
        {
            //leave blank
        }

        public DbSet<ApplicationResponse> Responses { get; set; }
        public DbSet<Category> Category { get; set; }

        //Seed data 
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                    new Category { CategoryId=1, CategoryName="Family"},
                    new Category { CategoryId = 2, CategoryName = "Horror/Suspense" },
                    new Category { CategoryId = 3, CategoryName = "Miscellaneous" },
                    new Category { CategoryId = 4, CategoryName = "Television" },
                    new Category { CategoryId = 5, CategoryName = "VHS" },
                    new Category { CategoryId = 6, CategoryName = "Action/Adventure" },
                    new Category { CategoryId = 7, CategoryName = "Comedy" },
                    new Category { CategoryId = 8, CategoryName = "Drama" }
                );

            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    MovieID = 1,
                    CategoryId = 6,
                    Title = "Spider-Man: No way home",
                    Year = 2022,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LenTo = "",
                    Notes = "Best movie of 2022"
                },

                new ApplicationResponse
                {
                    MovieID = 2,
                    CategoryId = 6,
                    Title = "Avengers:Endgame",
                    Year = 2019,
                    Director = "Kevin Feige",
                    Rating = "PG-13",
                    Edited = false,
                    LenTo = "",
                    Notes = "Best movie of 2019"
                },

                new ApplicationResponse
                {
                    MovieID = 3,
                    CategoryId = 6,
                    Title = "Avengers:Infinity War",
                    Year = 2018,
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LenTo = "",
                    Notes = "Best movie of 2018"
                }


                );
        }
    }
}
