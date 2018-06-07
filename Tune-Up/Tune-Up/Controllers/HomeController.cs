using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tune_Up.Models;
using Tune_Up.Models.DbModels;
namespace Tune_Up.Controllers
{
    public class HomeController : Controller
    {
        DbEntities db = new DbEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        // Vehicles
        public ActionResult Vehicles()
        {
            return View(db.Vehicles.ToList());
        }
        [HttpPost]
        public ActionResult CreateVehicle(Vehicle vehicle)
        {

            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }
        // Services
        public ActionResult Services()
        {
            var viewModel =
                    from pd in db.Services
                    select new ServiceHolder { Autopart = pd.Autopart, Service = pd, Vehicle = pd.Vehicle};

            return View(viewModel.ToList());
        }
        // Autoparts
        public ActionResult Autoparts()
        {
            return View(db.Autoparts.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}