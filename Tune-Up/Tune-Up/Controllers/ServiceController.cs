using System;
using System.Linq;
using System.Web.Mvc;
using Tune_Up.Models;
using Tune_Up.Models.DbModels;

namespace Tune_Up.Controllers
{
    public class ServiceController : Controller
    {
        DbEntities db = new DbEntities();

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
            string v = Request.Form["vehicleId"];
            int vId = 0;
            Int32.TryParse(v, out vId);
            Vehicle vehicle = db.Vehicles.Where(s => s.Id == vId).FirstOrDefault();

            string a = Request.Form["autopartId"];
            int aId = 0;
            Int32.TryParse(a, out aId);
            Autopart autopart = db.Autoparts.Where(s => s.Id == aId).FirstOrDefault();

            var itemToSave = db.Services.Where(s => s.Id == item.Id).FirstOrDefault();

            itemToSave.Master = item.Master;
            itemToSave.ServiceDate = item.ServiceDate;
            itemToSave.Distance = item.Distance;
            itemToSave.Vehicle = vehicle;
            itemToSave.Autopart = autopart;
            db.SaveChanges();
            return RedirectToAction("Services", "Home");
        }
        [HttpGet]
        public ActionResult EditService(int? id)
        {
            var item = db.Services.Where(s => s.Id == id).FirstOrDefault();
            ViewBag.Vehicles = db.Vehicles.ToList();
            ViewBag.Autoparts = db.Autoparts.ToList();
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