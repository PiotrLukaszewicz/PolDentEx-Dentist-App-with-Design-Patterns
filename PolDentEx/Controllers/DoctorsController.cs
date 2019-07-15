using PolDentEx.DAL;
using PolDentEx.Models;
using PolDentEx.RepositoryFacade;
using System.Net;
using System.Web.Mvc;

namespace PolDentEx.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly DoctorFacade _doctor;

        public DoctorsController()
        {
            _doctor = Repository.Instance.Data.GetDoctorFacade();
        }

        // GET: Doctors
        public ActionResult Index()
        {
            var model = _doctor.GetDoctors();
            return View(model);
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Doctor doctor = _doctor.GetDoctorById(id.Value);

            if (doctor == null) return HttpNotFound();

            return View(doctor);

        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,FirstName,LastName")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _doctor.Add(doctor);
                return RedirectToAction("Index");
            }

            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Doctor doctor = _doctor.GetDoctorById(id.Value);

            if (doctor == null) return HttpNotFound();

            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,FirstName,LastName")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {

                _doctor.Edit(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Doctor doctor = _doctor.GetDoctorById(id.Value);

            if (doctor == null) return HttpNotFound();

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _doctor.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
