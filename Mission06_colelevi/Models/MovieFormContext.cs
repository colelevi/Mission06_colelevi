using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_colelevi.Models
{
    public class MovieFormContext: DbContext
    {
        //Constructor
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base (options)
        {
            //inherit from context and options
        }

        //Pull Data using responses
        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Category> categories { get; set; }

        //Seeding the Data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Seed data for categories
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName="Action/Adventure"},
                new Category { CategoryId=2, CategoryName="Comedy"},
                new Category { CategoryId =3, CategoryName = "Drama" },
                new Category { CategoryId =4, CategoryName = "Family" },
                new Category { CategoryId =5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId =6, CategoryName = "Misc" },
                new Category { CategoryId =7, CategoryName = "TV" },
                new Category { CategoryId =8, CategoryName = "VCR" }
                );

            //Form Data
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "asdf",
                    Year = 2008,
                    Director = "Me",
                    Rating = "PG",
                    Edited = true,
                    Lent = "Spencer",
                    Notes = "None"
                },
                new ApplicationResponse
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "asdf2",
                    Year = 2009,
                    Director = "Me",
                    Rating = "PG-13",
                    Edited = true,
                    Lent = "Cole",
                    Notes = "None"
                }
                );
        }
    }
}
