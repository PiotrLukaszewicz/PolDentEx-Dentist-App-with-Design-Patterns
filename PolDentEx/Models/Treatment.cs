using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolDentEx.Models
{
    [Table("Treatments")]
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Nfzid { get; set; }
    }

}