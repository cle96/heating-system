using System;
using System.Web.Mvc;
using HeatingSystemModel.Model;
using HeatingSystemModel.Storage;
using System.Linq;

namespace HeatingSystemWebApp.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index()
        {
            return View(new Meter());
        }

       [HttpPost]
        public ActionResult Index(Meter m)
        {
            Meter login;
            using (var db = new StorageContext())
            {
                login = db.Meters.Where(meter => meter.Id == m.Id).First();
            }

            if (login == null)
            {
                ViewBag.ErrorMessage = "User Not Found";
                return View(new Meter());
            }
            return RedirectToAction("Index", "MeterReadings", new { meterId = m.Id },);
        }
    }
}