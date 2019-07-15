using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolDentEx.Models
{
    [Table("Teeth")]
    public class Tooth
    {
        [Key]
        public int ToothId { get; set; }

        [ForeignKey("HumanTooth")]
        public int HumanToothId { get; set; }

        public string Note1 { get; set; }
        public string Note2 { get; set; }
        public string Note3 { get; set; }
        public string Note4 { get; set; }
        public bool Extracted { get; set; }

        [ForeignKey("PatientCard")]
        public int PatientCardId { get; set; }

        public virtual PatientCard PatientCard { get; set; }
        public virtual HumanTooth HumanTooth { get; set; }
    }


}