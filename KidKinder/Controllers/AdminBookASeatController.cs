using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminBookASeatController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult BookASeatList()
        {
            var values = context.BookASeats.ToList();
            return View(values);
        }

        public ActionResult DetailBookASeat(int id)
        {
            var values = context.BookASeats.FirstOrDefault(x => x.BookASeatId == id);

            if (values == null)
            {
                // Mesaj bulunamazsa, hata sayfasına yönlendirme yapabilirsiniz
                return RedirectToAction("Error");
            }

            return View(values);
        }

        public ActionResult DeleteBookASeat(int id)
        {
            var values = context.BookASeats.Find(id);
            context.BookASeats.Remove(values);
            context.SaveChanges();
            return RedirectToAction("BookASeatList");
        }
    }
}