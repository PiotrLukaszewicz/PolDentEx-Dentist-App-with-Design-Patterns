using PolDentEx.DAL;
using PolDentEx.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PolDentEx.RepositoryFacade
{
    public class DoctorFacade
    {
        private readonly IDoctorRepository _repository;

        public DoctorFacade(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public Doctor GetDoctorById(int id)
        {
            return _repository.GetDoctorById(id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _repository.GetAll().ToList();
        }

        public IEnumerable GetList()
        {
            foreach (Doctor d in _repository.GetAll().ToList())
            {
                yield return new
                {
                    id = d.DoctorId,
                    name = $"{d.FirstName} {d.LastName}"
                };
            }
        }

        public void Add(Doctor doctor)
        {
            _repository.Insert(doctor);
            _repository.Save();
        }

        public void Edit(Doctor doctor)
        {
            var d = _repository.GetDoctorById(doctor.DoctorId);
            d.FirstName = doctor.FirstName;
            d.LastName = doctor.LastName;
            
            _repository.Update(d);
            _repository.Save();
        }

        public void Remove(Doctor doctor)
        {
            _repository.Delete(doctor);
            _repository.Save();
        }

        public void Remove(int idDoctor)
        {
            var d = _repository.GetDoctorById(idDoctor);
            Remove(d);
        }
    }
}