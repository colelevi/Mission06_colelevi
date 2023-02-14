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

        public DbSet<ApplicationResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieId = 1,
                    Category = "Comedy",
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
                    Category = "Drama",
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
