using ConcertBooking.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertBooking.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) {}

        public DbSet<People> Peoples { get; set; } 
    }
}


//Entity Framework Core:
// Introduced in .NET Core 1.0, Entity Framework Core is a lightweight, extensible, and cross-platform version of the popular Entity Framework data access technology.
// It is designed to work with .NET Core applications and provides a modern approach to data access, including support for LINQ queries, change tracking, and migrations.
// Entity Framework Core is a complete rewrite of the original Entity Framework, providing better performance and flexibility.
// Entity Framework Core is commonly used in ASP.NET Core applications to interact with databases using an object-relational mapping (ORM) approach.

//DbContext: Primary class responsible for interacting with the database.
// It manages the database connection and is used to query and save instances of your entities.

// DbSet<TEntity> properties represent collections of entities in the database.
// Each DbSet corresponds to a table in the database.


