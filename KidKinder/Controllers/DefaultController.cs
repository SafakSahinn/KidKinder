using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Entities;
using KidKinder.Context;

namespace KidKinder.Controllers
{
    public class DefaultController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAboutList()
        {
            var values = context.AboutLists.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialClassRooms()
        {
            var values = context.ClassRooms.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialBookASeat()
        {
            List<SelectListItem> values = (from x in context.ClassRooms.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.ClassRoomId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return PartialView();
        }

        [HttpPost]
        public ActionResult BookASeat(BookASeat bookASeat)
        {
            context.BookASeats.Add(bookASeat);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PartialTeacher()
        {
            var values = context.Teachers.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
    }
}