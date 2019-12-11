﻿using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.SignOut.Controllers;
using Raybiztech.Kentico12.MVC.Widgets.SignOut.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.SignOut", typeof(SignOutWidgetController), "Sign out button", Description = "Displays a button that allows users to log out.", IconClass = "icon-user")]
namespace Raybiztech.Kentico12.MVC.Widgets.SignOut.Controllers
{
    public class SignOutWidgetController : WidgetController<SignOutWidgetProperties>
    {

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        public ActionResult Index()
        {
            return PartialView("Widgets/SignOutWidget/_SignOutWidget");
        }


        [HttpPost]
        public ActionResult SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
    }
}
