using InfnetMovieDataBaseEntity.Domain;
using Microsoft.EntityFrameworkCore;

namespace InfnetMovieDataBaseEntity
{
    public class MovieEntityDb : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Genero> Generos { get; set; }

        public MovieEntityDb(DbContextOptions<MovieEntityDb> options) : base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=MovieEntity;MultipleActiveResultSets=true;" +
                "Trusted_Connection=true;";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Filme>()           
                .HasOne<Genero>(p => p.Genero)
                .WithMany(p => p.Filmes)
                .HasForeignKey(p => p.GeneroId);  

            modelBuilder.Entity<Pessoa>()           
                .HasOne<Filme>(p => p.Filme)
                .WithMany(p => p.Pessoas)
                .HasForeignKey(p =>p.FilmeId); 
        }
    }
}

