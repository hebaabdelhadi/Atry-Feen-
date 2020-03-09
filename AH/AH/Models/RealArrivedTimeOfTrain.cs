using AH.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AH.Models
{


       [Table("RealArrivedTimeOfTrain")]
        public  class RealArrivedTimeOfTrain
        {
            [Required]
           
            [ForeignKey("Person")]
            public string PersonID { get; set; }


            [Required]
          
            [ForeignKey("Train")]
             public int TrainID { get; set; }

            [Required]
            
            [ForeignKey("Station")]
            public int StationID { get; set; }
            
            public  DateTime  Time { get; set; } = DateTime.Now;

            public bool AllowPhone { get; set; }

        [Key]
           [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
           public int ID { get; set; }
       
           public virtual ApplicationUser Person { get; set; }
            public virtual Station Station { get; set; }
            public virtual Train Train { get; set; }
        }





    
}