using GestionCabinetAvocat.Autorisations;
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
    public class CompteController : AbstractController
    {


        [LoggedAuthorization(AllowedTypes = new String[] { "Administrateur"})]
        public ActionResult Create()
        {
            ViewBag.EmailError = "";
            ViewBag.RepeatMotDePasseError = "";

            //Create the default view model
            var compte = new Compte();
            var viewModel = new CreateAccountViewModel()
            {
                Compte = compte,
                RepeatMotDePasse = ""
            };

            return View(viewModel);
        }

        [HttpPost, LoggedAuthorization(AllowedTypes = new String[] { "Administrateur"})]
        public ActionResult Create(CreateAccountViewModel viewModel)
        {
            ViewBag.EmailError = "";
            ViewBag.RepeatMotDePasseError = "";

            //If the post informations are valid, insert the user in the database
            if (ModelState.IsValid)
            {
                var errorOccured = false;
                if (viewModel.RepeatMotDePasse != viewModel.Compte.MotDePasse)
                {
                    ViewBag.RepeatMotDePasseError = "Les mots de passes ne correspondent pas.";
                    errorOccured = true;
                }

                if (CompteHepler.Current.GetItem(viewModel.Compte.Email) != null)
                {
                    ViewBag.EmailError = "L'email renseigné existe déjà dans la base de donnée";
                    errorOccured = true;
                }

                if (!errorOccured)
                {
                    CompteHepler.Current.AddCompte(viewModel.Compte);
                    return RedirectToAction("List");
                }
            }

            return View(viewModel);
        }

        [LoggedAuthorization]
        public ActionResult List()
        {
            ViewBag.Comptes = CompteHepler.Current.GetComptes();
            return View();
        }

        [LoggedAuthorization]
        public ActionResult Detail(int id)
        {
            //Check if the user exists
            var account = CompteHepler.Current.GetItem(id);
            if (account == null)
            {
                return new HttpNotFoundResult("Le compte n'existe pas.");
            }

            return View(account);
        }

        [LoggedAuthorization(AllowedTypes = new String[] { "Administrateur"})]
        public ActionResult Edit(int id)
        {
            //Check if the user exists
            var compte = CompteHepler.Current.GetItem(id);
            if (compte == null)
            {
                return new HttpNotFoundResult("Le compte n'existe pas.");
            }

            //Create default view model
            var viewModel = new CreateAccountViewModel()
            {
                Compte = compte,
                EditRepeatMotDePasse = compte.MotDePasse,
                EditMotDePasse = compte.MotDePasse
            };
            return View(viewModel);
        }

        [HttpPost, LoggedAuthorization(AllowedTypes = new String[] { "Administrateur" })]
        public ActionResult Edit(int id, CreateAccountViewModel viewModel)
        {
            //Check if the user exists
            Compte compte = CompteHepler.Current.GetItem(id);
            if (compte == null)
            {
                return new HttpNotFoundResult("Le compte n'existe pas.");
            }

            //Force the id to the current logged user
            viewModel.Compte.Id = id;

            //If the post informations are valid, update the user informations in the database
            if (!ModelState.IsValid)
            {
                var errorOccured = false;
                if (viewModel.EditRepeatMotDePasse != null && viewModel.EditRepeatMotDePasse == viewModel.EditMotDePasse)
                {
                    viewModel.Compte.MotDePasse = viewModel.EditMotDePasse;
                }
                else
                {
                    if (viewModel.EditRepeatMotDePasse== null && viewModel.EditMotDePasse == null)
                        viewModel.Compte.MotDePasse = compte.MotDePasse;
                }
                if (viewModel.EditRepeatMotDePasse!= viewModel.EditMotDePasse)
                {
                    ViewBag.RepeatPasswordError = "Les mots de passes ne correspondent pas.";
                    errorOccured = true;
                }

                if (CompteHepler.Current.GetItem(viewModel.Compte.Email) != null && CompteHepler.Current.GetItem(viewModel.Compte.Email).Id != viewModel.Compte.Id)
                {
                    ViewBag.EmailError = "L'email renseigné existe déjà dans la base de donnée";
                    errorOccured = true;
                }

                if (!errorOccured)
                {

                    CompteHepler.Current.Update(viewModel.Compte);
                    return RedirectToAction("List");
                }
            }

            return View(viewModel);
        }

        public ActionResult Login()
        {
            var viewModel = new LoginViewModel();
            return View(viewModel);
        }

        public ActionResult Deactivate()
        {
            return View();
        }
        [HttpPost]
        [LoggedAuthorization]
        public ActionResult Logout()
        {
            Session.Remove("User");
            return RedirectToAction("Login");
        }

    }
}