using PolDentEx.Models;
using System.Linq;

namespace PolDentEx.DAL
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Patient GetPatientById(int patientId);
    }

    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public Patient GetPatientById(int id)
        {
            return GetAll().FirstOrDefault(e => e.PatientId == id);
        }

        public override IQueryable<Patient> GetAll()
        {
            IQueryable<Patient> query = DbContext.Instance.ApplicationDbContext.Set<Patient>()
                .Include("PatientCard").Include("PatientDetails").Include("Doctor");
            return query;
        }
    }
}