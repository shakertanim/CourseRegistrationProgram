using Course_Registration_program.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course_Registration_program.Controllers;

public class InstructorsController : Controller
{
    private DatabaseConnection dbContextForInstructor = new DatabaseConnection();
    // GET
    private Course tempInstructor;
    private string lName;
    private string fName;
    private string email;
    private int cid;
    private string errorContent;

    private Instructor check = new Instructor();
    
    public IActionResult Instructors()
    {
        List<Instructor> instructors = new List<Instructor>();

        foreach (var instructorInDB in dbContextForInstructor.instructor)
        {
            instructors.Add(instructorInDB);
        }
        
        return View(instructors);
    }
    
    public ActionResult addInstructor(int iid, string iLName, string iFName, string iEmail, int icid)
    {
        var course = dbContextForInstructor.course.FirstOrDefault(c => c.courseID == icid);
        bool validate = check.validateCourse(course.courseID);
            if (course != null && validate)
            {
                dbContextForInstructor.instructor.Add(new Instructor(iid,iLName,iFName,iEmail,icid));
                dbContextForInstructor.SaveChanges();
                errorContent = "Instructor Added.";
            }
            else if (course != null && !validate)
            {
                errorContent = "Duplicate Course.";
            }
            else
            {
                errorContent = "Course does not exists.";
            }
        return Content(errorContent);
    }
    
    public ActionResult deleteInstructor(int iid)
    {
        var InstructorToDelete = dbContextForInstructor.instructor.FirstOrDefault(c => c.instructorID == iid);
        dbContextForInstructor.instructor.Remove(InstructorToDelete);
        dbContextForInstructor.SaveChanges();
        errorContent = "Instructor Deleted.";
        return Content(errorContent);
    }
}