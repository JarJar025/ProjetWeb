using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using ProjetWeb.BL;
using ProjetWeb.MODEL;
namespace ProjetWeb.WEB.Controllers
{
    public class HomeLecteurController : Controller
    {
        private UtilisateurBL BLuser = new UtilisateurBL();
        public ActionResult Index()
        {
            int ID_User = int.Parse(Session["IDUser"].ToString());
            UtilisateurModel utilisateur = new UtilisateurModel();
            List<UtilisateurModel> listutilisateur = new List<UtilisateurModel>();
            utilisateur = BLuser.GetNomPrenomUtilisateur(ID_User);
            string nomcomplet = utilisateur.Prenom + " " + utilisateur.Nom_User;
            utilisateur.NomComplet = nomcomplet;
            utilisateur.ID_User = ID_User;
            listutilisateur.Add(utilisateur);
            return View(listutilisateur);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UtilisateurModel utilisateur = new UtilisateurModel();
            utilisateur = BLuser.getUtilisateurbyId((int)id);
            Session["IDUser"] = id.ToString();
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
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
            Session["IDUser"] = id.ToString();
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

                BLuser.setEditUtilisateur(utilisateur);
            }
            return RedirectToAction("Index");
        }
    }
}
