using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Model;

namespace webapi.Repository
{
    public interface ULeitorRepository
    {
        Task<IEnumerable<Leitor>> BuscaLeitores();
        Task<Leitor> BuscaLeitor(int id);
        void AdicionaLeitor(Leitor leitor);
        void AtualizaLeitor(Leitor leitor);
        void DeletaLeitor(Leitor leitor);

        Task<bool> SaveChangesAcync();
    }
}