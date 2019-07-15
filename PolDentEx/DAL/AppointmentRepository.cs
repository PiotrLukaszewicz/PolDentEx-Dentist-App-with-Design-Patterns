using PolDentEx.Models;
using System.Linq;
using PolDentEx.RepositoryFacade;

namespace PolDentEx.DAL
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Appointment GetAppointmentById(int appointmentId);
    }

    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public Appointment GetAppointmentById(int idAppointment)
        {
            return GetAll().FirstOrDefault(e => e.AppointmentId == idAppointment);
        }

        public override IQueryable<Appointment> GetAll()
        {
            IQueryable<Appointment> query = DbContext.Instance.ApplicationDbContext.Set<Appointment>()
                .Include("Patient").Include("Doctor");
            return query;
        }
    }
}