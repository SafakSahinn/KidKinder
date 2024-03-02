using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminStudentController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult StudentList()
        {
            var values = context.Students.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("StudentList");
        }

        public ActionResult DeleteStudent(int id)
        {
            var value = context.Students.Find(id);
            context.Students.Remove(value);
            context.SaveChanges();
            return RedirectToAction("StudentList");
        }

        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            var value = context.Students.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var values = context.Students.Find(student.StudentId);
            values.NameSurname = student.NameSurname;
            values.ImageUrl = student.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("StudentList");
        }
    }
}