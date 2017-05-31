﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeatingSystemModel.Model;
using HeatingSystemModel.Storage;
using HeatingSystemWebApp.Models;

namespace HeatingSystemWebApp.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        public ActionResult Index(int? id = null)
        {
            LoginViewModel model = new LoginViewModel();

            using (var db = new StorageContext())
            {
                    if (id != null)
                    {
                        model.Meter = db.Meters.Find(id);
                    }
                }
                return View(model.Meter);
            }

        [HttpPost]
        public ActionResult Login(Meter meter)
        {
            Meter login;
            using (var db = new StorageContext())
            {
                login = db.Meters.Find(meter.Id);
            }

            if (login == null)
            {
                ViewBag.ErrorMessage = "User Not Found";
            }
            return this.RedirectToAction("MeterReadingsController", new { id = login.Id });
        }
    }
}