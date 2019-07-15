using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolDentEx.Models
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId{ get; set; }

        [ForeignKey("PatientCard")]
        public int PatientCardId { get; set; }

        [ForeignKey("PatientDetails")]
        public int PatientDetailsId { get; set; }

        [Required]
        public string PESEL { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsChild { get; set; }

        public virtual PatientDetails PatientDetails { get; set; }
        public virtual PatientCard PatientCard { get; set; }
        public virtual Doctor Doctor { get; set; }
    }

}