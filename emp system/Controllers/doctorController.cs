using emp_system.Models;
using emp_system.repositiry;
using emp_system.validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace emp_system.Controllers
{
    [Authorize]
    [Ex_handel]

    public class doctorController : Controller
    {
        private readonly Idoctorrepo idoctorrepo;
        private readonly Ispecialtyrepo ispecialtyrepo;

        public doctorController(Idoctorrepo idoctorrepo,Ispecialtyrepo ispecialtyrepo)
        {
            this.idoctorrepo = idoctorrepo;
            this.ispecialtyrepo = ispecialtyrepo;
        }

        public IActionResult Index()
        {
            List<doctor> doctors = idoctorrepo.all();
            return View(doctors);
        }

        [HttpGet]
        public IActionResult create()
        {
            ViewData["splist"]= ispecialtyrepo.all();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult savecreate(doctor doctor)
        {
            if (ModelState.IsValid == true)
            {
                idoctorrepo.add(doctor);
                idoctorrepo.save();
                return RedirectToAction("index");
            }
            ViewData["splist"] = ispecialtyrepo.all();
              return View("create", doctor);
        }

        [HttpGet]
        public IActionResult edite(int id)
        {

            doctor doctor = idoctorrepo.get(id);
            ViewData["splist"] = ispecialtyrepo.all();

            return View(doctor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveedite(int id, doctor model)
        {
           doctor doctor = idoctorrepo.get(id);
            if (ModelState.IsValid == true)
            {
                doctor.Name = model.Name;
                doctor.sepcialtyid = model.sepcialtyid;

                idoctorrepo.save();
                return RedirectToAction("index");
            }
            ViewData["splist"] = ispecialtyrepo.all();
            return View("edite", model);
        }

        public IActionResult delete(int id)
        {
            doctor doctor = idoctorrepo.get(id);
            if (doctor!= null)
            {
                idoctorrepo.delete(id);
                idoctorrepo.save();
                return RedirectToAction("index");
            }
            return Content(" Not Found !");
        }

    }
}

