using System.Runtime.InteropServices.Marshalling;
using Microsoft.EntityFrameworkCore;

namespace Course_Registration_program.Models;

public class DatabaseConnection : DbContext
{
    public DbSet<Course> course { get; set; }
    public DbSet<Student> student { get; set; }
    public DbSet<Instructor> instructor { get; set; }
    public DbSet<StudentCourse> studentCourse { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString =
            "User ID=user;Password=Black_Rabbit@1234;Host=shakertanimdev.crwa4608cyzp.ca-central-1.rds.amazonaws.com;Port=5432;Database=CourseRegistration;Pooling=true;";
        optionsBuilder.UseNpgsql(connectionString);
    }

    
}