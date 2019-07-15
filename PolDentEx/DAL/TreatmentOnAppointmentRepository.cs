using PolDentEx.Models;
using System.Linq;

namespace PolDentEx.DAL
{
    public interface ITreatmentOnAppointmentRepository : IBaseRepository<TreatmentOnAppointment>
    {
        TreatmentOnAppointment GetTreatmentOnAppointmentById(int id);
    }

    public class TreatmentOnAppointmentRepository : BaseRepository<TreatmentOnAppointment>, ITreatmentOnAppointmentRepository
    {

        public TreatmentOnAppointment GetTreatmentOnAppointmentById(int id)
        {
            return GetAll().FirstOrDefault(e => e.TreatmentOnAppointmentId == id);
        }

        public override IQueryable<TreatmentOnAppointment> GetAll()
        {
            IQueryable<TreatmentOnAppointment> query = DbContext.Instance.ApplicationDbContext.Set<TreatmentOnAppointment>()
                .Include("Treatment").Include("Appointment");
            return query;
        }
    }
}