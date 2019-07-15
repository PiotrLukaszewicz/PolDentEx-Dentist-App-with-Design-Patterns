using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolDentEx.Models
{
    [Table("Jaws")]
    public class Jaw
    {
        [Key]
        public int JawId { get; set; }

        public string Description { get; set; }

        public bool State { get; set; }

        [InverseProperty("JawProp")]
        public virtual ICollection<Tooth> Teeth { get; set; }
    }
}