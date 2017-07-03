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
    public class ProfilController : Controller
    {
        // On instancie un ProfilBL pour utiliser les fonctions codées dedans
        private ProfilBL BLprofil = new ProfilBL();
        // GET: Profils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfilModel profil = new ProfilModel();
            profil = BLprofil.getProfilbyId((int)id);

            if (profil == null)
            {
                return HttpNotFound();
            }
            return View(profil);
        }
        // GET: Profils
        public ActionResult Index()
        {
            List<ProfilModel> profil = new List<ProfilModel>();
            profil = BLprofil.getProfilAll();
            return View(profil);
        }
    }
}
