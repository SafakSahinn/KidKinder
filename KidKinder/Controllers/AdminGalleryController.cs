using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminGalleryController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult GalleryList()
        {
            var values = context.Galleries.ToList();
            return View(values);
        }

        public ActionResult ActiveGallerytList()
        {
            var values = context.Galleries.Where(x => x.Status == true).ToList();
            return View(values);
        }

        public ActionResult PasiveGallerytList()
        {
            var values = context.Galleries.Where(x => x.Status == false).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGallery(Gallery gallery)
        {
            context.Galleries.Add(gallery);
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }

        public ActionResult DeleteGallery(int id)
        {
            var values = context.Galleries.Find(id);
            context.Galleries.Remove(values);
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }

        [HttpGet]
        public ActionResult UpdateGallery(int id)
        {
            var values = context.Galleries.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateGallery(Gallery gallery)
        {
            var values = context.Galleries.Find(gallery.GalleryId);
            values.ImageUrl = gallery.ImageUrl;
            values.Status = gallery.Status;
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }
    }
}