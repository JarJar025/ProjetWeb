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
    public class UtilisateurController : Controller
    {
        // On instancie un utilisateurBL pour utiliser les fonctions codées dedans
        private UtilisateurBL BLuser = new UtilisateurBL();

        // GET: Utilisateurs
        public ActionResult Index()
        {
            List<UtilisateurModel> utilisateur = new List<UtilisateurModel>();
            utilisateur = BLuser.getUtilisateurNoPurge();
            return View(utilisateur);
        }
        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurModel utilisateur = new UtilisateurModel();
            utilisateur = BLuser.getUtilisateurbyId((int)id);

            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilisateurs/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nom_User,Prenom,Mail,Password,Last_login,Deconnexion,Nom_Profil")] UtilisateurModel utilisateur)
        {
            if (ModelState.IsValid)
            {
                BLuser.setCreateUtilisateur(utilisateur.Nom_User, utilisateur.Prenom, utilisateur.Mail, utilisateur.Password, utilisateur.Last_Login, utilisateur.Deconnexion, utilisateur.Nom_Profil);
            }
            return RedirectToRoute("../Views/LigneResa/Create");
        }

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurModel utilisateur = new UtilisateurModel();
            utilisateur = BLuser.getUtilisateurbyId((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nom_User,Prenom,Mail,Password,Last_Login,Deconnexion,ID_User,Nom_Profil,Purge")] UtilisateurModel utilisateur)
        {
            if (ModelState.IsValid)
            {
                BLuser.setEditUtilisateur(utilisateur.Nom_User, utilisateur.Prenom, utilisateur.Mail, utilisateur.Password, utilisateur.Last_Login, utilisateur.Deconnexion, utilisateur.ID_User, utilisateur.Nom_Profil, utilisateur.Purge);
            }
            return RedirectToAction("Index");
        }

        // GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurModel utilisateur = new UtilisateurModel();
            utilisateur = BLuser.getUtilisateurbyId((int)id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                BLuser.setRemoveUtilisateur(id);
            }
            return RedirectToAction("Index");

        }
    }
}
