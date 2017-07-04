using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.MODEL;
namespace ProjetWeb.WEB.Controllers
{
    public class RessourceUtilisateurController : Controller
    {
        // On instancie un RessourceBL pour utiliser les fonctions codées dedans
        private RessourceBL BLRessource = new RessourceBL();
        // GET: Ressource
        public ActionResult Index()
        {
            List<RessourceModel> ressource = new List<RessourceModel>();
            ressource = BLRessource.getRessourceNoPurge();
            return View(ressource);
        }
        //GET : Ressource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RessourceModel ressource = new RessourceModel();
            ressource = BLRessource.getRessourceById((int)id);
            if (ressource == null)
            {
                return HttpNotFound();
            }
            return View(ressource);
        }
    }
}
