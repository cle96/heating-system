using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeatingSystemAdministration;

namespace HeatingSystemWebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index(int? id = null)
        {

            using (var db = new Storage.StorageContext())
            {
                if (id != null)
                {
                    model.Customer = db.Customers.Find(id);
                }
                model.Matches = db.Matches.Where(m => m.MatchStart >= DateTime.Now).ToList();
            }
            return View(model);
        }
    }
}