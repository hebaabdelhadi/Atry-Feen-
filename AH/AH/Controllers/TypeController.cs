using AH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AH.Controllers
{
    [Authorize(Roles = "Admins")]
    public class TypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        [HttpGet]
        public ActionResult showTypes()
        {
           
            var types = db.TypeOfTrains.ToList();
            return View(types);
        }

        [HttpGet]
        public ActionResult AddType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddType(TypeOfTrain typeOfTrain)
        {
           
            if (ModelState.IsValid == true)
            {
                TypeOfTrain NewType = new TypeOfTrain();
                NewType.Name = typeOfTrain.Name;
                db.TypeOfTrains.Add(NewType);
                db.SaveChanges();
                return RedirectToAction("ShowTypes");
            }
            return View(typeOfTrain);
        }

        [HttpGet]
        public ActionResult EditType(int TypeId)
        {
           
            var type = db.TypeOfTrains.SingleOrDefault(t => t.ID == TypeId);
            return View(type);
        }

        [HttpPost]
        public ActionResult EditType(int TypeId, TypeOfTrain updatedType)
        {
            
            var type = db.TypeOfTrains.SingleOrDefault(t => t.ID == TypeId);
            type.Name = updatedType.Name;
            db.SaveChanges();
            return RedirectToAction("ShowTypes");
        }

        [HttpGet]
        public ActionResult DeleteType(int TypeId)
        {
           
            var type = db.TypeOfTrains.SingleOrDefault(t => t.ID == TypeId);
            return View(type);
        }

        [HttpPost]
        public ActionResult DeleteType(int TypeId, TypeOfTrain deletedType)
        {
            
            var type = db.TypeOfTrains.SingleOrDefault(t => t.ID == TypeId);
            db.TypeOfTrains.Remove(type);
            db.SaveChanges();
            return RedirectToAction("ShowTypes");
        }
    }

}
