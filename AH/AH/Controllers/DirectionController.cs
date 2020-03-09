using AH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AH.Controllers
{

    [Authorize(Roles = "Admins")]
    public class DirectionController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Direction
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowDirections()
        {
            
            var directions = db.TrainDirections.ToList();
            return View(directions);
        }

        [HttpGet]
        public ActionResult AddDirection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDirection(TrainDirection direction)
        {
            
            if (ModelState.IsValid == true)
            {
                TrainDirection NewDirection = new TrainDirection();
                NewDirection.Name = direction.Name;
                db.TrainDirections.Add(NewDirection);
                db.SaveChanges();
                return RedirectToAction("ShowDirections");
            }
            return View(direction);
        }

        [HttpGet]
        public ActionResult EditDirection(int DirectionId)
        {
           
            var direction = db.TrainDirections.SingleOrDefault(d => d.ID == DirectionId);
            return View(direction);
        }

        [HttpPost]
        public ActionResult EditDirection(int DirectionId, TrainDirection updatedDirection)
        {
            
            var direction = db.TrainDirections.SingleOrDefault(d => d.ID == DirectionId);
            direction.Name = updatedDirection.Name;
            db.SaveChanges();
            return RedirectToAction("ShowDirections");
        }

        [HttpGet]
        public ActionResult DeleteDirection(int DirectionId)
        {
            
            var direction = db.TrainDirections.SingleOrDefault(d => d.ID == DirectionId);
            return View(direction);
        }

        [HttpPost]
        public ActionResult DeleteDirection(int DirectionId, TrainDirection DeletedDirection)
        {
            
            var direction = db.TrainDirections.SingleOrDefault(d => d.ID == DirectionId);
            db.TrainDirections.Remove(direction);
            db.SaveChanges();
            return RedirectToAction("ShowDirections");
        }
    }







}
