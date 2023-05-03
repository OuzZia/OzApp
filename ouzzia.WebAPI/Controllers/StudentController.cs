using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ouzzia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentBs _studentBs;
        public StudentController()
        {
            _studentBs = new StudentBs();
        }
        public List<Student> Get()
        {
            return _studentBs.GetAll("StudentLessons");
        }
    }
}
