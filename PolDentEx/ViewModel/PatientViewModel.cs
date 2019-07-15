namespace PolDentEx.ViewModel
{
    /// <summary>
    /// Model służacy do eksportu danych do JSON oraz wyświetlania ich w dataTable w panelu głównym
    /// </summary>
    public class PatientViewModel
    {
        public int  PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PatientCardId { get; set; }
        public string DoctorNameAndSurname { get; set; }
        public string PESEL { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }

    }
}