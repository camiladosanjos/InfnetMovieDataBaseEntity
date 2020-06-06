using System.Collections.Generic;

namespace InfnetMovieDataBaseEntity.Repository
{
    public interface IBase<T> where T : class
    {
        public void Excluir(int id);

        public void Atualizar(T valor);

        public void Adicionar(T valor);

        public IList<T> Listar();

        public T Detalhar(int id);
    }
}
