using PolDentEx.Models;
using System;
using System.Linq;

namespace PolDentEx.DAL
{
    public class PatientApiRepository : IPatientRepository
    {
        public IQueryable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Patient obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}