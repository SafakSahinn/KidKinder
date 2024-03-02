using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminParentController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ParentList()
        {
            var values = context.Parents.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateParent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateParent(Parent parent)
        {
            context.Parents.Add(parent);
            context.SaveChanges();
            return RedirectToAction("ParentList");
        }

        public ActionResult DeleteParent(int id)
        {
            var values = context.Parents.Find(id);
            context.Parents.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ParentList");
        }

        [HttpGet]
        public ActionResult UpdateParent(int id)
        {
            var values = context.Parents.Find(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateParent(Parent parent)
        {
            var values = context.Parents.Find(parent.ParentId);
            values.NameSurname = parent.NameSurname;
            context.SaveChanges();
            return RedirectToAction("ParentList");
        }
    }
}