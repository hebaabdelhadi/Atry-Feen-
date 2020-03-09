using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AH.Models;

using Microsoft.AspNet.Identity;


namespace AH.Controllers
{    [Authorize]
    public class ActualPlaceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();




        public ActionResult Answer()
        {
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Name");
            ViewBag.TrainID = new SelectList(db.Trains, "ID", "Number");
            ViewBag.DirectionID = new SelectList(db.RealArrivedTimeOfTrains, "ID", "AllowPhone");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Answer(RealArrivedTimeOfTrain realArrivedTimeOfTrain)
        {
            realArrivedTimeOfTrain.PersonID = User.Identity.GetUserId();

            db.RealArrivedTimeOfTrains.Add(realArrivedTimeOfTrain);
            db.SaveChanges();



            ViewBag.StationID = new SelectList(db.Stations, "ID", "Name");
            ViewBag.TrainID = new SelectList(db.Trains, "ID", "Number");
            return View(realArrivedTimeOfTrain);
        }


        public ActionResult Search()
        {
           
            ViewBag.TrainID = new SelectList(db.Trains, "ID", "Number");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(RealArrivedTimeOfTrain realArrivedTimeOfTrain)
        {


            realArrivedTimeOfTrain.PersonID = User.Identity.GetUserId();
            if (realArrivedTimeOfTrain == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Result", new { id = realArrivedTimeOfTrain.TrainID });

        }

        [HttpGet]
        public ActionResult Result(int id)
        {
            int inital = -15;
            var result = DoMagic(id, inital);
            
            return View(result);
        }
       


        [HttpGet]
        public ActionResult GetSurveyDetails(int trainId, int stationId, int backperiod, DateTime now)
        {
            return View("SurveyDetails", GetSurveyInfo(trainId, stationId, backperiod, now));
        }
        

        private List<StationCount> DoMagic(int trainID, int initialBackPeriod = -15)
        {
           
            DateTime time = DateTime.Now;
            DateTime updated = time;
            string hour = "0";
            int minute = 0;
            string em = "";
                        if (initialBackPeriod > -60)
                updated = time.Add(new TimeSpan(0, initialBackPeriod, 0));
            else
                updated = time.Add(new TimeSpan(initialBackPeriod, 0, 0));
            updated = time.Add(new TimeSpan(0, initialBackPeriod, 0));

            List<StationCount> result = db.RealArrivedTimeOfTrains
                                           .Where(item => item.TrainID == trainID &&
                                               (item.Time >= updated && item.Time <= time))
                                               .GroupBy(G => new { G.Station.Name, G.StationID, G.TrainID })
                                               .Select(e => new StationCount
                                               {
                                                   MyStation = e.Key.Name,
                                                   MyCount = e.Count(),
                                                   StationID = e.Key.StationID,
                                                   TrainID = e.Key.TrainID,
                                                   LastBackPeriod = initialBackPeriod/*hour+":"+minute+em*/,
                                                   Now = time
                                               }).OrderByDescending(o => o.MyCount).ToList();

            if (result.Count() <= 0 && initialBackPeriod > -120)
            {
                initialBackPeriod -= 15;
                result = DoMagic(trainID, initialBackPeriod);
            }

            return result;
        }

        /**************************************************/
        private List<SurveyDetailViewModel> GetSurveyInfo(int trainID, int stationID, int initialBackPeriod, DateTime now)
        {
            
            DateTime time = DateTime.Now;
            DateTime updated = time;
            if (initialBackPeriod > -60)
                updated = time.Add(new TimeSpan(initialBackPeriod, 0, 0));
            else
                updated = time.Add(new TimeSpan(0, initialBackPeriod, 0));
            List<SurveyDetailViewModel> result =
                    db.RealArrivedTimeOfTrains
                   .Where(item =>
                     item.TrainID == trainID && item.StationID == stationID && item.AllowPhone &&
                    /*item.Person.ShowPhone &&*/
                    (item.Time >= updated && item.Time <= time)
                   )
                   .GroupBy(G => new { G.Person.Name, G.Person.PhoneNumber })
                   .Select(e => new SurveyDetailViewModel
                   {
                       Name = e.Key.Name,
                       Phone = e.Key.PhoneNumber
                   }).ToList();

            return result;
        }
    }
}
