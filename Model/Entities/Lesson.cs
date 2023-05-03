using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class Lesson:BaseEntity
    {
        public string LessonName { get; set; }
        public int Credit { get; set; }
        public int LowestPassingGradeId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }
        public int? TeacherId { get; set; }
        public string LessonCode { get; set; }
        public int? FirstVisaRatio { get; set; }
        public int? SecondVisaRatio { get; set; }
        public int? FinalRatio { get; set; }
        public Department Department { get; set; }
        public virtual List<StudentLesson> StudentLessons { get; set; }




    }
}
