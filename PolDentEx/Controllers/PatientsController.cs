using PolDentEx.DAL;
using PolDentEx.DocumentationGenerator;
using PolDentEx.Models;
using PolDentEx.RepositoryFacade;
using PolDentEx.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PolDentEx.Controllers
{
    public class PatientsController : Controller
    {

        private readonly PatientFacade _patient;
        private readonly DoctorFacade _doctor;

        public PatientsController()
        {
            _patient = Repository.Instance.Data.GetPatientFacade();
            _doctor = Repository.Instance.Data.GetDoctorFacade();
        }


        /// <summary>
        /// Akcja domyślna
        /// </summary>
        /// <returns></returns>
        // GET: Patients
        public ActionResult Index()
        {
            var model = new PatientViewModel();
            return View(model);
        }

        /// <summary>
        /// Pobieranie pliku XLSX z dokumentacją medyczną pacjenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GenerateXLSXDocumentation(int? id)
        {
            DocumentationGenerator.DocumentationGenerator generator = new XLSXDocumentationGenerator();
            ReportViewModel model = generator.GenerateDocumentation(_patient.GetPatientById(id.Value));
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", model.FileName);
            Response.BinaryWrite(model.FileBytes);
            return new EmptyResult();
        }

        /// <summary>
        /// Pobieranie pliku PDF z dokumentacją medyczną pacjenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GeneratePDFDocumentation(int? id)
        {
            DocumentationGenerator.DocumentationGenerator generator = new PDFDocumentationGenerator();
            ReportViewModel model = generator.GenerateDocumentation(_patient.GetPatientById(id.Value));
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", model.FileName);
            Response.BinaryWrite(model.FileBytes);
            return new EmptyResult();
        }

        /// <summary>
        /// Pobranie danych  o pacjentach do DataTable
        /// </summary>
        /// <returns>Plik JSON do zasilenia DataTable</returns>
        public virtual ActionResult PatientsListData()
        {
            var errMessage = TempData["ErrorMessage"] as string;
            if (!String.IsNullOrEmpty(errMessage))
            {
                ViewBag.Errors = new List<string> { errMessage };
            }

            IEnumerable<PatientViewModel> items = _patient.GetViewModel();

            return Json(new
            {
                aaData = items
            }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Generuje widok szczegółów pacjenta wraz z jego kartą pacjenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Patient patient = _patient.GetPatientById(id.Value);

            if (patient == null) return HttpNotFound();

            JawAdapter.JawAdapter jawAdapter = new JawAdapter.JawAdapter();
            ViewBag.Jaw = jawAdapter.GenerateJawData(patient.PatientCardId);
            return View(patient);
        }


        /// <summary>
        /// Generuje string Json do zasilenia szczęki
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Patients/Jaw/5
        public ActionResult Jaw(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Patient patient = _patient.GetPatientById(id.Value);

            if (patient == null) return HttpNotFound();

            JawAdapter.JawAdapter jawAdapter = new JawAdapter.JawAdapter();
            ViewBag.Jaw = jawAdapter.GenerateJawData(patient.PatientCardId);
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            LoadDoctorsList(null);
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,DoctorId,PatientDetails,PatientCard,PESEL,Date, isChild")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patient.Add(patient);
                return RedirectToAction("Index");
            }

            LoadDoctorsList(patient);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Patient patient = _patient.GetPatientById(id.Value);

            if (patient == null) return HttpNotFound();

            LoadDoctorsList(patient);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,DoctorId,PatientDetails,PatientCard,PESEL,Date")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patient.Edit(patient);
                return RedirectToAction("Index");
            }

            LoadDoctorsList(patient);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Patient patient = _patient.GetPatientById(id.Value);

            if (patient == null) return HttpNotFound();
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _patient.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult FastOverview(int? id)
        {
            var model = new FastViewModel();
            model.Step = 0;
            model.Caretraker = new Memento.IteratorCaretaker();
            model.Originator = new Memento.IteratorOriginator();

            model.Iterator = _patient.GetTeethIterator(id.Value);

            model.Originator.SetState((TeethIterator)model.Iterator.Clone());
            model.Caretraker.AddMemento(model.Originator.Save());

            model.Tooth = model.Iterator.NextTooth();

            TempData["FastViewModel"] = model;

            return View(model.Tooth);
        }

        [HttpPost]
        public ActionResult FastOverviewNext(Tooth tooth)
        {
            var model = (FastViewModel)TempData["FastViewModel"];
            model.Step++;

            model.Originator.SetState((TeethIterator)model.Iterator.Clone());
            model.Caretraker.AddMemento(model.Originator.Save());

            model.Tooth = model.Iterator.NextTooth();

            TempData["FastViewModel"] = model;
            _patient.Edit(tooth);
            return View("FastOverview", model.Tooth);
        }

        public ActionResult FastOverviewBack()
        {
            var model = (FastViewModel)TempData["FastViewModel"];
            model.Originator.Restore(model.Caretraker.GetMemento(model.Step-1));

            model.Iterator = model.Caretraker.GetMemento(model.Step-1).Getstate();
            model.Tooth = model.Iterator.NextTooth();

            TempData["FastViewModel"] = model;
            _patient.Edit(model.Tooth);

            return View("FastOverview", model.Tooth);
        }

        private void LoadDoctorsList(Patient patient)
        {
            ViewBag.DoctorId = new SelectList(_doctor.GetList(), "id", "name", patient?.DoctorId);
        }
    }
}
