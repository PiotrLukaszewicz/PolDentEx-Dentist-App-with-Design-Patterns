using PolDentEx.DAL;
using PolDentEx.Models;
using PolDentEx.RepositoryFacade;
using System.Net;
using System.Web.Mvc;

namespace PolDentEx.Controllers
{
    public class TreatmentOnAppointmentsController : Controller
    {
        private readonly TreatmentOnAppointmentFacade _treatmentOnAppointment;
        private readonly AppointmentFacade _appointment;
        private readonly TreatmentFacade _treatment;

        public TreatmentOnAppointmentsController()
        {
            _treatmentOnAppointment = Repository.Instance.Data.GeTreatmentOnAppointmentFacade();
            _appointment = Repository.Instance.Data.GetAppointmentFacade();
            _treatment = Repository.Instance.Data.GeTreatmentFacade();
        }

        // GET: TreatmentOnAppointments
        public ActionResult Index()
        {
            var model = _treatmentOnAppointment.GetTreatmentOnAppointments();
             return View(model);
        }

        // GET: TreatmentOnAppointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TreatmentOnAppointment treatmentOnAppointment = _treatmentOnAppointment.TreatmentOnAppointment(id.Value);

            if (treatmentOnAppointment == null) return HttpNotFound();

            return View(treatmentOnAppointment);
        }

        // GET: TreatmentOnAppointments/Create
        public ActionResult Create()
        {
            LoadAppointmentAndTreatmentList(null);
            return View();
        }

        // POST: TreatmentOnAppointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentOnAppointmentId,Description,TreatmentId,AppointmentId")] TreatmentOnAppointment treatmentOnAppointment)
        {
            if (ModelState.IsValid)
            {
                _treatmentOnAppointment.Add(treatmentOnAppointment);
                return RedirectToAction("Index");
            }

            LoadAppointmentAndTreatmentList(treatmentOnAppointment);
            return View(treatmentOnAppointment);
        }

        // GET: TreatmentOnAppointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TreatmentOnAppointment treatmentOnAppointment = _treatmentOnAppointment.TreatmentOnAppointment(id.Value);

            if (treatmentOnAppointment == null) return HttpNotFound();

            LoadAppointmentAndTreatmentList(treatmentOnAppointment);
            return View(treatmentOnAppointment);
        }

        // POST: TreatmentOnAppointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentOnAppointmentId,Description,TreatmentId,AppointmentId")] TreatmentOnAppointment treatmentOnAppointment)
        {
            if (ModelState.IsValid)
            {
                _treatmentOnAppointment.Edit(treatmentOnAppointment);
                return RedirectToAction("Index");
            }
            LoadAppointmentAndTreatmentList(treatmentOnAppointment);
            return View(treatmentOnAppointment);
        }

        // GET: TreatmentOnAppointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TreatmentOnAppointment treatmentOnAppointment = _treatmentOnAppointment.TreatmentOnAppointment(id.Value);

            if (treatmentOnAppointment == null) return HttpNotFound();
            return View(treatmentOnAppointment);
        }

        // POST: TreatmentOnAppointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _treatmentOnAppointment.Remove(id);
            return RedirectToAction("Index");
        }

        private void LoadAppointmentAndTreatmentList(TreatmentOnAppointment treatmentOnAppointment)
        {
            ViewBag.AppointmentId = new SelectList(_appointment.GetAppointments(), "AppointmentId", "AppointmentId", treatmentOnAppointment?.AppointmentId);
            ViewBag.TreatmentId = new SelectList(_treatment.GetTreatments(), "TreatmentId", "Name", treatmentOnAppointment?.TreatmentId);
        }
    }
}
