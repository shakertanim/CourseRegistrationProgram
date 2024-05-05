using Course_Registration_program.Models;
using Microsoft.AspNetCore.Mvc;
namespace Course_Registration_program.Controllers;

public class StudentCourseController : Controller
{
    private DatabaseConnection dbContextForStudentCourse = new DatabaseConnection();
    private int sid;
    private int cid;
    private bool valid=false;
    private string errorText;
    public bool validation(int passedValue, int dbValue)
    {   
        
        return valid;
    }

    public ActionResult StudentCourse()
    {
        List<StudentCourse> studentCourses = new List<StudentCourse>();

        foreach (var studentCourseInDB in dbContextForStudentCourse.studentCourse)
        {
            studentCourses.Add(studentCourseInDB);
        }
        
        return View(studentCourses);
    }

    public ActionResult registerCourse(int sid, int cid)
    {
        var studentToTrack = dbContextForStudentCourse.student.FirstOrDefault(s => s.studentID == sid);
        var courseToTrack = dbContextForStudentCourse.course.FirstOrDefault(c => c.courseID == cid);

        if (studentToTrack != null && courseToTrack != null)
        {
            dbContextForStudentCourse.studentCourse.Add(new StudentCourse(sid, cid));
            dbContextForStudentCourse.SaveChanges();
            errorText = $"Registration Done for Student ID {sid}";
        }
        else
        {
            errorText = $"Either Student with ID : {sid} or Course with ID : {cid} does not exists.";
        }

        return Content(errorText);
    }

    public ActionResult deregisterCourse(int assignID)
    {
        var checkAssignment = dbContextForStudentCourse.studentCourse.FirstOrDefault(a => a.assignmentID == assignID);

        if (checkAssignment != null)
        {
            dbContextForStudentCourse.studentCourse.Remove(checkAssignment);
            dbContextForStudentCourse.SaveChanges();
            errorText = "Assignment Deleted.";
            return Content(errorText);
        }
        else
        {
            errorText = "Assignment Does not exists.";
        }

        return Content(errorText);
    }
    
}