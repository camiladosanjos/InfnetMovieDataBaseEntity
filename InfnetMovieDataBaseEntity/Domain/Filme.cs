using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfnetMovieDataBaseEntity.Domain
{
    public class Filme
    {
        public int FilmeId { get; set; }
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Título Original")]
        public string TituloOriginal { get; set; }
        [Display(Name = "Ano de Lançamento")]
        public int Ano { get; set; }
        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
        public ICollection<Pessoa> Pessoas{ get; set; }
        public Filme()
        {
            Pessoas = new List<Pessoa>();
        }
    }
}
