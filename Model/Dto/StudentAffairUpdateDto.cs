using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Dto
{
    public class StudentAffairUpdateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Şifre sağlanmalıdır.", AllowEmptyStrings = false)]
        [MinLength(4, ErrorMessage = "Şifre en az 4 karakter olmalıdır.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "İsim sağlanmalıdır.", AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Email formatında olmalıdır.", AllowEmptyStrings = false)]
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public int FacultyId { get; set; }
    }
}
