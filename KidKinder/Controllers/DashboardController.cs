using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Context;
using KidKinder.Entities;

namespace KidKinder.Controllers
{
    public class DashboardController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            ViewBag.ArtCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Resim").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.MusicCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Müzik").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.MathCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Matematik").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.EnglishCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "İngilizce").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.SpanishCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "İspanyolca").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.GymCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Beden Eğitimi").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.ScienceCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Fen Bilimleri").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.ThatreCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Tiyatro").Select(y => y.BranchId).FirstOrDefault()).Count();

            ViewBag.AvgPrice = context.ClassRooms.Average(x => x.Price).ToString("0.00");

            ViewBag.BookASeatCount = context.BookASeats.Count();

            return View();
        }

        public PartialViewResult TeacherDashboardPartial()
        {
            var values = context.Teachers.OrderByDescending(x => x.TeacherId).Take(5).ToList();
            return PartialView(values);
        }

        public PartialViewResult BranchDashboardPartial()
        {
            var values = context.Branches.OrderByDescending(x => x.BranchId).Take(6).ToList();

            return PartialView(values);
        }
    }
}