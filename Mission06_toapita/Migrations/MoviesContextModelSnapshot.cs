﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission06_toapita.Models;

namespace Mission06_toapita.Migrations
{
    [DbContext(typeof(MoviesContext))]
    partial class MoviesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission06_toapita.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryDescription = "Television"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryDescription = "VHS"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryDescription = "Horror/Suspense"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryDescription = "Miscellaneous"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryDescription = "Drama"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryDescription = "Action/Adventure"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryDescription = "Comedy"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryDescription = "Family"
                        });
                });

            modelBuilder.Entity("Mission06_toapita.Models.Movies", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lent_To")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            CategoryId = 6,
                            Director = "George Lucas",
                            Edited = false,
                            Rating = "PG",
                            Title = "Star Wars",
                            Year = 1977
                        },
                        new
                        {
                            MovieID = 2,
                            CategoryId = 7,
                            Director = "Simon Langton",
                            Edited = false,
                            Rating = "PG",
                            Title = "Pride and Prejudice",
                            Year = 1995
                        },
                        new
                        {
                            MovieID = 3,
                            CategoryId = 7,
                            Director = "Taika Waititi",
                            Edited = true,
                            Rating = "PG-13",
                            Title = "Thor Ragnarok",
                            Year = 2017
                        });
                });

            modelBuilder.Entity("Mission06_toapita.Models.Movies", b =>
                {
                    b.HasOne("Mission06_toapita.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
