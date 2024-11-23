using emp_system.Models;
using emp_system.repositiry;
using emp_system.validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace emp_system.Controllers
{
    [Authorize]
    [Ex_handel]

    public class specialtyController : Controller
    {
        private readonly Ispecialtyrepo ispecialtyrepo;
        private readonly appcontext appcontext;

        public specialtyController(Ispecialtyrepo ispecialtyrepo,appcontext appcontext)
        {
            this.ispecialtyrepo = ispecialtyrepo;
            this.appcontext = appcontext;
        }

        public IActionResult uniqe(string Name)
        {
            specialty specialty=appcontext.specialties.FirstOrDefault(x => x.Name == Name);
            if(specialty != null)
            
                return Json(false);
            
            return Json(true);

        }

        public IActionResult Index()
        {
            List<specialty> specialties = ispecialtyrepo.all();

            return View(specialties);
        }


        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult savecreate(specialty specialty)
        {
            if(ModelState.IsValid)
            {
                ispecialtyrepo.add(specialty);
                ispecialtyrepo.save();
                return RedirectToAction("Index");
            }
            return View("create");
        }



        [HttpGet]
        public IActionResult edite(int id)
        {
            specialty specialty=ispecialtyrepo.get(id);
            return View(specialty);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveedite(int id,specialty model)
        {
            specialty specialty = ispecialtyrepo.get(id);
            if (ModelState.IsValid == true)
            {
                specialty.Name = model.Name;
                ispecialtyrepo.save();
                return RedirectToAction("index");
            }
            return View("edite");
        }

        public IActionResult delete(int id)
        {
            specialty specialty =ispecialtyrepo.get(id);
            if (specialty != null)
            {
                ispecialtyrepo.delete(id);
                ispecialtyrepo.save();
                return RedirectToAction("index");
            }
            return Content("Not Found !");
        }
    }
}
