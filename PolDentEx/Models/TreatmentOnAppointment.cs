using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolDentEx.Models
{
    [Table("TreatmentOnAppointments")]
    public class TreatmentOnAppointment
    {
        [Key]
        public int TreatmentOnAppointmentId { get; set; }

        public string Description { get; set; }

        [ForeignKey("Treatment")]
        public int TreatmentId { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        
        
        public virtual  Treatment Treatment { get; set; }
        public virtual  Appointment Appointment { get; set; }

    }
}