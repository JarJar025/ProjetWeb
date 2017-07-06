using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetWeb.BL;
using ProjetWeb.MODEL;
using System.Web.Security;
using Newtonsoft.Json;

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
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Mail,Password")] UtilisateurModel utilisateur)
        {

            UtilisateurModel utilisateurverif = new UtilisateurModel();
            utilisateurverif = BLutilisateur.getTestConnexion(utilisateur.Mail, utilisateur.Password);
            if ((utilisateur.Mail != null) && (utilisateur.Password != null))
            {
                if ((utilisateurverif != null) && (utilisateurverif != null))
                {
                    if ((utilisateur.Mail == utilisateurverif.Mail) && (utilisateur.Password == utilisateurverif.Password))
                    {
                        if (utilisateurverif.Purge == false)
                        {

                            if (utilisateurverif.Nom_Profil == "Lecteur")
                            {
                                Session["IDUser"] = utilisateurverif.ID_User;
                                return RedirectToAction("/../HomeLecteur/Index");
                            }
                            else if (utilisateurverif.Nom_Profil == "Utilisateur")
                            {
                                Session["IDUser"] = utilisateurverif.ID_User;
                                return RedirectToAction("/../HomeUtilisateur/Index");
                            }
                            else if (utilisateurverif.Nom_Profil == "Administrateur")
                            {
                                return RedirectToAction("/../HomeAdministrateur/Index");
                            }
                        }
                    }
                    else
                    {

                        ViewBag.Connexion = false;
                        ViewBag.Message = "Echec d'authentification. Votre couple Mail/Mot de passe est incorrect";
                        return View();
                    }
                }
                else
                {

                    ViewBag.Connexion = false;
                    ViewBag.Message = "Echec d'authentification. Votre couple Mail/Mot de passe est incorrect";
                    return View();
                }
            }
            else
            {
                if(String.IsNullOrEmpty(utilisateur.Mail))
                {
                    ViewBag.Connexion = false;
                    ViewBag.Message = "Le champ Mail est vide. Veuillez le remplir";
                    return View();
                }
                if(String.IsNullOrEmpty(utilisateur.Password))
                {
                    ViewBag.Connexion = false;
                    ViewBag.Message = "Le champ Mot de passe est vide. Veuillez le remplir";
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Deconnexion()
        {
            return RedirectToAction("/../Authentification/Index");
        }
    }
}
