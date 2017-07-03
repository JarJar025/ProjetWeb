using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjetWeb.BL;
using ProjetWeb.MODEL;

namespace ProjetWeb.API.Controllers
{
    public class ReservationController : ApiController
    {
        // On instancie un ReservationBL pour utiliser les fonctions codées dedans
        private ReservationBL BLresa = new ReservationBL();
        // GET: api/Reservation
        public List<ReservationModel> Get()
        {
            // On appelle la fonction getResaAll de ProfilBL
            return BLresa.getResaAll();
        }
        // GET: api/Reservation/5
        public ReservationModel Get(int id)
        {
            // On appelle la fonction getResaById de ProfilBL
            return BLresa.getResaById(id);
        }
    }
}
