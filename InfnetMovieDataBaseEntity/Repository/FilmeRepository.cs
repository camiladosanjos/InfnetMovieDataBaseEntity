using InfnetMovieDataBaseEntity.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq;

namespace InfnetMovieDataBaseEntity.Repository
{
    public class FilmeRepository : IBase<Filme>
    {
        private readonly DbContextOptions<MovieEntityDb> _optionsBuilder;
        public FilmeRepository()
        {
            _optionsBuilder = new DbContextOptions<MovieEntityDb>();
        }

        public void Excluir(int id)
        {
            using var db = new MovieEntityDb(_optionsBuilder);
            using IDbContextTransaction t = db.Database.BeginTransaction();

            var filmes = db.Filmes.Where(p => p.FilmeId.Equals(id));
            
            db.RemoveRange(filmes);
            db.SaveChanges();
            t.Commit();
        }

        public void Atualizar(Filme filme)
        {
            using var db = new MovieEntityDb(_optionsBuilder);
         
            var filmes = db.Filmes.Where(p => p.FilmeId.Equals(filme.FilmeId));
            
            foreach (var f in filmes)
            {
                f.Ano = filme.Ano;
                f.GeneroId = filme.GeneroId;
            }

            int affected = db.SaveChanges();
        }

        public void Adicionar(Filme filmeNovo)
        {
            using var db = new MovieEntityDb(_optionsBuilder);
            
            db.Filmes.Add(filmeNovo);
            db.SaveChanges();
        }

        public IList<Filme> Listar()
        {
            using var db = new MovieEntityDb(_optionsBuilder);
            IOrderedEnumerable<Filme> filmes = db.Filmes.AsEnumerable().OrderByDescending(c => c.Ano);

            return filmes.ToList();
        }

        public Filme Detalhar(int id)
        {
            using var db = new MovieEntityDb(_optionsBuilder);
            var filme = db.Filmes.Where(c => c.FilmeId.Equals(id));

            return (Filme) filme;
        }

        public IList<Filme> ListarFilmesPorGenero()
        {
            using var db = new MovieEntityDb(_optionsBuilder);
            IOrderedEnumerable<Filme> filmes = db.Filmes.AsEnumerable().OrderByDescending(c => c.GeneroId);
            
            return filmes.ToList();

        }
    }
}
