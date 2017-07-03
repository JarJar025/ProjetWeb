using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetWeb.DAL;
using ProjetWeb.MODEL;
namespace ProjetWeb.BL
{
    public class FonctionnaliteBL
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();

        // Récupérer toutes les fonctionnalités
        public List<FonctionnaliteModel> getFonctionnaliteAll()
        {
            var lesFonctionnalites = db.Fonctionnalite.Select(u => new FonctionnaliteModel()
            {
                ID_Fonctionnalite = u.ID_Fonctionnalite,
                Nom_Fonctionnalite = u.Nom_Fonctionnalite,
            });

            List<FonctionnaliteModel> FonctionnaliteAll = new List<FonctionnaliteModel>();

            FonctionnaliteAll = lesFonctionnalites.ToList();

            return FonctionnaliteAll;
        }
        public FonctionnaliteModel GetFonctionnalitebyId(int id)
        {
            var FonctionnaliteById = db.Fonctionnalite.Where(p => p.ID_Fonctionnalite == id).Select(u => new FonctionnaliteModel()
            {
                ID_Fonctionnalite = u.ID_Fonctionnalite,
                Nom_Fonctionnalite = u.Nom_Fonctionnalite,
            }).FirstOrDefault();

            return FonctionnaliteById;
        }
    }
}
