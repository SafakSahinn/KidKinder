using KidKinder.Context;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KidKinder.Entities;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [Authorize]
    public class AdminClassController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ClassList()
        {
            var values = context.ClassRooms.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateClass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClass(ClassRoom classRoom)
        {
            context.ClassRooms.Add(classRoom);
            context.SaveChanges();
            return RedirectToAction("ClassList");
        }

        public ActionResult DeleteClass(int id)
        {
            var value = context.ClassRooms.Find(id);
            context.ClassRooms.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ClassList");
        }

        [HttpGet]
        public ActionResult UpdateClass(int id)
        {
            var values = context.ClassRooms.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateClass(ClassRoom classRoom)
        {
            var value = context.ClassRooms.Find(classRoom.ClassRoomId);
            value.Title = classRoom.Title;
            value.Description = classRoom.Description;
            value.AgeOfKids = classRoom.AgeOfKids;
            value.TotalSeats = classRoom.TotalSeats;
            value.ClassTime = classRoom.ClassTime;
            value.Price = classRoom.Price;
            value.ImageUrl = classRoom.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("ClassList");
        }
    }
}