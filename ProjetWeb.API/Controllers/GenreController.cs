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
    public class GenreController : ApiController
    {
        // On instancie un GenreBL pour utiliser les fonctions codées dedans
        private GenreBL BLgenre = new GenreBL();
        // GET: api/Genre
        public List<GenreModel> Get()
        {
            // On appelle la fonction getGenreAll de GenreBL
            return BLgenre.getGenreAll();
        }
        // GET: api/Genre/5
        public GenreModel Get(int id)
        {
            // On appelle la fonction getGenreById de GenreBL
            return BLgenre.getGenrebyId(id);
        }
    }
}
