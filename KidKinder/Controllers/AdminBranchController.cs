using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminBranchController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult BranchList()
        {
            var values = context.Branches.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateBranch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBranch(Branch branch)
        {
            context.Branches.Add(branch);
            context.SaveChanges();
            return RedirectToAction("BranchList");
        }

        public ActionResult DeleteBranch(int id)
        {
            var value = context.Branches.Find(id);
            context.Branches.Remove(value);
            context.SaveChanges();
            return RedirectToAction("BranchList");
        }

        [HttpGet]
        public ActionResult UpdateBranch(int id)
        {
            var values = context.Branches.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateBranch(Branch branch)
        {
            var value = context.Branches.Find(branch.BranchId);
            value.Name = branch.Name;
            context.SaveChanges();
            return RedirectToAction("BranchList");
        }
    }
}