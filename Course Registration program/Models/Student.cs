using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course_Registration_program.Models;

public class Student
{
    [Key]public int studentID { get; set; }
    public string lName { get; set; }
    public string fName { get; set; }
    public string emailID { get; set; }
    public long phoneNumber { get; set; }
    // [ForeignKey("courseID")]public int courseID { get; set; }
    // public Course Course { get; set; }
    public Student(int studentID, string lName, string fName, string emailID, long phoneNumber)
    {
        this.studentID = studentID;
        this.lName = lName;
        this.fName = fName;
        this.emailID = emailID;
        this.phoneNumber = phoneNumber;
        // this.courseID = courseID;
    }

    // public Student()
    // {
    //     throw new NotImplementedException();
    // }
}