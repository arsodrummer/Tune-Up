using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Tune_Up.Models.DbModels;

namespace Tune_Up.Controllers
{
    public class VehicleController : Controller
    {
        DbEntities db = new DbEntities();

        public ActionResult AddVehicle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVehicle(Tune_Up.Models.Vehicle newVehicle)
        {
            db.Vehicles.Add(newVehicle);
            db.SaveChanges();
            return RedirectToAction("Vehicles", "Home");
        }
        [HttpPost]
        public ActionResult SaveVehicle(Tune_Up.Models.Vehicle data, HttpPostedFileBase photo)
        {
            var itemToSave = db.Vehicles.Where(s => s.Id == data.Id).FirstOrDefault();
            itemToSave.EngineVolume = data.EngineVolume;
            itemToSave.Fuel = data.Fuel;
            itemToSave.ManufacturingDate = data.ManufacturingDate;
            itemToSave.Name = data.Name;
            //itemToSave.Photo = photo.FileName;

            if (photo != null && photo.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(photo.FileName));
                photo.SaveAs(path);
            }

            db.SaveChanges();
            return RedirectToAction("Vehicles", "Home");
        }
        [HttpGet]
        public ActionResult EditVehicle(int? id)
        {
            var item = db.Vehicles.Where(s => s.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpGet]
        public ActionResult DeleteVehicle(int? id)
        {
            var item = db.Vehicles.Where(s => s.Id == id).FirstOrDefault();
            db.Vehicles.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Vehicles", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}