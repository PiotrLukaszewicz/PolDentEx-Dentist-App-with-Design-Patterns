using System;
using System.Collections.Generic;
using PolDentEx.Models;

namespace PolDentEx_Data.DAL
{
    public interface IPatientRepository : IDisposable
    {
        IEnumerable<Patient> GetStudents();
        Patient GetStudentByID(int studentId);
        void InsertStudent(Patient student);
        void DeleteStudent(int studentID);
        void UpdateStudent(Patient student);
        void Save();
    }
}