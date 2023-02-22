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

        // Give access to the categories table
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Fill the table with data
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryDescription = "Television"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryDescription = "VHS"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryDescription = "Horror/Suspense"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryDescription = "Miscellaneous"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryDescription = "Drama"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryDescription = "Action/Adventure"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryDescription = "Comedy"
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryDescription = "Family"
                }
                );
            //Add my movies (These are some of the best movies of all time)
            mb.Entity<Movies>().HasData(
                new Movies
                {
                    MovieID = 1,
                    CategoryId = 6,
                    Title = "Star Wars",
                    Year = 1977,
                    Director = "George Lucas",
                    Rating = "PG",
                    Edited = false
                },
                new Movies
                {
                    MovieID = 2,
                    CategoryId = 7,
                    Title = "Pride and Prejudice",
                    Year = 1995,
                    Director = "Simon Langton",
                    Rating = "PG",
                    Edited = false
                },
                new Movies
                {
                    MovieID = 3,
                    CategoryId = 7,
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
