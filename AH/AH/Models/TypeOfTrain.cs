﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AH.Models
{
    [Table("TypeOfTrain")]
    public class TypeOfTrain
    {
        public TypeOfTrain()
        {
            this.Trains = new HashSet<Train>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]

        public string Name { get; set; }

        public virtual ICollection<Train> Trains { get; set; }
    }
}