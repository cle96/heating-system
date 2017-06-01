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
            return View();
        }


    }
}