using Microsoft.EntityFrameworkCore;
using StudentData.Models.Domain;

namespace StudentData.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
