using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AH.Models;

using Microsoft.AspNet.Identity;

namespace AH.Controllers
{
    [Authorize(Roles = "Admins")]
    public class StationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
            // GET: Station
            public ActionResult Index()
            {
                return View();
            }

            [HttpGet]
            public ActionResult ShowStations()
            {
               
                var stations = db.Stations.ToList();
                return View(stations);
            }

            [HttpGet]
            public ActionResult AddStation()
            {
                return View();
            }

            [HttpPost]
            public ActionResult AddStation(Station station)
            {
                if (ModelState.IsValid == true)
                {
                    Station NewStation = new Station();
                    NewStation.Name = station.Name;
                    db.Stations.Add(NewStation);
                    db.SaveChanges();
                    return RedirectToAction("ShowStations");
                }
                return View(station);
            }

            [HttpGet]
            public ActionResult EditStation(int StationId)
            {
                
                var station = db.Stations.SingleOrDefault(i => i.ID == StationId);
                return View(station);
            }

            [HttpPost]
            public ActionResult EditStation(int StationId, Station updatedStation)
            {
               
                var station = db.Stations.SingleOrDefault(i => i.ID == StationId);
                station.Name = updatedStation.Name;
                db.SaveChanges();
                return RedirectToAction("ShowStations");
            }

            [HttpGet]
            public ActionResult DeleteStation(int StationId)
            {
                
                var station = db.Stations.SingleOrDefault(i => i.ID == StationId);
                return View(station);
            }

            [HttpPost]
            public ActionResult DeleteStation(int StationId, Station DeletedTrain)
            {
               
                var station = db.Stations.SingleOrDefault(i => i.ID == StationId);
                db.Stations.Remove(station);
                db.SaveChanges();
                return RedirectToAction("Showstations");
            }
        }
    }










