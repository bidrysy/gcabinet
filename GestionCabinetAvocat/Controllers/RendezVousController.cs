using GestionCabinetAvocat.Autorisations;
using GestionCabinetAvocat.DAO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionCabinetAvocat.Controllers
{
    public class RendezVousController : Controller
    {
        // GET: RendezVous

        [LoggedAuthorization]
        public ActionResult List()
        {
            ViewBag.RendezVous = RendezVousHelper.Current.GetAll();
            return View();
        }
    }
}