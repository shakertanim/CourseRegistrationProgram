using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Registration_program.Models;

public class Instructor
{
    [Key] public int instructorID { get; set; }
    public string lName { get; set; }
    public string fName { get; set; }
    public string emailID{ get; set; }
    [ForeignKey("courseID")]
    public int courseID{ get; set; }
    public Course Course { get; set; }
    public bool validate = false;
    public Instructor() {}
    public Instructor(int instructorID, string lName, string fName, string emailID, int courseID)
    {
        this.instructorID = instructorID;
        this.lName = lName;
        this.fName = fName;
        this.emailID = emailID;
        this.courseID = courseID;
    }

    public bool validateCourse(int cid)
    {
        DatabaseConnection checkCourse = new DatabaseConnection();
        foreach (var course in checkCourse.instructor)
        {
            if (course.courseID == cid)
            {
                validate = false;
            }
            else
            {
                validate = true;
            }
        }
        return validate;
    }
}