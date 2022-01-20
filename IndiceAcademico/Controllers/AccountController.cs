using System.Security.Claims;
using System.Threading.Tasks;
using IndiceAcademico.Models.ViewModels;
using IndiceAcademico.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IndiceAcademico.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password,RememberMe")] LoginViewModel model)
        {

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                
                var user = await _userManager.FindByEmailAsync(model.Email);
                //await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Student"));
                if (await _userManager.IsInRoleAsync(user, "Professor"))
                {
                    return RedirectToAction("Index", "Professors");
                }
                else
                {
                    return RedirectToAction("Index", "Students");
                }
            }
            ModelState.AddModelError("BadUsorPs", "Usuario y/o Contraseña Incorrecto");
            return View(model);

        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}