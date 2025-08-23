using ConcertBooking.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConcertBooking.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Skill> Skills { get; set; }
        // We don't need to define DbSet for StudentSkill, but it's useful for direct access
        //public DbSet<StudentSkill> StudentSkills { get; set; } // Join table for many-to-many relationship

        // Fluent API configurations can be done here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentSkill>()
                .HasKey(x => new { x.StudentId, x.SkillId }); // Composite key

            base.OnModelCreating(modelBuilder);
        }
    }
}

// Fluent API: An alternative to Data Annotations for configuring the model
// in simple terms it is used to tell Entity Framework how to map your
// classes to database tables and how to handle relationships between them.