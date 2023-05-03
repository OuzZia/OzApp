using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entities
{
    public class TeacherLesson:BaseEntity
    {
        public int LessonId { get; set; }
        public int TeacherId { get; set; }
        public Lesson Lesson { get; set; }


    }
}
