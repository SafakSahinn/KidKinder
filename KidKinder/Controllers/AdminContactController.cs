using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult ContactList()
        {
            var values = context.Contacts.ToList();
            return View(values);
        }

        public ActionResult UnReadContactList()
        {
            var values = context.Contacts.Where(x => x.IsRead == false).ToList();
            return View(values);
        }

        public ActionResult ReadedContactList()
        {
            var values = context.Contacts.Where(x => x.IsRead == true).ToList();
            return View(values);
        }

        public ActionResult DeleteContact(int id)
        {
            var values = context.Contacts.Find(id);
            context.Contacts.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }

        public ActionResult ContactDetail(int id)
        {
            var values = context.Contacts.FirstOrDefault(x => x.ContactId == id);

            if (values == null)
            {
                // Mesaj bulunamazsa, hata sayfasına yönlendirme yapabilirsiniz
                return RedirectToAction("Error");
            }

            return View(values);
        }

        public ActionResult MarkAsRead(int id) // Okundu bilgisini güncelleme
        {
            var value = context.Contacts.Find(id);

            if (value != null)
            {
                value.IsRead = true;
                context.SaveChanges();
            }

            return RedirectToAction("ContactDetail", new { id = id });
        }
    }
}