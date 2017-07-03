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
    public class RessourceController : Controller
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

        // GET: Ressource/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Ressource/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nom_Ressource,Disponibilite,Description,Date_Achat,QRCode,Nom_Genre")] RessourceModel ressource)
        {
            if (ModelState.IsValid)
            {
                BLRessource.setCreateRessource(ressource.Nom_Ressource, ressource.Disponibilite, ressource.Description, ressource.Date_Achat, ressource.QRCode, ressource.Nom_Genre);
            }
            return RedirectToAction("Index");
        }
        // GET: Ressource/Edit/5
        public ActionResult Edit(int? id)
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
        //// POST : Ressource/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nom_Ressource,Disponibilite,Description,Date_Achat,QRCode,Purge,Nom_Genre,ID_Ressource")] RessourceModel ressource)
        {
            if (ModelState.IsValid)
            {
                BLRessource.setEditRessource(ressource.Nom_Ressource, ressource.Disponibilite, ressource.Description, ressource.Date_Achat, ressource.QRCode, ressource.Purge, ressource.Nom_Genre, ressource.ID_Ressource);
            }
            return RedirectToAction("Index");
        }

        // GET: Ressource/Delete/5
        public ActionResult Delete(int? id)
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
        // POST: Ressource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                BLRessource.setRemoveRessource(id);
            }
            return RedirectToAction("Index");
        }
    }
}
