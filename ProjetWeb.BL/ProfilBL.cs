using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetWeb.DAL;
using ProjetWeb.MODEL;

namespace ProjetWeb.BL
{
    public class ProfilBL
    {
        private BDD_GRP2Entities db = new BDD_GRP2Entities();
        // Récupérer tous les users
        public List<ProfilModel> getProfilAll()
        {
            var lesProfils = db.Profil.Select(u => new ProfilModel()
            {
                ID_Profil = u.ID_Profil,
                Nom_Profil = u.Nom_Profil,
            });
            List<ProfilModel> ProfilAll = new List<ProfilModel>();
            ProfilAll = lesProfils.ToList();
            return ProfilAll;
        }
        // Récupérer un utilisateur suivant son id
        public ProfilModel getProfilbyId(int id)
        {
            var ProfilById = db.Profil.Where(p => p.ID_Profil == id).Select(u => new ProfilModel()
            {
                ID_Profil = u.ID_Profil,
                Nom_Profil = u.Nom_Profil,
            }).FirstOrDefault();
            return ProfilById;
        }
    }
}
