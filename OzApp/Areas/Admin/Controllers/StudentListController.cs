using Business;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using OzApp.Areas.Admin.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentListController : Controller
    {
        private readonly StudentBs _studentBs;
        public StudentListController()
        {
            _studentBs = new StudentBs();
        }
      
        public IActionResult Index()
        {
            StudentAffair studentAffair = HttpContext.Session.GetObject<StudentAffair>("LoggedAdmin");
            ViewBag.LoggedStudentAffair = studentAffair;
            if (studentAffair.RoleId == 4)
            {
             
                List<Student> studentList = _studentBs.GetAllByDepartmentId(studentAffair.DepartmentId,"Role","Department","StudentLessons","StudentLessons.Lesson");
                return View(studentList);
            }
            return View("Forbidden");
        }
        
    }
}
