using PolDentEx.DAL;
using PolDentEx.Models;
using PolDentEx.RepositoryFacade;
using PolDentEx.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PolDentEx.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppointmentFacade _appointment;
        private readonly DoctorFacade _doctor;
        private readonly PatientFacade _patient;

        public AppointmentsController()
        {
            _appointment = Repository.Instance.Data.GetAppointmentFacade();
            _doctor = Repository.Instance.Data.GetDoctorFacade();
            _patient = Repository.Instance.Data.GetPatientFacade();
        }

        /// <summary>
        /// Akcja domyślna, panel główny aplikacji
        /// </summary>
        /// <returns></returns>
        // GET: Appointments
        public ActionResult Index()
        {
            var model = _appointment.GetAppointments();
            return View(model);
        }

        /// <summary>
        /// Przejście do widoku szczegółów wizyty
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Appointment appointment = _appointment.GetAppointment(id.Value);

            if (appointment == null) return HttpNotFound();

            return View(appointment);
        }

        /// <summary>
        /// Pobranie danych  o wizytach do DataTable
        /// </summary>
        /// <returns>Plik JSON do zasilenia DataTable</returns>
        public virtual ActionResult AppointmentsListData()
        {
            var errMessage = TempData["ErrorMessage"] as string;
            if (!String.IsNullOrEmpty(errMessage))
            {
                ViewBag.Errors = new List<string> { errMessage };
            }
            IEnumerable<AppointmentViewModel> items = _appointment.GetViewModel();

            return Json(new { aaData = items }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Tworzenie wizyty
        /// </summary>
        /// <returns></returns>
        // GET: Appointments/Create
        public ActionResult Create()
        {
            LoadDoctorAndPatientList(null);
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentId,Type,PatientId,DoctorId,Date")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointment.Add(appointment);
                return RedirectToAction("Index");
            }

            LoadDoctorAndPatientList(appointment);
            return View(appointment);
        }

        /// <summary>
        /// Edycja wizyty
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Appointment appointment = _appointment.GetAppointment(id.Value);
            if (appointment == null) return HttpNotFound();
            LoadDoctorAndPatientList(appointment);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentId,Type,PatientId,DoctorId,Date")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointment.Edit(appointment);
                return RedirectToAction("Index");
            }
            LoadDoctorAndPatientList(appointment);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Appointment appointment = _appointment.GetAppointment(id.Value);

            if (appointment == null) return HttpNotFound();

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //rf.DeleteAppointment(id);
            return RedirectToAction("Index");
        }

        private void LoadDoctorAndPatientList(Appointment appointment)
        {
            ViewBag.DoctorId = new SelectList(_doctor.GetList(), "id", "name", appointment?.DoctorId);
            ViewBag.PatientId = new SelectList(_patient.GetList(), "id", "name", appointment?.PatientId);
        }
    }
}
