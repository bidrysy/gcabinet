using GestionCabinetAvocat.Autorisations;
using GestionCabinetAvocat.DAO.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionCabinetAvocat.Controllers
{
    public class AdherantController : Controller
    {
        // GET: Adherant

        [LoggedAuthorization]
        
        public ActionResult List()
        {
            ViewBag.Adherants = AdherentHelper.Current.GetAll();
            return View();
        }
        
    }
}