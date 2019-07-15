using PolDentEx.Models;
using System.Linq;

namespace PolDentEx.DAL
{
    public interface IToothRepository : IBaseRepository<Tooth>
    {
        Tooth GetToothById(int patientId);
    }
    public class ToothRepository : BaseRepository<Tooth>, IToothRepository
    { 
        public Tooth GetToothById(int id)
        {
            return GetAll().FirstOrDefault(e => e.ToothId == id);
        }

        public override IQueryable<Tooth> GetAll()
        {
            IQueryable<Tooth> query = DbContext.Instance.ApplicationDbContext.Set<Tooth>()
                .Include("PatientCard").Include("HumanTooth");
            return query;
        }
    }
}