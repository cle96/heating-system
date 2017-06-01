using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HeatingSystemModel.Storage;
using HeatingSystemModel.Model;

namespace HeatingSystemWebApp.Controllers
{
    public class ReadingAcknowledgingController : Controller
    {
        public ActionResult Index(int meterId,int meterReadingId)
        {
            string textDisplayed = "";
            if (meterId == 0)
            {
               textDisplayed = "Failed to update the reading";
            }
            else
            {
                using (var db = new StorageContext())
                {
                    
                    var actualMeterReading = db.MeterReadings.Where(mr => mr.Id == meterReadingId).FirstOrDefault();
                    var lastMeterReading = db.MeterReadings.Where(mr => mr.Meter.Id == meterId && mr.Id != meterReadingId && mr.Date.Year<actualMeterReading.Date.Year).OrderBy(mr => mr.Date.Year).FirstOrDefault();
                    if (lastMeterReading != null && actualMeterReading != null)
                    {
                        double lastMeterReadingKWH = lastMeterReading.kWh;
                        double actualMeterReadingKWH = actualMeterReading.kWh;

                        double percentage = (lastMeterReadingKWH / actualMeterReadingKWH) * 100;

                        if (percentage > 30)
                            textDisplayed = "This year consumption is 30% higher than last registration!";
                    }else
                    {
                        textDisplayed = "Succesfully updated !";
                    }
                }
            }
            @ViewBag.MyLabelAck = textDisplayed;
            return View();
        }

    }
}
