using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.MODEL;
namespace ProjetWeb.WEB.Controllers
{
    public class AuthentificationController : Controller
    {
        private UtilisateurBL BLutilisateur = new UtilisateurBL();
        // GET: Authentification
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Mail,Password")] UtilisateurModel utilisateur)
        {

            UtilisateurModel utilisateurverif = new UtilisateurModel();
            utilisateurverif = BLutilisateur.getTestConnexion(utilisateur.Mail, utilisateur.Password);
            if (String.IsNullOrEmpty(utilisateurverif.Mail))
            {

            }
            else
            {
                if ((utilisateur.Mail == utilisateurverif.Mail) && (utilisateur.Password == utilisateurverif.Password))
                {
                    return RedirectToAction("/../Home/Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
