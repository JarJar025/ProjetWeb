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
    public class ProfilController : ApiController
    {
        // On instancie un profilBL pour utiliser les fonctions codées dedans
        private ProfilBL ProfilBL = new ProfilBL();

        // GET: api/Profil
        public List<ProfilModel> Get()
        {
            // On appelle la fonction getProfilAll de ProfilBL
            return ProfilBL.getProfilAll();
        }

        // GET: api/Profil/5
        public ProfilModel Get(int id)
        {
            // On appelle la fonction getProfilById de ProfilBL
            return ProfilBL.getProfilbyId(id);
        }
    }
}
