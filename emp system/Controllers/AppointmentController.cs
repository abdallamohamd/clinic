using emp_system.Models;
using emp_system.repositiry;
using emp_system.validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace emp_system.Controllers
{
    [Ex_handel]

    public class AppointmentController : Controller
    {
        private readonly Iappointmentrepo iappointmentrepo;

        public Ispecialtyrepo Ispecialtyrepo { get; }

        public AppointmentController(Iappointmentrepo iappointmentrepo, Ispecialtyrepo ispecialtyrepo)
        {
            this.iappointmentrepo = iappointmentrepo;
            Ispecialtyrepo = ispecialtyrepo;
        }
        
        public IActionResult Index( string sstring)
        {

          List<appointment> appointment =  iappointmentrepo.all();

            if (!string.IsNullOrEmpty(sstring))
            {
                appointment = appointment.Where(x=> x.Patientname.Contains(sstring)).ToList();
            }

            return View(appointment);
        }
        [HttpGet]
        [Authorize]
        public IActionResult create()
        {
            ViewData["splist"] = Ispecialtyrepo.all();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult savecreate(appointment appointment)
        {
            if (ModelState.IsValid == true)
            {
                iappointmentrepo.add(appointment);
                iappointmentrepo.save();
                return RedirectToAction("Index", "Home");
            }
            ViewData["splist"] = Ispecialtyrepo.all();

            return View("create",appointment);
        }
        [HttpGet]
        [Authorize]
        public IActionResult edite(int id)
        {
            appointment appointment = iappointmentrepo.get(id);
            ViewData["splist"] = Ispecialtyrepo.all();
            return View(appointment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult saveedite(int id ,appointment model)
        { 
            appointment appointment = iappointmentrepo.get(id);
            if (ModelState.IsValid)
            {
                appointment.Patientname=model.Patientname;
                appointment.address=model.address;
                appointment.phone=model.phone;
                appointment.age=model.age;
                appointment.appointmentdate=model.appointmentdate;
                appointment.specialtyid=model.specialtyid;

                iappointmentrepo.save();

                return RedirectToAction("index");
            }
            ViewData["splist"] = Ispecialtyrepo.all();
            return View("edite", model);
        }

        [Authorize]
        public IActionResult delete(int id)
        {
            appointment appointment=iappointmentrepo.get(id);
            if(appointment!=null)
            {
                iappointmentrepo.delete(id);
                iappointmentrepo.save();
                return RedirectToAction("index");
            }
            return Content("Not Found!");
        }
    }
}
