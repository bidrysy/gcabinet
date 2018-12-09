using GestionCabinetAvocat.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace GestionCabinetAvocat.Autorisations
{
    public class LoggedAuthorizationAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public String[] AllowedTypes { get; set; }
       
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.Session["User"] as Compte;
            if (user == null)
            {
                //If the user is not logged, redirect him to the connection page
                filterContext.Result = new RedirectResult("/Compte/Login");
            }
            else if (AllowedTypes != null && AllowedTypes.Length > 0 && !AllowedTypes.Contains(user.TypeCompte))
            {
                //If the user is logged but dont have the good access rights, send him a 401 error
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)

        {
        }
    }
}