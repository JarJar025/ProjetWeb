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
    public class UtilisateurController : ApiController
    {
        // On instancie un utilisateurBL pour utiliser les fonctions codées dedans
        private UtilisateurBL BLUtilisateur = new UtilisateurBL();
        // GET: api/Users
        public List<UtilisateurModel> Get()
        {
            // On appelle la fonction getUserAll de UtilisateurBL
            return BLUtilisateur.getUtilisateurAll();
        }
        // GET: api/Users/5
        public UtilisateurModel Get(int id)
        {
            // On appelle la fonction getUserById de UtilisateurBL
            return BLUtilisateur.getUtilisateurbyId(id);
        }
    }
}
