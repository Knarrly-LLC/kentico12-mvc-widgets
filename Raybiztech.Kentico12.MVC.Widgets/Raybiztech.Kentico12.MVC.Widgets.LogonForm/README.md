# Logon Form

Displays a Logon form that allows users to log into the website. Authentication requires a valid user name and password.

# Installation

Install the Raybiztech.Kentico12.MVC.Widgets.LogonForm NuGet Package to your Kentico 12 MVC Site.

Install   Microsoft.Owin.Host.SystemWeb.3.1.0.

If you have Startup.Auth.cs in your solution add Below Code. If you don't have Create Startup.Auth.cs and add below code.

<pre>
using CMS.Helpers;
using CMS.SiteProvider;
using Kentico.Membership;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(Startup))]
namespace &lt;YourSolution Namae&gt;
{
    /// &lt;summary&gt;
    /// Wraps application authentication configuration.
    /// &lt;/summary&gt;
    public class Startup
    {
        /// &lt;summary&gt;
        /// The application authentication cookie name
        /// &lt;/summary&gt;
        private const string AUTHENTICATION_COOKIE_NAME = "owin.authentication";


        /// &lt;summary&gt;
        /// Configures the application authentication.
        /// &lt;/summary&gt;
        public void Configuration(IAppBuilder app)
        {
            // Register Kentico Membership identity implementation
            app.CreatePerOwinContext(() => UserManager.Initialize(app, new UserManager(new UserStore(SiteContext.CurrentSiteName))));
            app.CreatePerOwinContext<SignInManager>(SignInManager.Create);
            // Configure the sign in cookie
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/"),
                ExpireTimeSpan = TimeSpan.FromDays(14),
                SlidingExpiration = true,
                CookieName = AUTHENTICATION_COOKIE_NAME
            });

            // Register the authentication cookie in the Kentico application and set its cookie level.
            // This will ensure that the authentication cookie will not be removed when a user revokes the tracking consent.
            CookieHelper.RegisterCookie(AUTHENTICATION_COOKIE_NAME, CookieLevel.Essential);
        }
    }
}
</pre>
# Widget

This is a widget which allows you to add a LognForm to your screen with certain fields.
- Redirect to URL*
- Button Text*
- Logon failure text*

*Required fields


# Author

This widget was created by Srikanth Nasa @ Ray Business Technologies Pvt Ltd.

# License

This widget is provided under MIT license.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

This widget has been tested on Kentico 12.0.29 MVC and can be used on Kentico 12.0.29 MVC instance and higher.

# Uninstall instructions

After uninstalling this package from the solution, if you are still seeing the widget on the page tab in Kentico CMS then please follow the below steps.

Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.LogonForm.dll) and delete
-> Rebuild the solution
