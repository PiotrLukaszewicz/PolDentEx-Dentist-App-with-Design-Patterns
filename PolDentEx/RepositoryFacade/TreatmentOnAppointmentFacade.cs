using PolDentEx.DAL;
using PolDentEx.Models;
using System.Collections.Generic;
using System.Linq;

namespace PolDentEx.RepositoryFacade
{
    public class TreatmentOnAppointmentFacade
    {
        private readonly ITreatmentOnAppointmentRepository _repository;
        public TreatmentOnAppointmentFacade(ITreatmentOnAppointmentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TreatmentOnAppointment> GetTreatmentOnAppointments()
        {
            return _repository.GetAll().ToList();
        }

        public TreatmentOnAppointment TreatmentOnAppointment(int idTreatmentOnAppointment)
        {
            return _repository.GetTreatmentOnAppointmentById(idTreatmentOnAppointment);
        }

        public void Add(TreatmentOnAppointment treatmentOnAppointment)
        {
            _repository.Insert(treatmentOnAppointment);
            _repository.Save();
        }

        public void Edit(TreatmentOnAppointment treatmentOnAppointment)
        {
            var t = _repository.GetTreatmentOnAppointmentById(treatmentOnAppointment.TreatmentOnAppointmentId);
            t.TreatmentId = treatmentOnAppointment.TreatmentId;
            t.AppointmentId = treatmentOnAppointment.AppointmentId;
            t.Description = treatmentOnAppointment.Description;

            _repository.Update(t);
            _repository.Save();
        }

        public void Remove(TreatmentOnAppointment treatmentOnAppointment)
        {
            _repository.Delete(treatmentOnAppointment);
            _repository.Save();
        }

        public void Remove(int idTreatmentOnAppointment)
        {
            var t = _repository.GetTreatmentOnAppointmentById(idTreatmentOnAppointment);
            Remove(t);
        }
    }
}