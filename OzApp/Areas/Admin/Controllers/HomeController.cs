﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Newtonsoft.Json;
using OzApp.Areas.Admin.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
          
            StudentAffair StudentAffair = HttpContext.Session.GetObject<StudentAffair>("LoggedAdmin");
        ViewBag.LoggedStudentAffair = StudentAffair;
            return View();
        }
    }
}
