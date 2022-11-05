using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Model;
using webapi.Data;

namespace webapi.Repository
{
    public class LivroRepository : ILivrosRepository
    {
        private readonly LeitorContext _lcontext;

        public LivroRepository(LeitorContext lcontext)
        {
            _lcontext = lcontext;
        }

        public void AdicionaLivro(Livro livro)
        {
            _lcontext.Add(livro);
        }

        public async Task<Livro> BuscaLivro(int id)
        {
            return await _lcontext.Livros.
                        Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Livro>> BuscaLivros()
        {
            return await _lcontext.Livros.ToListAsync();
        }

        public void AtualizaLivro(Livro livro)
        {
            _lcontext.Update(livro);
        }

        public void DeletaLivro(Livro livro)
        {
            _lcontext.Remove(livro);
        }

        public async Task<bool> SaveChangesAcync()
        {
            return await _lcontext.SaveChangesAsync() > 0;
        }
    }
}