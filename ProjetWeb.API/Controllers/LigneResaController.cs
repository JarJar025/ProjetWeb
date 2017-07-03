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
    public class LigneResaController : ApiController
    {
        // On instancie un LigneResaBL pour utiliser les fonctions codées dedans
        private LigneResaBL BLresa = new LigneResaBL();
        // GET: api/LigneResa
        public List<LigneResaModel> Get()
        {
            // On appelle la fonction getLigneResaAll de LigneResaBL
            return BLresa.getLigneResaAll();
        }
        // GET: api/LigneResa/5
        public LigneResaModel Get(int id)
        {
            // On appelle la fonction getLigneResaById de LigneResaBL
            return BLresa.getLigneResaById(id);
        }
    }
}
