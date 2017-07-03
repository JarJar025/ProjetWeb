using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.MODEL
{
    public class LigneResaModel
    {
        public int ID_Ligne_Reservation { get; set; }
        public DateTime Date_Debut { get; set; }
        public DateTime Date_Fin { get; set; }
        public Boolean Purge { get; set; }
        public int ID_Reservation { get; set; }
        public int ID_Ressource { get; set; }
        public LigneResaModel()
        {

        }
        public LigneResaModel(int id_ligne_resa, DateTime date_debut, DateTime date_fin, Boolean purge, int id_ress, int id_resa)
        {
            ID_Ligne_Reservation = id_ligne_resa;
            Date_Debut = date_debut;
            Date_Fin = date_fin;
            Purge = purge;
            ID_Reservation = id_resa;
            ID_Ressource = id_ress;
        }
    }
}
