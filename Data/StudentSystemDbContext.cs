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
            builder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder
                .Entity<Student>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Student)
                .HasForeignKey(c => c.StudentId);

            builder
                .Entity<Course>()
                .HasMany(c => c.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(s => s.CourseId);

            base.OnModelCreating(builder);
        }
    }
}
