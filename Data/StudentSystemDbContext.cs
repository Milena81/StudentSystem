namespace StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    public class StudentSystemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=HOME\\SQLEXPRESS;Database=StudentSystemDb;Integrated Sequrity=True;");

            base.OnConfiguring(builder);
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
