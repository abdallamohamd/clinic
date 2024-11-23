using emp_system.Models;
using emp_system.repositiry;
using emp_system.validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace emp_system.Controllers
{
    [Authorize]
    [Ex_handel]

    public class patientController : Controller
    {
        private readonly Ipatientrepo ipatientrepo;
        public patientController(Ipatientrepo ipatientrepo)
        {
            this.ipatientrepo = ipatientrepo;
        }

        public IActionResult Index(string sstring)
        {
            List <patient> patient = ipatientrepo.all();
            if(!string.IsNullOrEmpty(sstring))
            {
                patient =patient.Where(x=>x.Name.Contains(sstring)).ToList();
            }
            return View(patient);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult savecreate(patient patient)
        {
            if (ModelState.IsValid == true)
            {
                ipatientrepo.add(patient);
                ipatientrepo.save();
                return RedirectToAction("Index");
            }
            return View("create");
        }

        [HttpGet]
        public IActionResult edite(int id)
        {
            patient patient = ipatientrepo.get(id);
            return View(patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveedite(int id ,patient model)
        {
            patient patient =ipatientrepo.get(id);
            if(ModelState.IsValid == true)
            {
                patient.Name=model.Name;
                patient.address=model.address;
                patient.phone=model.phone;
                patient.age=model.age;
                patient.ex_date=model.ex_date;
                patient.diagnosis=model.diagnosis;

                ipatientrepo.save();
                return RedirectToAction("index");
            }
            return View("edite",model);
        }

       public IActionResult delete(int id)
        {
            patient patient= ipatientrepo.get(id);
            if(patient != null)
            {
                ipatientrepo.delete(id);
                ipatientrepo.save();
                return RedirectToAction("index");
            }
            return Content(" Not Found !");
        }

    }
}
