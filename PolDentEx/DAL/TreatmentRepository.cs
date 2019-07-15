using PolDentEx.Models;
using System.Linq;

namespace PolDentEx.DAL
{
    public interface ITreatmentRepository : IBaseRepository<Treatment>
    {
        Treatment GetTreatmentById(int treatmentId);
    }
    
    public class TreatmentRepository : BaseRepository<Treatment>, ITreatmentRepository
    {
        public Treatment GetTreatmentById(int treatmentId)
        {
            return GetAll().FirstOrDefault(e => e.TreatmentId == treatmentId);
        }

        public override IQueryable<Treatment> GetAll()
        {
            IQueryable<Treatment> query = DbContext.Instance.ApplicationDbContext.Set<Treatment>();
            return query;
        }
    }
}