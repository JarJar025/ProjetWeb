using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetWeb.MODEL
{
    public class GenreModel
    {
        public int id_genre { get; set; }
        public String nom_genre { get; set; }
        public String description { get; set; }
        public Boolean purge { get; set; }
        public GenreModel()
        {

        }
        public GenreModel(int idg, String ng, String de, Boolean pu)
        {
            id_genre = idg;
            nom_genre = ng;
            description = de;
            purge = pu;
        }
    }
}
