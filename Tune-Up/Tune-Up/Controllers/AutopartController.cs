using System.Linq;
using System.Web.Mvc;
using Tune_Up.Models.DbModels;

namespace Tune_Up.Controllers
{
    public class AutopartController : Controller
    {
        DbEntities db = new DbEntities();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddAutopart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAutopart(Tune_Up.Models.Autopart newAutopart)
        {
            db.Autoparts.Add(newAutopart);
            db.SaveChanges();
            return RedirectToAction("Autoparts", "Home");
        }
        [HttpPost]
        public ActionResult SaveAutopart(Tune_Up.Models.Autopart item)
        {
            var itemToSave = db.Autoparts.Where(s => s.Id == item.Id).FirstOrDefault();
            itemToSave.Manufacturer = item.Manufacturer;
            itemToSave.Name = item.Name;
            itemToSave.Photo = item.Photo;
            db.SaveChanges();
            return RedirectToAction("Autoparts", "Home");
        }
        [HttpGet]
        public ActionResult EditAutopart(int? id)
        {
            var item = db.Autoparts.Where(s => s.Id == id).FirstOrDefault();
            return View(item);
        }
        [HttpGet]
        public ActionResult DeleteAutopart(int? id)
        {
            var item = db.Autoparts.Where(s => s.Id == id).FirstOrDefault();
            db.Autoparts.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Autoparts", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}