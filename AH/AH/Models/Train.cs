using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AH.Models
    
{


    [Table("Train")]
    public class Train
    {
        public Train()
    {
        this.RealArrivedTimeOfTrains = new HashSet<RealArrivedTimeOfTrain>();
    }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }

        [Required]
        
        [ForeignKey("TrainDirection")]
        public int DirectionID { get; set; }

        [Required]
        
        [ForeignKey("TypeOfTrain")]
        public int TypeID { get; set; }

        public virtual ICollection<RealArrivedTimeOfTrain> RealArrivedTimeOfTrains { get; set; }
        
        public virtual TrainDirection TrainDirection { get; set; }

        public virtual TypeOfTrain TypeOfTrain { get; set; }
}
}