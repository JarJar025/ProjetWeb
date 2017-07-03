using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.MODEL
{
    public class FonctionnaliteModel
    {
        public int ID_Fonctionnalite { get; set; }
        public String Nom_Fonctionnalite { get; set; }
        public FonctionnaliteModel()
        {

        }
        public FonctionnaliteModel(int fo, string nmf)
        {
            ID_Fonctionnalite = fo;
            Nom_Fonctionnalite = nmf;
        }
    }
}
