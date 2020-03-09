using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AH.Models
{
    public class CascadingModel
    {
        public CascadingModel()
        {
            this.Direction = new List<SelectListItem>();
            this.Type = new List<SelectListItem>();
            this.Train = new List<SelectListItem>();
            this.Station = new List<SelectListItem>();

        }

        public List<SelectListItem> Direction { get; set; }
        public List<SelectListItem> Type { get; set; }
        public List<SelectListItem> Train { get; set; }
        public List<SelectListItem> Station { get; set; }


        public int DirectionId { get; set; }
        public int TypeId { get; set; }
        public int TrainId { get; set; }
        public int StationId { get; set; }
        public bool AllowPhone { get; set; }
    }
















}
