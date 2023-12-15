using LerningApi1.Controllers;
using LerningApi1.Entities;
using Microsoft.EntityFrameworkCore;

namespace LerningApi1.DbContex
{
    public class DbApiLerning:DbContext
    {
            /*The settings sent from the program file to the database
            are delivered to the parent class*/
        public DbApiLerning(DbContextOptions<DbApiLerning> options)
            : base(options)
        {
                  
        }
        public DbSet<Cities> Cities { get; set; }
       public DbSet<PlaceOfCity> PlaceOfCity { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=DbApiLerning.db");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>()
             .HasData(
                new Cities()
                {
                    Name="Shiraz",
                    Description="this is Shiraz city",
                    Id=1
                },
                new Cities()
                {
                    Name = "Tehran",
                    Description = "this is Tehran city",
                    Id = 2
                },
                new Cities()
                {
                    Name = "MAshhad",
                    Description = "this is mashhad city",
                    Id = 3
                }

            );
            modelBuilder.Entity<PlaceOfCity>().HasData(
                new PlaceOfCity()
                {
                    Name="eram",
                    Description= "this is Garden",
                    CityId=1,
                    Id=1
                },
                new PlaceOfCity()
                {
                    Name="emarat shapoori",
                    Description= "this is mansion",
                    CityId=1,
                    Id=2
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
