using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Tune_Up.Models.DbModels;

namespace Tune_Up.Controllers
{
    public class ServiceController : Controller
    {
        DbEntities db = new DbEntities();

        // GET: Service
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(Tune_Up.Models.Service newService )
        {
            db.Services.Add(newService);
            db.SaveChanges();
            return RedirectToAction("Services", "Home");
        }
        [HttpPost]
        public ActionResult SaveService(Tune_Up.Models.Service item)
        {
            var itemToSave = db.Services.Where(s => s.Id == item.Id).FirstOrDefault();
            itemToSave.Master = item.Master;
            itemToSave.ServiceDate = item.ServiceDate;
            itemToSave.Distance = item.Distance;
            db.SaveChanges();
            return RedirectToAction("Services", "Home");
        }
        [HttpGet]
        public ActionResult EditService(int? id)
        {
            var item = db.Services.Where(s => s.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpGet]
        public ActionResult DeleteService(int? id)
        {
            var item = db.Services.Where(s => s.Id == id).FirstOrDefault();
            db.Services.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Services", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}