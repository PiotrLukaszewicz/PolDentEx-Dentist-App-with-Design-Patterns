using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace PolDentEx.Models
{
    [Table("PatientCards")]
    public class PatientCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Identyfikator karty pacjenta")]
        public int PatientCardId { get; set; }
        [Display(Name = "Historia pacjenta")]
        public string HistoryFile { get; set; }
        [Display(Name = "Alergie")]
        public string AllergiesFile { get; set; }
        [Display(Name = "Historia choroby")]
        public string DiseaseFile { get; set; }
        [Display(Name = "Leki")]
        public string TakenMedicinesFile { get; set; }
        [Display(Name = "Zdjęcia RTG")]
        public string RtgFile { get; set; }
        
        public List<Tooth> Jaw { get; set; }
    }
}