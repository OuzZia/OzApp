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
    public class DeleteStudentController : Controller
    {
        private readonly StudentBs _studentBs;
        private readonly StudentLessonBs _studentLessonBs;
        private readonly UserBs _userBs;
        public DeleteStudentController()
        {
            _studentBs = new StudentBs();
            _studentLessonBs = new StudentLessonBs();
            _userBs = new UserBs();
        }
        public IActionResult Index()
        {
            StudentAffair studentAffair =HttpContext.Session.GetObject<StudentAffair>("LoggedAdmin");
            ViewBag.LoggedStudentAffair = studentAffair;
            if (studentAffair.RoleId==4)
            {
               List<Student> studentList = _studentBs.GetAllByDepartmentId(studentAffair.DepartmentId, "Role", "Department");
                return View(studentList);

            }
            return View("Forbidden");
        }
      [HttpPost]
        public IActionResult DeleteStd(int stId)
        {
            Student student = _studentBs.GetById(stId);
            User user = _userBs.GetByEmail(student.Email);
            List<StudentLesson> studentLessonList = _studentLessonBs.GetAllStudentLessonsById(stId);
            foreach (var item in studentLessonList)
            {
                _studentLessonBs.Delete(item);
            }
            _userBs.Delete(user);
            _studentBs.Delete(stId);
            return Json(new { result = true, message = "Öğrenci Kaydı Silindi" });
        }
        [HttpPost]
        public IActionResult UpdateStd(UpdateStudentVm vm)
        {
            try
            {
                Student student = _studentBs.GetById(vm.Id);
                User userMail = _userBs.GetByEmail(vm.Email);
                User user = _userBs.GetByEmail(student.Email);
                if (userMail!=null&&student.Email != vm.Email)
                {
                    return Json(new { Result = false, message = "Bu Email sistemde kayıtlı" });
                }
                student.StudentName = vm.FullName;
                student.Adress = vm.Adress;
                student.BirthDate = vm.BirthDate;
                student.City = vm.City;
                student.Email = vm.Email;
                student.Password = vm.Password;
                student.PhoneNumber = vm.PhoneNumber;
                student.IsActive = vm.IsActive;
                student.StudentSemesterCount = vm.StudentSemesterCount;
                student.DateOfRegistiration = vm.DateOfRegistiration;
                student.RoleId = vm.RoleId;
                student.DepartmentId = vm.DepartmentId;
                student.Id = vm.Id;
                student.IDNumber = vm.IdNumber;
                user.Email = vm.Email;
                user.Password = vm.Password;
                
                _studentBs.Update(student);
                _userBs.Update(user);
                return Json(new { Result = true, message = "Güncelleme Başarılı" });
            }
            catch (Exception ex)
            {

                return Json(new { Result = false, message = "Güncelleme Başarısız" });
            }
        }
    }
}
