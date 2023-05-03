using Microsoft.EntityFrameworkCore;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class OgrenciSistemiDb:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=OUZZIA;database=OgrenciSistemiDb;trusted_connection=true");
        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TeacherRole> TeacherRoles { get; set; }
        public DbSet <StudentAffair> StudentAffairs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<TeacherLesson> TeacherLessons { get; set; }
        public DbSet<User> Users { get; set; }




    }
}
