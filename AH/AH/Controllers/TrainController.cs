using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AH.Models;

using Microsoft.AspNet.Identity;

namespace AH.Controllers
{    [Authorize(Roles ="Admins")]
    public class TrainController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       
        [HttpGet]
        public ActionResult ShowTrains()
        {
            
            var trains = db.Trains.ToList();
            return View(trains);
        }

        [HttpGet]
        public ActionResult AddTrain()
        {
           
            TrainTypeAndDirectionViewModel model = new TrainTypeAndDirectionViewModel();
            foreach (var direction in db.TrainDirections)
            {
                model.Direction.Add(new SelectListItem { Text = direction.Name, Value = direction.ID.ToString() });
            }
            foreach (var type in db.TypeOfTrains)
            {
                model.Type.Add(new SelectListItem { Text = type.Name, Value = type.ID.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddTrain(TrainTypeAndDirectionViewModel train)
        {
           
            if (ModelState.IsValid == true)
            {
                Train NewTrain = new Train();
                NewTrain.Number = train.TrainNumber;
                NewTrain.DirectionID = train.DirectionId;
                NewTrain.TypeID = train.TypeId;
                db.Trains.Add(NewTrain);
                db.SaveChanges();
                return RedirectToAction("ShowTrains");
            }
            return View(train);
        }

        [HttpGet]
        public ActionResult EditTrain(int TrainId)
        {
           
            var train = db.Trains.SingleOrDefault(t => t.Id == TrainId);
            TrainTypeAndDirectionViewModel model = new TrainTypeAndDirectionViewModel();
            foreach (var direction in db.TrainDirections)
            {
                model.Direction.Add(new SelectListItem { Text = direction.Name, Value = direction.ID.ToString() });
            }
            foreach (var type in db.TypeOfTrains)
            {
                model.Type.Add(new SelectListItem { Text = type.Name, Value = type.ID.ToString() });
            }
            model.Id = train.Id;
            model.TrainNumber = train.Number;
            model.DirectionId = train.DirectionID;
            model.TypeId = train.TypeID;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditTrain(int TrainId, TrainTypeAndDirectionViewModel model)
        {
           
            var train = db.Trains.SingleOrDefault(t => t.Id == TrainId);
            train.Number = model.TrainNumber;
            train.TypeID = model.TypeId;
            train.DirectionID = model.DirectionId;
            db.SaveChanges();
            return RedirectToAction("ShowTrains");
        }

        [HttpGet]
        public ActionResult DeleteTrain(int TrainId)
        {
           
            var train = db.Trains.SingleOrDefault(i => i.Id == TrainId);
            return View(train);
        }

        [HttpPost]
        public ActionResult DeleteTrain(int TrainId, Train DeletedTrain)
        {
          
            var train = db.Trains.SingleOrDefault(t => t.Id == TrainId);
            db.Trains.Remove(train);
            db.SaveChanges();
            return RedirectToAction("ShowTrains");
        }
    }
}