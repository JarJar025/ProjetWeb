using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetWeb.DAL;
using ProjetWeb.MODEL;
using System.Data.Entity;

namespace ProjetWeb.BL
{
    public class GenreBL
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();
        // Récupérer tous les genre
        public List<GenreModel> getGenreAll()
        {
            var lesGenres = db.Genre.Select(u => new GenreModel()
            {
                id_genre = u.ID_Genre,
                nom_genre = u.Nom_Genre,
                description = u.Description,
                purge = (Boolean)u.Purge
            });
            List<GenreModel> GenreAll = new List<GenreModel>();
            GenreAll = lesGenres.ToList();
            return GenreAll;
        }
        public GenreModel getGenrebyId(int id)
        {
            var GenreById = db.Genre.Where(p => p.ID_Genre == id).Select(u => new GenreModel()
            {
                id_genre = u.ID_Genre,
                nom_genre = u.Nom_Genre,
                description = u.Description,
                purge = (Boolean)u.Purge
            }).FirstOrDefault();
            return GenreById;
        }
        public List<GenreModel> getGenreNoPurge()
        {
            var GenreNoPurge = db.Genre.Where(p => p.Purge == false).Select(u => new GenreModel()
            {
                id_genre = u.ID_Genre,
                nom_genre = u.Nom_Genre,
                description = u.Description,
                purge = (Boolean)u.Purge
            }).ToList();
            return GenreNoPurge;
        }
        // Editer le genre
        public GenreModel setEditGenre(int id_genre, string nom_genre, string description, Boolean purge)
        {
            // On lie les réponses du formulaire d'édition qui seront en paramètres à un Utilisateur de la BDD
            Genre genre = new Genre();
            genre.ID_Genre = id_genre;
            genre.Nom_Genre = nom_genre;
            genre.Description = description;
            genre.Purge = purge;
            // Envoi de l'utilisateur dans la BDD
            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();
            // Création de l'utilisateur précédemment créé suivant le modèle
            GenreModel genrem = new GenreModel();
            genrem.nom_genre = genrem.nom_genre;
            genrem.description = genrem.description;
            genrem.purge = (Boolean)genrem.purge;
            return genrem;
        }
        //création d'un genre
        public void setCreateGenre(string Nom_genre, string description)
        {
            // On lie les réponses du formulaire d'ajout qui seront en paramètres à un Utilisateur de la BDD
            Genre genre = new Genre();
            genre.Nom_Genre = Nom_genre;
            genre.Description = description;
            genre.Purge = false;
            // On ajoute le genre
            db.Genre.Add(genre);
            db.SaveChanges();
        }
        public void setRemoveGenre(int id_genre)
        {
            // On récupère le genre suivant son id
            Genre genre = db.Genre.FirstOrDefault(g => g.ID_Genre == id_genre);
            // On passe l'élément "purge" à true
            genre.Purge = true;
            // On applique ces changements
            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
