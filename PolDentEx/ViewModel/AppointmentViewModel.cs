using System.ComponentModel.DataAnnotations;

namespace PolDentEx.ViewModel
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public string DoctorNameAndSurname { get; set; }
        public string PatientNameAndSurname { get; set; }
        public string PESEL { get; set; }
        public string AppointmentType { get; set; }
        [DataType(DataType.Date)]
        public string AppointmentDate{ get; set; }
    }
}