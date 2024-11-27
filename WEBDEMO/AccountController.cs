using BusinessLayer.Interface;
using BusinessLayer.Reprosetory;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using WEBDEMO.ViewModel;


namespace ThreeLayerArticture.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationRepository authRepo;
        
        public AccountController(IAuthenticationRepository authenticationRepository) {


            authRepo = authenticationRepository;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {


            return View("Form");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Registeration(UserViewModel userm)
        {
            if( ModelState.IsValid )
            {
                ApplicationUser applicationUser = new ApplicationUser();
                
                applicationUser.UserName = userm.UserName;
                applicationUser.Email = userm.Email;
                applicationUser.PasswordHash = userm.password;

                IdentityResult result= await authRepo.Registration(applicationUser, userm.password);

                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index","Proudct");
                }
                else
                {
                    foreach(var erorr in result.Errors)
                    {

                        ModelState.AddModelError("", erorr.Description);
                    }

                }


            }
            return View("Form", userm);


        }

        [HttpGet]
        public IActionResult SignIN()
        {

            return View("Login");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSignIN(LoginUserViewModel loginUser)
        {
            if(ModelState.IsValid)
            {
                var result = await authRepo.SignInAsync(loginUser.UserName, loginUser.Password,loginUser.remmberme);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Proudct");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt");

                }
            }
            return View ("Login", loginUser);

        }

        public async Task<IActionResult> SignOut()
        {

           await authRepo.Logout();
            HttpContext.Session.Clear();
            Response.Cookies.Delete(".AspNetCore.Identity.Application"); 
            return RedirectToAction("SignIN","Account");
        }
       


    }
}
