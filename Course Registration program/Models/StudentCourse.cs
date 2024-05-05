using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Registration_program.Models;

public class StudentCourse
{   [Key]
    public int assignmentID { get; set; }
    [ForeignKey("studentID")]
    public int studentID { get; set; }
    public Student Student { get; set; }
    [ForeignKey("courseID")]
    public int courseID { get; set; }
    public Course Course { get; set; }
    
    public StudentCourse(int studentID, int courseID)
    {
        this.studentID = studentID;
        this.courseID = courseID;
    }
}