using GestionCabinetAvocat.DAO;
using GestionCabinetAvocat.DAO.Helpers;
using GestionCabinetAvocat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionCabinetAvocat.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel)
        {
            ViewBag.EmailError = "";
            ViewBag.MotDePasseError = "";

            if (ModelState.IsValid)
            {
                //Check if the user informations are correct
                Compte user = CompteHepler.Current.GetItem(viewModel.Email);
                if (user == null)
                {
                    ViewBag.EmailError = "Le compte n'existe pas";
                    return View();
                }
                else if (user.MotDePasse != viewModel.MotDePasse)
                {
                    ViewBag.MotDePasseError = "Mot de passe incorrect";
                    return View();
                }
                else
                {
                    //Log the user
                    Session.Add("User", user);
                    return RedirectToAction("List", "Compte");
                }
            }

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}