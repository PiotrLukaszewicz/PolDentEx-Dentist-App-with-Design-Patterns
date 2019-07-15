using PolDentEx.Builder;
using PolDentEx.DAL;
using PolDentEx.Models;
using PolDentEx.ViewModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace PolDentEx.RepositoryFacade
{
    public class PatientFacade
    {
        private readonly IPatientRepository _repository;
        private readonly IPatientCardRepository _patientCardRepository;
        private readonly IPatientDetailsRepository _patientDetailsRepository;
        private readonly IToothRepository _toothRepository;

        public PatientFacade(IPatientRepository repository, IPatientCardRepository patientCardRepository, IPatientDetailsRepository patientDetailsRepository, IToothRepository toothRepository)
        {
            _repository = repository;
            _patientCardRepository = patientCardRepository;
            _patientDetailsRepository = patientDetailsRepository;
            _toothRepository = toothRepository;
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _repository.GetAll().ToList();
        }

        public Patient GetPatientById(int idPatient)
        {
            return _repository.GetPatientById(idPatient);
        }

        public IEnumerable<PatientViewModel> GetViewModel()
        {
            foreach (Patient p in _repository.GetAll().ToList())
            {
                yield return new PatientViewModel
                {
                    PatientId = p.PatientId,
                    Name = p.PatientDetails.FirstName,
                    Surname = p.PatientDetails.LastName,
                    DoctorNameAndSurname = p.Doctor.FirstName + " " + p.Doctor.LastName,
                    PESEL = p.PESEL,
                    DateOfBirth = p.Date.ToString(),
                    PhoneNumber = p.PatientDetails.PhoneNumber
                };
            }
        }

        public IEnumerable GetList()
        {
            foreach (Patient p in _repository.GetAll().ToList())
            {
                yield return new
                {
                    id = p.PatientId,
                    name = $"{p.PatientDetails.FirstName} {p.PatientDetails.LastName}"
                };
            }
        }

        public void Add(Patient patient)
        {
            var details = patient.PatientDetails;
            details.PatientDetailsId = 0;
            _patientDetailsRepository.Insert(details);

            var card = patient.PatientCard;
            card.PatientCardId = 0;
            _patientCardRepository.Insert(card);
            _patientCardRepository.Save();

            _repository.Insert(patient);
            _repository.Save();

            //card.Jaw = GetJaw(patient);
            //_repository.Save();
        }

        private List<Tooth> GetJaw(Patient patient)
        {
            JawBuilder builder;
            if (patient.IsChild)
                builder = new ChildJawBuilder();
            else
                builder = new AdultJawBuilder();

            builder.BuildJaw(patient.PatientId);
            return builder.GetResult();
        }

        public void Edit(Patient patient)
        {
            var p = _repository.GetPatientById(patient.PatientId);
            p.DoctorId = patient.DoctorId;
            p.Date = patient.Date;
            p.IsChild = patient.IsChild;
            p.PESEL = patient.PESEL;
            _repository.Update(p);

            var d = _patientDetailsRepository.GetPatientDetailsById(p.PatientDetailsId);
            d.FirstName = patient.PatientDetails.FirstName;
            d.LastName = patient.PatientDetails.LastName;
            d.PhoneNumber = patient.PatientDetails.PhoneNumber;
            _patientDetailsRepository.Update(d);

            var c = _patientCardRepository.GetPatientCardById(p.PatientCardId);
            c.AllergiesFile = patient.PatientCard.AllergiesFile;
            c.DiseaseFile = patient.PatientCard.DiseaseFile;
            c.HistoryFile = patient.PatientCard.HistoryFile;
            c.RtgFile = patient.PatientCard.RtgFile;
            c.TakenMedicinesFile = patient.PatientCard.TakenMedicinesFile;
            _patientCardRepository.Update(c);

            _repository.Save();
        }

        public void Remove(Patient patient)
        {
            _repository.Delete(patient);

            var details = _patientDetailsRepository.GetPatientDetailsById(patient.PatientDetailsId);
            _patientDetailsRepository.Delete(details);

            var card = _patientCardRepository.GetPatientCardById(patient.PatientCardId);
            _patientCardRepository.Delete(card);

            _repository.Save();
        }

        public void Remove(int idPatient)
        {
            var p = _repository.GetPatientById(idPatient);
            Remove(p);
        }

        public TeethIterator GetTeethIterator(int patientId)
        {
            var teeth = GetTeeth(patientId);
            return new TeethIterator(teeth);
        }

        public List<Tooth> GetTeeth(int patientId)
        {
            var patient = _repository.GetPatientById(patientId);
            return _toothRepository.GetAll().Where(e => e.PatientCardId == patient.PatientCardId && !e.Extracted).ToList();
        }

        public void Edit(Tooth tooth)
        {
            var t = _toothRepository.GetToothById(tooth.ToothId);
            t.Note1 = tooth.Note1;
            t.Note2 = tooth.Note2;
            t.Note3 = tooth.Note3;
            t.Note4 = tooth.Note4;

            _toothRepository.Update(t);
            _toothRepository.Save();
        }
    }
}