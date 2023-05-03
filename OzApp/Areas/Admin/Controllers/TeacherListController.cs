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
    public class TeacherListController : Controller
    {
        private readonly TeacherBs _teacherBs;
        private readonly RoleBs _roleBs;
        private readonly TeacherRoleBs _teacherRoleBs;
        private readonly TeacherLessonBs _teacherLessonBs;
        private readonly LessonBs _lessonBs;
        private readonly UserBs _userBs;
        public TeacherListController()
        {
            _teacherBs = new TeacherBs();
            _roleBs = new RoleBs();
            _teacherRoleBs = new TeacherRoleBs();
            _teacherLessonBs = new TeacherLessonBs();
            _lessonBs = new LessonBs();
            _userBs = new UserBs();
        }
        public IActionResult Index()
        {
            StudentAffair studentAffair = HttpContext.Session.GetObject<StudentAffair>("LoggedAdmin");
            ViewBag.LoggedStudentAffair = studentAffair;

            TeacherIndexVm indexVm = new TeacherIndexVm();
            indexVm.TeacherList = _teacherBs.GetByDepartmentId(studentAffair.DepartmentId, "Department","TeacherRoles", "TeacherRoles.Role", "TeacherLessons", "TeacherLessons.Lesson");
            indexVm.TeacherRoleList = _teacherRoleBs.GetAll("Role");
            indexVm.LessonList = _lessonBs.GetByDepartmentId(studentAffair.DepartmentId);
            if (studentAffair.RoleId == 4)
            {
                return View(indexVm);
            }
            return View("Forbidden");
        }
        [HttpPost]
        public IActionResult Add(NewTeacherVm vm)
        {
            StudentAffair studentAffair = HttpContext.Session.GetObject<StudentAffair>("LoggedAdmin");
            try
            {
                User userEmail = _userBs.GetByEmail(vm.Email);
                if (userEmail!=null)
                {
                    return Json(new { Result = false, message = "Bu Email sistemde kayıtlı" });
                }
                if (vm.LessonIds==null)
                {
                    return Json(new { Result = false, message = "Lütfen en az 1 ders seçiniz." });
                }

                Teacher teacher = new Teacher();
                teacher.TeacherName = vm.FullName;
                teacher.Email = vm.Email;
                teacher.Password = vm.Password;
                teacher.Adress = vm.Adress;
                teacher.City = vm.City;
                teacher.DepartmentId = studentAffair.DepartmentId;
                teacher.PhoneNumber = vm.PhoneNumber;
                teacher.IsActive = vm.IsActive;
                teacher.DateOfRegistiration = vm.DateOfRegistiration;
                teacher.Birthdate = vm.BirthDate;
                teacher.IDNumber = vm.IDNumber;
                teacher.RoleId = vm.RoleId;
                _teacherBs.Insert(teacher);

                for (int i = 0; i < vm.LessonIds.Length; i++)
                {
                    TeacherLesson teacherLesson = new TeacherLesson();
                    teacherLesson.TeacherId = teacher.Id;
                    teacherLesson.LessonId = vm.LessonIds[i];
                    _teacherLessonBs.Insert(teacherLesson);
                }
                TeacherRole teacherRole = new TeacherRole();
                teacherRole.TeacherId = teacher.Id;
                teacherRole.RoleId = vm.RoleId;
                _teacherRoleBs.Insert(teacherRole);
                User user = new User();
                user.Email = vm.Email;
                user.Password = vm.Password;
                _userBs.Insert(user);




                return Json(new { Result = true, message = "Kayıt Başarılı" });

            }
            catch (Exception ex)
            {

                return Json(new { Result = false, message = "Kayıt Başarısız" });
            }


        }
        [HttpPost]
        public IActionResult DeleteTch(int tchId)
        {
            try
            {
                List<TeacherLesson> teacherLessonList = _teacherLessonBs.GetAllByTeacherId(tchId);
                Teacher teacher = _teacherBs.GetById(tchId);
                User user = _userBs.GetByEmail(teacher.Email);
                TeacherRole teacherRole = _teacherRoleBs.GetByTeacherId(tchId);
                foreach (var item in teacherLessonList)
                {
                    _teacherLessonBs.Delete(item);
                }
        
                _userBs.Delete(user);
                _teacherRoleBs.Delete(teacherRole);
                _teacherBs.Delete(tchId);
                return Json(new { result = true, message = "Öğretmen Kaydı Silindi" });
            }
            catch (Exception)
            {

                return Json(new { result = false, mesaage = "Kayıt Silinemedi" });
            }

        }
        [HttpPost]
        public IActionResult UpdateTch(UpdateTeacherVm vm)
        {
            try
            {
                Teacher teacher = _teacherBs.GetById(vm.Id);
                TeacherRole teacherRole = _teacherRoleBs.GetByTeacherId(vm.Id);
                List<TeacherLesson> teacherLessonList = _teacherLessonBs.GetAllByTeacherId(vm.Id);
                User userMail = _userBs.GetByEmail(vm.Email);
                User user = _userBs.GetByEmail(teacher.Email);
                if (userMail != null && teacher.Email != vm.Email)
                {
                    return Json(new { Result = false, message = "Bu Email sistemde kayıtlı" });
                }
                teacher.Id = vm.Id;
                teacher.Email = vm.Email;
                teacher.Password = vm.Password;
                teacher.Adress = vm.Adress;
                teacher.City = vm.City;
                teacher.DepartmentId = vm.DepartmentId;
                teacher.IDNumber = vm.IDNumber;
                teacher.IsActive = vm.IsActive;
                teacher.PhoneNumber = vm.PhoneNumber;
                teacher.RoleId = vm.RoleId;
                teacher.TeacherName = vm.FullName;
                teacher.Birthdate = vm.BirthDate;
                teacher.DateOfRegistiration = vm.DateOfRegistiration;
                teacherRole.TeacherId = vm.Id;
                teacherRole.RoleId = vm.RoleId;
                user.Email = vm.Email;
                user.Password = vm.Password;
                if (vm.LessonIds==null)
                {
                    return Json(new { result = false, message = "Lütfen en az 1 ders seçiniz." });
                }
                foreach (var item in teacherLessonList)
                {
                    _teacherLessonBs.Delete(item);
                }
               for (int  i = 0; i < vm.LessonIds.Length; i++)
                {
                    TeacherLesson teacherLesson = new TeacherLesson();
                    teacherLesson.TeacherId = teacher.Id;
                    teacherLesson.LessonId = vm.LessonIds[i];
                    _teacherLessonBs.Insert(teacherLesson);
                }
                _teacherBs.Update(teacher);
                _teacherRoleBs.Update(teacherRole);
                _userBs.Update(user);
                

                return Json(new { result = true, message = "Kayıt Güncellendi" });
            }
            catch (Exception ex)
            {

                return Json(new { result = false, message = "İşlem Başarısız" });
            }

        }
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
