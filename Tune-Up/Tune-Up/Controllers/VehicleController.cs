using System.Linq;
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
        public ActionResult SaveVehicle(Tune_Up.Models.Vehicle item)
        {
            var itemToSave = db.Vehicles.Where(s => s.Id == item.Id).FirstOrDefault();
            itemToSave.EngineVolume = item.EngineVolume;
            itemToSave.Fuel = item.Fuel;
            itemToSave.ManufacturingDate = item.ManufacturingDate;
            itemToSave.Name = item.Name;
            itemToSave.Photo = item.Photo;
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