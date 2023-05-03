using Business;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using OzApp.Areas.Admin.Extension;
using OzApp.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddStudentController : Controller
    {
        private readonly StudentBs _studentBs;
        private readonly RoleBs _roleBs;
        private readonly UserBs _userBs;
        
        public AddStudentController()
        {
            _studentBs = new StudentBs();
            _roleBs = new RoleBs();
            _userBs = new UserBs();
        }

        public IActionResult Add()
        {
            
            StudentAffair studentAffair = HttpContext.Session.GetObject<StudentAffair>("LoggedAdmin");
            ViewBag.LoggedStudentAffair = studentAffair;
            if (studentAffair.RoleId == 4)
            {
                
                List<Student> studentList = _studentBs.GetAllByDepartmentId(studentAffair.DepartmentId, "Role", "Department");
                return View(studentList);

            }
            return View("Forbidden");
        }
        #region FullPostBack
        //[HttpPost]
        //public void Add(NewStudentVm vm)
        //{
        //    Model.Entities.Student student = new Model.Entities.Student();
        //    student.StudentName = vm.FullName;
        //    student.Email = vm.Email;
        //    student.Password = vm.Password;
        //    student.IsActive = vm.IsActive;
        //    student.RoleId = vm.RoleId;
        //    student.Adress = vm.Adress;
        //    student.BirthDate = vm.BirthDate;
        //    student.DateOfRegistiration = vm.DateOfRegistiration;
        //    student.PhoneNumber = vm.PhoneNumber;
        //    student.IDNumber = vm.IdNumber;
        //    student.DepartmentId = studentAffair.DepartmentId;
        //    student.City = vm.City;

        //    _studentBs.Insert(student);


        //}
        #endregion

        [HttpPost]

        public IActionResult Add(NewStudentVm vm)
        {
            StudentAffair studentAffair = HttpContext.Session.GetObject<StudentAffair>("LoggedAdmin");
            try
            {
                User userEmail = _userBs.GetByEmail(vm.Email);
                if (userEmail != null)
                {
                    return Json(new { Result = false, message = "Bu Email sistemde kayıtlı" });
                }
                Student student = new Student();
                User user = new User();
                student.StudentName = vm.FullName;
                student.Email = vm.Email;
                student.Password = vm.Password;
                student.IsActive = vm.IsActive;
                student.RoleId = vm.RoleId;
                student.Adress = vm.Adress;
                student.BirthDate = vm.BirthDate;
                student.DateOfRegistiration = vm.DateOfRegistiration;
                student.PhoneNumber = vm.PhoneNumber;
                student.IDNumber = vm.IdNumber;
                student.DepartmentId = studentAffair.DepartmentId;
                student.City = vm.City;
                user.Email = vm.Email;
                user.Password = vm.Password;
                _userBs.Insert(user);
                _studentBs.Insert(student);
                return Json(new { Result = true, message = "Kayıt Başarılı" });
            }
            catch (Exception ex)
            {

                return Json(new { Result = false, message = "Kayıt Başarısız" });
            }


        }

    }
}
