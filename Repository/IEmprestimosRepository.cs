using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Model;

namespace webapi.Repository
{
    public interface IEmprestimosRepository
    {
        Task<IEnumerable<Emprestimo>> BuscaEmprestimos();
        Task<Emprestimo> BuscaEmprestimo(int id);
        void AdicionaEmprestimo(Emprestimo emprestimo);
        void AtualizaEmprestimo(Emprestimo emprestimo);
        void DeletaEmprestimo(Emprestimo emprestimo);

        Task<bool> SaveChangesAcync();
    }
}