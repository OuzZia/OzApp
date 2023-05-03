using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using OzApp.Areas.Admin.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Areas.Admin.Components
{

    public class LeftMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            StudentAffair studentAffair = HttpContext.Session.GetObject<StudentAffair>("LoggedAdmin");

            ViewBag.LoggedStudentAffair = studentAffair;

            return View();
        }
    }
}
