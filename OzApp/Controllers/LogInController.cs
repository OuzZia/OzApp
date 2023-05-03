using Business;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using OzApp.Areas.Admin.Extension;
using OzApp.Areas.Admin.Models;
using OzApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Controllers
{
    public class LogInController : Controller
    {
        private readonly StudentAffairBs _studentAffairBs;
        public LogInController()
        {
            _studentAffairBs = new StudentAffairBs();
        }
        public IActionResult LogIn()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult LogIn(EmailPasswordLogIn vm)
        //{
        //    StudentAffairBs bs = new StudentAffairBs();
        //    StudentAffair StudentAffair = bs.LogIn(vm.Email, vm.Password);
        //    if (StudentAffair != null)
        //    {
        //        ViewBag.LoggedStudentAffair = StudentAffair;
        //        HttpContext.Session.SetObject("LoggedStudentAffair", StudentAffair);
        //        return View();
        //    }
        //    else
        //    {
        //        ViewBag.Alert = "danger";
        //        ViewBag.Message = "Giriş Başarısız";
        //        return View();
        //    }
        //}
        [HttpPost]
        public IActionResult LogIn(EmailPasswordLogIn JsonData)
        {
            HttpContext.Session.Remove("LoggedAdmin");
            StudentAffair studentAffair = _studentAffairBs.LogIn(JsonData.Email, JsonData.Password, "Department");
            if (studentAffair != null)
            {
                HttpContext.Session.SetObject("LoggedAdmin", studentAffair);
                return Json(new { result = true });
            }
            return Json(new { result = false, message = "Giriş Başarısız", Alertstyle = "danger" });
        }
        [HttpPost]
        public IActionResult SendPassword(ForgetPassword vm)
        {
            StudentAffairBs saBs = new StudentAffairBs();
            StudentAffair studentAffair =saBs.GetByEmail(vm.Email);
           
            if (studentAffair !=null)
            {
                UserBs userbs = new UserBs();
                User user = userbs.GetByEmail(studentAffair.Email);
                studentAffair.Password = RandomValueGenerator.GeneratePassword();
                saBs.Update(studentAffair);
                user.Password = studentAffair.Password;
                userbs.Update(user);
                return Json(new { result = true, message = "Yeni şifreniz mail adresinize gönderilmiştir." });
            }
            return Json(new { result = false, message = "Bu email adresiyle bir kayıt bulunamamıştır." });
            string message = $"Sayın {studentAffair.Name}. Yeni Şifreniz: <b>"+studentAffair.Password+"</b>}";
            MailHelper.SendMail(vm.Email, "Yeni Şifreniz", message);
        }
    }
}
