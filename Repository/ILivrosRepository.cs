using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Model;

namespace webapi.Repository
{
    public interface ILivrosRepository
    {
        Task<IEnumerable<Livro>> BuscaLivros();
        Task<Livro> BuscaLivro(int id);
        void AdicionaLivro(Livro livro);
        void AtualizaLivro(Livro livro);
        void DeletaLivro(Livro livro);

        Task<bool> SaveChangesAcync();
    }
}