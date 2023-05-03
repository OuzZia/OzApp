using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ouzzia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAffairsController : ControllerBase
    {
        private readonly StudentAffairBs _studentAffairBs;
        private readonly StudentBs _studentBs;
        private readonly TeacherBs _teacherBs;
        public StudentAffairsController()
        {
            _studentAffairBs = new StudentAffairBs();
            _studentBs = new StudentBs();
            _teacherBs = new TeacherBs();
        }
        [HttpGet]
        [Route("GetAllStudentAffairs")]
        public List<StudentAffairDto> GetAllStudentAffairs()
        {
            return _studentAffairBs.GetAll().Select(x => new StudentAffairDto()
            {
                Email = x.Email,
                Name = x.Name,
                Id = x.Id,
                RoleId = x.RoleId,
                FacultyId = x.FacultyId,
                DepartmentId = x.DepartmentId
            }).ToList();
        }
        [HttpGet]
        [Route("GetByStudentAffairId/{id}")]
        public IActionResult GetByStudentAffairId(int id)
        {
            StudentAffair studentAffair = _studentAffairBs.GetById(id);
            if (studentAffair != null)
            {
                StudentAffairDto dto = new StudentAffairDto();
                dto.Id = studentAffair.Id;
                dto.Email = studentAffair.Email;
                dto.Name = studentAffair.Name;
                dto.DepartmentId = studentAffair.DepartmentId;
                dto.FacultyId = studentAffair.FacultyId;
                dto.RoleId = studentAffair.RoleId;
                return Ok(dto);
            }
            else
                return NotFound();
        }
        [HttpPost]
        [Route("InsertStudentAffair")]
        public IActionResult InsertStudentAffair([FromBody] StudentAffairInsertDto dto)
        {
            if (ModelState.IsValid)
            {
                StudentAffair studentAffair = new StudentAffair();
                studentAffair.Name = dto.Name;
                studentAffair.Password = dto.Password;
                studentAffair.Email = dto.Email;
                studentAffair.RoleId = dto.RoleId;
                studentAffair.DepartmentId = dto.DepartmentId;
                studentAffair.FacultyId = dto.FacultyId;
                _studentAffairBs.Insert(studentAffair);
                return CreatedAtAction("GetByStudentAffairId", new { id = studentAffair.Id }, studentAffair);
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put([FromBody] StudentAffairUpdateDto dto)
        {

            if (ModelState.IsValid)
            {
                StudentAffair studentAffair = _studentAffairBs.GetById(dto.Id);
                if (studentAffair != null)
                {
                    studentAffair.Email = dto.Email;
                    studentAffair.Name = dto.Name;
                    studentAffair.RoleId = dto.RoleId;
                    studentAffair.DepartmentId = dto.DepartmentId;
                    studentAffair.FacultyId = dto.FacultyId;
                    studentAffair.Password = dto.Password;
                    _studentAffairBs.Update(studentAffair);
                    return Ok(studentAffair);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            StudentAffair studentAffair = _studentAffairBs.GetById(id);
            if (studentAffair != null)
            {
                _studentAffairBs.Delete(id);
                return Ok();
            }
            return NotFound();
        }
        //[HttpGet]
        //[Route("GetStudentsByDepartmentId/{id}")]
        //public List<StudentDto> GetStudentsByDepartmentId(int id)
        //{
        //    return _studentBs.GetAllByDepartmentId(id).Select(x => new StudentDto()
        //    {
        //        Id = x.Id,
        //        Email = x.Email,
        //        Name = x.StudentName,
        //        RoleId = x.RoleId,
        //        DepartmentId = x.DepartmentId
        //    }).ToList();
        //}
        [HttpGet]
        [Route("GetStudentsByDepartmentId/{id}")]
        public IActionResult GetStudentsByDepartmentId(int id)
        {
            List<Student> student = _studentBs.GetAllByDepartmentId(id);
            if (student.Count>0)
            {
               var studentnew = student.Select(x => new StudentDto()
                {
                    Email = x.Email,
                    Name = x.StudentName,
                    Id = x.Id,
                    RoleId = x.RoleId,
                    DepartmentId = x.DepartmentId,
                }).ToList();
                return Ok(studentnew);
            }
            return NotFound(new { success = false, errormessage = "Kayıt bulunamadı." });
        }
        [HttpGet]
        [Route("GetTeachersByDepartmentId/{id}")]

        public List<TeacherDto> GetTeacherByDepartmentId(int id)
        {
            return _teacherBs.GetByDepartmentId(id).Select(x => new TeacherDto()
            {
                Id = x.Id,
                Email = x.Email,
                RoleId = x.RoleId,
                DepartmentId = x.DepartmentId,
                Name = x.TeacherName
            }).ToList();
        }

        //[HttpDelete]
        //[Route("DeleteStudent/{id}")]
        //public IActionResult DeleteStudent(int id)
        //{

        //}



    }
}
