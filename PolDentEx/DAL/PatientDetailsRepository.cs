using PolDentEx.Models;
using System.Linq;

namespace PolDentEx.DAL
{
    public interface IPatientDetailsRepository : IBaseRepository<PatientDetails>
    {
        PatientDetails GetPatientDetailsById(int patientDetailsId);
    }

    public class PatientDetailsRepository : BaseRepository<PatientDetails>, IPatientDetailsRepository
    {
        public PatientDetails GetPatientDetailsById(int patientDetailsId)
        {
            return GetAll().FirstOrDefault(e => e.PatientDetailsId == patientDetailsId);
        }

        public override IQueryable<PatientDetails> GetAll()
        {
            IQueryable<PatientDetails> query = DbContext.Instance.ApplicationDbContext.Set<PatientDetails>();
            return query;
        }
    }
}