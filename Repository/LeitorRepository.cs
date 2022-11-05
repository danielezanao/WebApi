using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Model;

namespace webapi.Repository
{
    public class LeitorRepository : ULeitorRepository
    {
        private readonly LeitorContext _context;

        public LeitorRepository(LeitorContext context)
        {
            _context = context;
        }
        public void AdicionaLeitor(Leitor leitor)
        {
            _context.Add(leitor);
        }

        public async Task<IEnumerable<Leitor>> BuscaLeitores()
        {
            return await _context.Leitores.ToListAsync();
        }
        public async Task<Leitor> BuscaLeitor(int id)
        {
            return await _context.Leitores.
                        Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void AtualizaLeitor(Leitor leitor)
        {
            _context.Update(leitor);
        }

        public void DeletaLeitor(Leitor leitor)
        {
            _context.Remove(leitor);
        }

        public async Task<bool> SaveChangesAcync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}