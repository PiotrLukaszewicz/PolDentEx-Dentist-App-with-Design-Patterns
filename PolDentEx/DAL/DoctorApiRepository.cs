using PolDentEx.Models;
using System;
using System.Linq;

namespace PolDentEx.DAL
{
    public class DoctorApiRepository : IDoctorRepository
    {
        public IQueryable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Doctor obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Doctor obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Doctor GetDoctorById(int doctorId)
        {
            throw new NotImplementedException();
        }
    }
}