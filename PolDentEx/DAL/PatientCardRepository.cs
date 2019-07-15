using PolDentEx.Models;
using System.Linq;

namespace PolDentEx.DAL
{
    public interface IPatientCardRepository : IBaseRepository<PatientCard>
    {
        PatientCard GetPatientCardById(int patientCardId);
    }

    public class PatientCardRepository : BaseRepository<PatientCard>, IPatientCardRepository
    {
        public PatientCard GetPatientCardById(int patientCardId)
        {
            return GetAll().FirstOrDefault(e => e.PatientCardId == patientCardId);
        }

        public override IQueryable<PatientCard> GetAll()
        {
            IQueryable<PatientCard> query = DbContext.Instance.ApplicationDbContext.Set<PatientCard>()
                .Include("Jaw");
            return query;
        }
    }
}