using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.MODEL
{
    public class ProfilModel
    {
        public int ID_Profil { get; set; }
        public String Nom_Profil { get; set; }
        //Constructeur Vide qui permet l'utilisation du model sans utiliser les attributs
        public ProfilModel()
        {

        }
        public ProfilModel(int idp, string np)
        {
            ID_Profil = idp;
            Nom_Profil = np;
        }
    }
}
