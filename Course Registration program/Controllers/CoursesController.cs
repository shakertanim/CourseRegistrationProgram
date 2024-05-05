using Course_Registration_program.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Text.Json;

namespace Course_Registration_program.Controllers;

public class CoursesController : Controller
{
    
    private DatabaseConnection dbContextForCourse = new DatabaseConnection();
    private Course tempCourse;
    private string? name;

    private string? num;

    private string? desc;
    private string? errorText;
    
    // GET
    public IActionResult Courses()
    {

        List<Course> courses = new List<Course>();

        foreach (var courseInDB in dbContextForCourse.course)
        {
            courses.Add(courseInDB);
        }
        
        return View(courses);
    }

    public ActionResult addCourse(int cid, int cnum, string cname, string cdesc)
    {
        dbContextForCourse.course.Add(new Course(cid, cnum, cname, cdesc));
        dbContextForCourse.SaveChanges();
        errorText = "Added";
        return Content(errorText);
    }
    
    public ActionResult deleteCourse(int cid)
    {
        var courseToDelete = dbContextForCourse.course.FirstOrDefault(c => c.courseID == cid);
        if (courseToDelete != null)
        {
            dbContextForCourse.course.Remove(courseToDelete);
            dbContextForCourse.SaveChanges();
            errorText = "Deleted";
        }
        else
        {
            errorText = "Course does not exists.";
        }
        return Content(errorText);
    }
    
    
    public ActionResult StudentCourseMapping(int cid)
    {
        var studentsInTheCourse = from c in dbContextForCourse.course
            join sc in dbContextForCourse.studentCourse on c.courseID equals sc.courseID
            join s in dbContextForCourse.student on sc.studentID equals s.studentID
            where c.courseID == cid
            select new 
            {
                studentID = s.studentID,
                lName = s.lName,
                fName = s.fName,
                emailID = s.emailID,
                phoneNumber = s.phoneNumber,
            };

        var studentsListJson = JsonSerializer.Serialize(studentsInTheCourse);

        return Content(studentsListJson, "application/json");
    }


}