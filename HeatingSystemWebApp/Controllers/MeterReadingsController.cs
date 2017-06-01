using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HeatingSystemModel.Model;
using HeatingSystemModel.Storage;
using HeatingSystemModel.Service;

namespace HeatingSystemWebApp.Controllers
{
    public class MeterReadingsController : Controller
    {
        private StorageContext db = new StorageContext();

        // GET: MeterReadings
        public ActionResult Index(int meterId)
        {
            return View(db.MeterReadings.Where(m=>m.Meter.Id == meterId).ToList());
        }

        // GET: MeterReadings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeterReading meterReading = db.MeterReadings.Find(id);
            if (meterReading == null)
            {
                return HttpNotFound();
            }
            return View(meterReading);
        }

        // GET: MeterReadings/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: MeterReadings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeterReading meterReading = db.MeterReadings.Find(id);
            if (meterReading == null)
            {
                return HttpNotFound();
            }
            return View(meterReading);
        }

        // POST: MeterReadings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,kWh,CubeMeters,UsageHours")] MeterReading meterReading)
        {
            if(meterReading != null) { 
                HeatingSystemModel.Service.Service.UpdateMeterReading(meterReading);
                return RedirectToAction("Index", new { meterId = meterReading.Meter.Id });
            }
            return View(meterReading);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
