using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolDentEx.Models
{
    [Table("HumanTeeth")]
    public class HumanTooth
    {
        [Key]
        public int HumanToothId { get; set; }
        public string ToothName { get; set; }
        public bool IsMilkTooth { get; set; }
    }
}