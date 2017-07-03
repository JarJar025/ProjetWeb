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
    public class RessourceController : ApiController
    {
        // On instancie un RessourceBL pour utiliser les fonctions codées dedans
        private RessourceBL BLRessource = new RessourceBL();
        // GET: api/Ressource
        public List<RessourceModel> Get()
        {
            // On appelle la fonction getRessourceAll de RessourceBL
            return BLRessource.getRessourceAll();
        }
        // GET: api/Ressource/5
        public RessourceModel Get(int id)
        {
            // On appelle la fonction getRessourceById de RessourceBL
            return BLRessource.getRessourceById(id);
        }
    }
}
