using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace ProjetWeb.MODEL
{
    public class LigneResaViewModel
    {

        public LigneResaModel LigneResa { get; set; }

        [Display(Name = "ID Reservation")]
        public int SelectedIdReservation { get; set; }
        public IEnumerable<SelectListItem> IdReservation { get; set; }

        [Display(Name = "Nom de la ressource")]
        public int SelectedIdRessource { get; set; }
        public IEnumerable<SelectListItem> IdRessource { get; set; }

        public LigneResaViewModel()
        {
            
        }

        public LigneResaViewModel(LigneResaModel li, int idresa, int idress)
        {
            LigneResa = li;
            SelectedIdReservation = idresa;
            SelectedIdRessource = idress;

        }
    }
}
