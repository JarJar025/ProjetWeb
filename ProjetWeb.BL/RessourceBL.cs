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
    public class RessourceBL
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();
        //Récuperer toutes les Ressources
        public List<RessourceModel> getRessourceAll()
        {
            var lesRessources = db.Ressource.Select(r => new RessourceModel()
            {
                Nom_Ressource = r.Nom_Ressource,
                Disponibilite = (int)r.Disponibilite,
                Description = r.Description,
                Date_Achat = (DateTime)r.Date_Achat,
                QRCode = r.QRCode,
                Purge = (Boolean)r.Purge,
                Nom_Genre = db.Genre.Where(g => g.ID_Genre == r.ID_Genre).FirstOrDefault().Nom_Genre,
                ID_Ressource = (int)r.ID_Ressource,
                ID_Genre = (int)r.ID_Genre
            });
            List<RessourceModel> RessourceAll = new List<RessourceModel>();
            RessourceAll = lesRessources.ToList();
            return RessourceAll;
        }
        //Récuperer une Ressource suivant son id
        public RessourceModel getRessourceById(int id)
        {
            var RessourcesById = db.Ressource.Where(g => g.ID_Ressource == id).Select(r => new RessourceModel()
            {
                Nom_Ressource = r.Nom_Ressource,
                Disponibilite = (int)r.Disponibilite,
                Description = r.Description,
                Date_Achat = (DateTime)r.Date_Achat,
                QRCode = r.QRCode,
                Purge = (Boolean)r.Purge,
                Nom_Genre = db.Genre.Where(g => g.ID_Genre == r.ID_Genre).FirstOrDefault().Nom_Genre,
                ID_Ressource = (int)r.ID_Ressource,
                ID_Genre = (int)r.ID_Genre
            }).FirstOrDefault();
            return RessourcesById;
        }
        public List<RessourceModel> getRessourceNoPurge()
        {
            var RessourceNoPurge = db.Ressource.Where(p => p.Purge == false).Select(r => new RessourceModel()
            {
                Nom_Ressource = r.Nom_Ressource,
                Disponibilite = (int)r.Disponibilite,
                Description = r.Description,
                Date_Achat = (DateTime)r.Date_Achat,
                QRCode = r.QRCode,
                Purge = (Boolean)r.Purge,
                Nom_Genre = db.Genre.Where(g => g.ID_Genre == r.ID_Genre).FirstOrDefault().Nom_Genre,
                ID_Ressource = (int)r.ID_Ressource,
                ID_Genre = (int)r.ID_Genre
            }).ToList();
            return RessourceNoPurge;
        }
        //Editer la ressource
        public RessourceModel setEditRessource(string nom_ressource, int disponibilite, string description, DateTime date_achat, string qrcode, Boolean purge, string nom_genre, int id_ressource)
        {
            // On lie les réponses du formulaire d'édition qui seront en paramètres à une Ressource de la BDD
            Ressource ressource = new Ressource();
            ressource.Nom_Ressource = nom_ressource;
            ressource.Disponibilite = disponibilite;
            ressource.Description = description;
            ressource.Date_Achat = date_achat;
            ressource.QRCode = qrcode;
            ressource.Purge = purge;
            ressource.ID_Genre = db.Genre.Where(g => g.Nom_Genre == nom_genre).FirstOrDefault().ID_Genre;
            ressource.ID_Ressource = id_ressource;
            // Envoi de la modification des données de la ressource dans la BDD
            db.Entry(ressource).State = EntityState.Modified;
            db.SaveChanges();
            // Création de la ressource précédemment créé suivant le modèle
            RessourceModel ressources = new RessourceModel();
            ressources.Nom_Ressource = ressource.Nom_Ressource;
            ressources.Disponibilite = (int)ressource.Disponibilite;
            ressources.Description = ressource.Description;
            ressources.Date_Achat = (DateTime)ressource.Date_Achat;
            ressources.QRCode = ressource.QRCode;
            ressources.Purge = (Boolean)ressource.Purge;
            ressources.ID_Genre = (int)ressource.ID_Genre;
            ressources.ID_Ressource = (int)ressource.ID_Ressource;
            return ressources;
        }
        public void setCreateRessource(string nom_ressource, int disponiblite, string description, DateTime date_achat, string qrcode, string nom_genre)
        {
            // On lie les réponses du formulaire d'ajout qui seront en paramètres à une Ressource de la BDD
            Ressource ressource = new Ressource();
            ressource.Nom_Ressource = nom_ressource;
            ressource.Disponibilite = disponiblite;
            ressource.Description = description;
            ressource.Date_Achat = date_achat;
            ressource.QRCode = qrcode;
            ressource.ID_Genre = db.Genre.Where(g => g.Nom_Genre == nom_genre).FirstOrDefault().ID_Genre;
            ressource.Purge = false;
            // On ajoute la ressource
            db.Ressource.Add(ressource);
            db.SaveChanges();
        }

        public void setRemoveRessource(int id_ressource)
        {
            // On récupere la ressource suivant son id
            Ressource ressource = db.Ressource.FirstOrDefault(r => r.ID_Ressource == id_ressource);
            //On passe l'élément "purge" a true
            ressource.Purge = true;
            //On applique ces changements
            db.Entry(ressource).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
