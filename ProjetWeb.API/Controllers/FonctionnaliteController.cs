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
    public class FonctionnaliteController : ApiController
    {
        // On instancie un FonctionnaliteBL pour utiliser les fonctions codées dedans
        private FonctionnaliteBL BLfonctionnalite = new FonctionnaliteBL();

        // GET: api/Fonctionnalite
        public List<FonctionnaliteModel> Get()
        {
            // On appelle la fonction getFonctionnaliteAll de FonctionnaliteBL
            return BLfonctionnalite.getFonctionnaliteAll();
        }
        // GET: api/Fonctinnalite/5
        public FonctionnaliteModel Get(int id)
        {
            // On appelle la fonction getFonctionnaliteById de FonctionnaliteBL
            return BLfonctionnalite.GetFonctionnalitebyId(id);
        }
    }
}
