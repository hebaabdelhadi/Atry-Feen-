using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AH.Models
{
    public class TrainTypeAndDirectionViewModel
    {
        public TrainTypeAndDirectionViewModel()
        {
            this.Direction = new List<SelectListItem>();
            this.Type = new List<SelectListItem>();
        }

        public List<SelectListItem> Direction { get; set; }
        public List<SelectListItem> Type { get; set; }


        public int Id { get; set; }
        public int DirectionId { get; set; }
        public int TypeId { get; set; }
        public int TrainNumber { get; set; }

    }



}
