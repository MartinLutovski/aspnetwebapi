using Avenga.DataAnnotations.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Avenga.DataAnnotations.DataAccess
{
    public class DataAnnotationsDbContext : DbContext
    {
        public DataAnnotationsDbContext(DbContextOptions options) : base(options)
        {

        }


        // Represents the tables in the database for the application.
        public DbSet<Note> Notes { get; set; } // Table in database for Notes
        public DbSet<User> Users { get; set; } // Table in database for Users
    }
}
