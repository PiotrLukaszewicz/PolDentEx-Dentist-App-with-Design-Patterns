using PolDentEx.DAL;
using PolDentEx.Models;
using PolDentEx.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace PolDentEx.RepositoryFacade
{
    public class AppointmentFacade
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentFacade(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _repository.GetAll().ToList();
        }

        public Appointment GetAppointment(int idAppointment)
        {
            return _repository.GetAppointmentById(idAppointment);
        }

        public IEnumerable<AppointmentViewModel> GetViewModel()
        {
            foreach (Appointment a in _repository.GetAll().ToList())
            {
                yield return new AppointmentViewModel
                {
                    DoctorNameAndSurname = a.Doctor.FirstName + " " + a.Doctor.LastName,
                    PatientNameAndSurname = a.Patient.PatientDetails.FirstName + " " + a.Patient.PatientDetails.LastName,
                    PESEL = a.Patient.PESEL,
                    AppointmentType = a.Type.ToString(),
                    AppointmentDate = a.Date.ToString(),
                    AppointmentId = a.AppointmentId
                };
            }
        } 

        public void Add(Appointment appointment)
        {
            _repository.Insert(appointment);
            _repository.Save();
        }

        public void Edit(Appointment appointment)
        {
            var a = _repository.GetAppointmentById(appointment.AppointmentId);

            a.DoctorId = appointment.DoctorId;
            a.PatientId = appointment.PatientId;
            a.Date = appointment.Date;
            a.Type = appointment.Type;

            _repository.Update(a);
            _repository.Save();
        }

        public void Remove(Appointment appointment)
        {
            _repository.Delete(appointment);
            _repository.Save();
        }

        public void Remove(int idAppointment)
        {
            Remove(idAppointment);
        }
    }
}