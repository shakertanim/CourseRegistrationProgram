using Course_Registration_program.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course_Registration_program.Controllers;

public class StudentsController : Controller
{
    private DatabaseConnection dbContextForStudent = new DatabaseConnection();
    // GET
    private Course tempStudent;
    private string lName;
    private string fName;
    private string email;
    private long phoneNumber;
    private string? errorText;
    
    public IActionResult Students()
    {
        List<Student> students = new List<Student>();

        foreach (var studentInDB in dbContextForStudent.student)
        {
            students.Add(studentInDB);
        }
        
        return View(students);
    }
    
    public ActionResult addStudent(int sid, string sLName, string sFName, string sEmail, long sPhoneNum)
    {
        dbContextForStudent.student.Add(new Student(sid,sLName,sFName,sEmail,sPhoneNum));
        dbContextForStudent.SaveChanges();
        errorText = "Added";
        return Content(errorText);
    }
    
    public ActionResult deleteStudent(int sid)
    {
        var studentToDelete = dbContextForStudent.student.FirstOrDefault(c => c.studentID == sid);
        if (errorText != null)
        {
            dbContextForStudent.student.Remove(studentToDelete);
            dbContextForStudent.SaveChanges();
            errorText = "Deleted";
        }
        else
        {
            errorText = "Student does not exists.";
        }
        
        return Content(errorText);
    }

    
}