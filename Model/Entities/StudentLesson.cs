using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class StudentLesson:BaseEntity
    {
        public int StudentId { get; set; }
        public int LessonId { get; set; }
        public int? StudentGrade { get; set; }
        public int TeacherId { get; set; }
        public int? FirstVisaGrade { get; set; }
        public int? SecondVisaGrade { get; set; }
        public int? FinalGrade { get; set; }
        public string LetterGradeId { get; set; }
        public Lesson Lesson { get; set; }



    }
}
