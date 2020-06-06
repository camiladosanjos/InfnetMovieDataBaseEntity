using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfnetMovieDataBaseEntity.Domain
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Filme> Filmes { get; set; }

        public Genero()
        {
            Filmes = new List<Filme>();
        }
    }
}
