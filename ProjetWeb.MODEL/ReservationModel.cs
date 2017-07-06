using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.MODEL
{
    public class ReservationModel
    {
        public int id_Reservation { get; set; }
        public DateTime Date_Debut_Resa { get; set; }
        public DateTime Date_Fin_Resa { get; set; }
        public DateTime Date_Resa { get; set; }
        public Boolean Purge { get; set; }
        public int id_User { get; set; }
        public String Nom_User { get; set; }
        public Boolean CheckEdit { get; set; }
        public ReservationModel()
        {

        }
        public ReservationModel(int id_Resa, DateTime ddr, DateTime dfr, DateTime dr, Boolean p, int id_U)
        {
            id_Reservation = id_Resa;
            Date_Debut_Resa = ddr;
            Date_Fin_Resa = dfr;
            Date_Resa = dr;
            Purge = p;
            id_User = id_U;
        }
        public ReservationModel(DateTime ddr, DateTime dfr, DateTime dr, Boolean p, int id_U)
        {
            Date_Debut_Resa = ddr;
            Date_Fin_Resa = dfr;
            Date_Resa = dr;
            Purge = p;
            id_User = id_U;
        }
    }
}
