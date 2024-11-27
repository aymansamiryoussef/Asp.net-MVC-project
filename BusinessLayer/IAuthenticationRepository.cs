using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IAuthenticationRepository
    {
        Task<IdentityResult> Registration(ApplicationUser User,string password);

        Task<SignInResult> SignInAsync(string name , string passord, bool remmberme );

        Task Logout();

    }
}
