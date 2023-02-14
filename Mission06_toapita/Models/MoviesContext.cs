using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_toapita.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        public DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Add my movies (These are some of the best movies of all time)
            mb.Entity<Movies>().HasData(
                new Movies
                {
                    MovieID = 1,
                    Category = "Sci-fi",
                    Title = "Star Wars",
                    Year = 1977,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false
                },
                new Movies
                {
                    MovieID = 2,
                    Category = "Comedy",
                    Title = "Pride and Prejudice",
                    Year = 1995,
                    Director = "Simon Langton",
                    Rating = "PG",
                    Edited = false
                },
                new Movies
                {
                    MovieID = 3,
                    Category = "Action/Adventure",
                    Title = "Thor Ragnarok",
                    Year = 2017,
                    Director = "Taika Waititi",
                    Rating = "PG-13",
                    Edited = true
                }
                );
        }
    }
}
