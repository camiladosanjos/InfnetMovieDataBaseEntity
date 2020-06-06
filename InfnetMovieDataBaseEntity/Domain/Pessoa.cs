using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfnetMovieDataBaseEntity.Domain
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
        public int FilmeId { get; set; }
        public virtual Filme Filme { get; set; }

        public int CalcularIdade()
        {
            return new DateTime(DateTime.Now.Subtract(DataNascimento).Ticks).Year - 1;
        }
    }
}
