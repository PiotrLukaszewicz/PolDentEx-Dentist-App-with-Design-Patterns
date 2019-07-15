using PolDentEx.Models;
using System.Linq;

namespace PolDentEx.DAL
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Doctor GetDoctorById(int doctorId);
    }

    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {

        public Doctor GetDoctorById(int doctorId)
        {
            return GetAll().FirstOrDefault(e => e.DoctorId == doctorId);
        }

        public override IQueryable<Doctor> GetAll()
        {
            IQueryable<Doctor> query = DbContext.Instance.ApplicationDbContext.Set<Doctor>();
            return query;
        }
    }
}