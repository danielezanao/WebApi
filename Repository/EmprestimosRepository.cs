using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Model;


namespace webapi.Repository
{
    public class EmprestimosRepository : IEmprestimosRepository
    {

        private readonly LeitorContext _econtext;

        public EmprestimosRepository(LeitorContext econtext)
        {
            _econtext = econtext;
        }

        public void AdicionaEmprestimo(Emprestimo emprestimo)
        {
            _econtext.Add(emprestimo);
        }

        public async Task<Emprestimo> BuscaEmprestimo(int id)
        {
            return await _econtext.Emprestimos.
                        Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Emprestimo>> BuscaEmprestimos()
        {
            return await _econtext.Emprestimos.ToListAsync();
        }

        public void AtualizaEmprestimo(Emprestimo emprestimo)
        {
            _econtext.Update(emprestimo);
        }

        public void DeletaEmprestimo(Emprestimo emprestimo)
        {
            _econtext.Remove(emprestimo);
        }

        public async Task<bool> SaveChangesAcync()
        {
            return await _econtext.SaveChangesAsync() > 0;
        }
    }
}