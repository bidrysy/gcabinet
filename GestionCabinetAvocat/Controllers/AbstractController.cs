using GestionCabinetAvocat.DAO;
using GestionCabinetAvocat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionCabinetAvocat.Controllers
{
    public class AbstractController : Controller
    {
        // GET: Abstract

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Add the current logged user in the ViewBag so it can be accessed in all actions
            var user = Session["User"] as Compte;
            ViewBag.LoggedUser = user;
            base.OnActionExecuting(filterContext);

            //Build the main menu items list
            var menuItems = new List<ControllerActionLink>();
            if (user != null)
            {
                switch (user.TypeCompte)
                {
                    case "Administrateur":
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Comptes utilisateurs",
                            Controller = "compte",
                            Action = "List"
                        });
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Liste Rendez-vous",
                            Controller = "RendezVous",
                            Action = "List"
                        });
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Liste Adherants",
                            Controller = "Adherant",
                            Action = "List"
                        });
                        break;
                    case "Avocat":
                       
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Liste Rendez-vous",
                            Controller = "RendezVous",
                            Action = "List"
                        });
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Liste Adherant",
                            Controller = "Adherant",
                            Action = "List"
                        });
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Liste Dossiers",
                            Controller = "Dossier",
                            Action = "List"
                        });
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Liste Affaires",
                            Controller = "Affaire",
                            Action = "List"
                        });
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Liste Pocedures Juridiqueq",
                            Controller = "ProcedureJuridique",
                            Action = "List"
                        });
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Liste Pieces",
                            Controller = "Piece",
                            Action = "List"
                        });
                        break;
                    case "Stagiaire":
                        menuItems.Add(new ControllerActionLink()
                        {
                            Text = "Liste Rendez-vous",
                            Controller = "RendezVous",
                            Action = "List"
                        });
                        break;
                        
                }
                ViewBag.MenuItems = menuItems;
            }
        }
    }
}