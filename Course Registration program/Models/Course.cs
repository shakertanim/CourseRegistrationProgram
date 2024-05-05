using System.ComponentModel.DataAnnotations;

namespace Course_Registration_program.Models;

public class Course
{
    [Key]public int courseID { get; set; }
    public int courseNumber { get; set; }
    public string courseName { get; set; }
    public string description { get; set; }

    public Course(int courseID, int courseNumber, string courseName, string description)
    {
        this.courseID = courseID;
        this.courseNumber = courseNumber;
        this.courseName = courseName;
        this.description = description;
    }
}