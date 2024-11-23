using emp_system.Models;
using emp_system.validation;
using emp_system.view_model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace emp_system.Controllers
{
    [Ex_handel]
    public class accountController : Controller
    {
        private readonly UserManager<appuser> userManager;
        private readonly SignInManager<appuser> signInManager;

        public accountController(UserManager<appuser> userManager,SignInManager<appuser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult regester()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> save(regvm regvm)
        { 
            appuser appuser = new appuser();
            if (ModelState.IsValid)
            {
                appuser.UserName = regvm.name;
                appuser.PasswordHash = regvm.password;
                appuser.address = regvm.address;
                appuser.PhoneNumber = regvm.phone;
                IdentityResult result = await userManager.CreateAsync(appuser, regvm.password);
                if (result.Succeeded)
                {
                   
                    await signInManager.SignInAsync(appuser, false);
                    return RedirectToAction("Index", "patient");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("regester", regvm);
        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> savelogin(logvm logvm)
        {
            if (ModelState.IsValid)
            {
                appuser appuser = await userManager.FindByNameAsync(logvm.UserName);
                if (appuser != null)
                {
                    bool found = await userManager.CheckPasswordAsync(appuser, logvm.Password);
                    if (found == true)
                    {
                        await signInManager.SignInAsync(appuser, logvm.Remmber);
                        return RedirectToAction("index", "patient");
                    }
                }
                ModelState.AddModelError("", "name or password not found");
               }
            return View("login", logvm); 
           }

        public async Task <IActionResult> logout()
        {
           await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
