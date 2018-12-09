using GestionCabinetAvocat.Autorisations;
using GestionCabinetAvocat.DAO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionCabinetAvocat.Controllers
{
    public class DossierController : Controller
    {
        // GET: Dossier
        [LoggedAuthorization]
        public ActionResult List()
        {
            ViewBag.Dossiers = DossierHelper.Current.GetAll();
            return View();
        }
    }
}