using BusinessLayer.Interface;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Reprosetory
{
    public class AuthenticationReprosatory : IAuthenticationRepository
    {
       private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthenticationReprosatory(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signinmange) { 
        
            userManager = _userManager;
            signInManager = _signinmange;
        
        }
        public  Task Logout()
        {
            return signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Registration(ApplicationUser appuser,string password)
        {
            IdentityResult result = await userManager.CreateAsync(appuser, password);
            if(result.Succeeded)
            {
             
               await signInManager.SignInAsync(appuser,false);
                
            }
            else
            {
             
                foreach (var error in result.Errors)
                {
               
                    Console.WriteLine($"Error Code: {error.Code}, Description: {error.Description}");
                }
            }
            return result;
        }

        public async Task<SignInResult> SignInAsync( string name, string password, bool rememberMe = false)
        {
            
            ApplicationUser user = await userManager.FindByNameAsync(name);

            if (user != null)
            {
                
                bool passwordValid = await userManager.CheckPasswordAsync(user, password);
                    
                if (passwordValid)
                {
                    await signInManager.SignInAsync(user, rememberMe);
                    return SignInResult.Success; 
                }
                else
                {
                    return SignInResult.Failed; 
                }
            }

            return SignInResult.Failed;
        }

    }
}
