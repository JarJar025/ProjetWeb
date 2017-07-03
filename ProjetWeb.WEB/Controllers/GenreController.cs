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
    public class GenreController : Controller
    {
        // On instancie un GenreBL pour utiliser les fonctions codées dedans
        private GenreBL BLgenre = new GenreBL();
        // GET: Genre
        public ActionResult Index()
        {
            List<GenreModel> genre = new List<GenreModel>();
            genre = BLgenre.getGenreNoPurge();
            return View(genre);
        }
        // GET: Genre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreModel genre = new GenreModel();
            genre = BLgenre.getGenrebyId((int)id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }
        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreModel genre = new GenreModel();
            genre = BLgenre.getGenrebyId((int)id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }
        // POST: Utilisateurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_genre,nom_genre,description,purge")] GenreModel genre)
        {
            if (ModelState.IsValid)
            {
                BLgenre.setEditGenre(genre.id_genre, genre.nom_genre, genre.description, genre.purge);
            }
            return RedirectToAction("Index");
        }
        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Genre/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nom_Genre,Description")] GenreModel genre)
        {
            if (ModelState.IsValid)
            {
                BLgenre.setCreateGenre(genre.nom_genre, genre.description);
            }
            return RedirectToAction("Index");
        }
        // GET: Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenreModel genre = new GenreModel();
            genre = BLgenre.getGenrebyId((int)id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }
        // POST: Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                BLgenre.setRemoveGenre(id);
            }
            return RedirectToAction("Index");
        }
    }
}
