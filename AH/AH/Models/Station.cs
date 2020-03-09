using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AH.Models
{

    [Table("Station")]
    public  class Station
    {
        public Station()
        {
            this.RealArrivedTimeOfTrains = new HashSet<RealArrivedTimeOfTrain>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<RealArrivedTimeOfTrain> RealArrivedTimeOfTrains { get; set; }
    }
}