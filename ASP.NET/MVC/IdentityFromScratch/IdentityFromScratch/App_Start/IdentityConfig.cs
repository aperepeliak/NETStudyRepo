﻿using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityFromScratch
{
    public class ApplicationUserManager : UserManager<CustomUser>
    {
        public ApplicationUserManager(UserStore<CustomUser> userStore)
            : base(userStore)
        {
        }

        public static ApplicationUserManager Create
            (IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var userStore = new UserStore<CustomUser>(context.Get<ApplicationDbContext>());

            return new ApplicationUserManager(userStore);
        }
    }

    public class ApplicationSignInManager: SignInManager<CustomUser, string>
    {
        public ApplicationSignInManager
            (ApplicationUserManager userManager, 
             IAuthenticationManager authenticationManager)
            : base (userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.Get<ApplicationUserManager>(),
                context.Authentication);
        } 
    }

    public class IdentityConfig
    {
        // IUser
        // IUserStore
        // UserManager

        // SignInManager

        // IdentityUser
        // UserStore - have to give db context

        // IdentityDbContext<TypeOfUser>
    }
}