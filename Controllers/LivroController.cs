using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Model;
using webapi.Repository;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivrosRepository _lrepository;

        public LivroController(ILivrosRepository lrepository)
        {
            _lrepository = lrepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Livro = await _lrepository.BuscaLivros();
            return Livro.Any()
            ? Ok(Livro)
            : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livro = await _lrepository.BuscaLivro(id);
            return livro != null
            ? Ok(livro)
            : NotFound("Livro não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Livro livro)
        {
            _lrepository.AdicionaLivro(livro);
            return await _lrepository.SaveChangesAcync()
                ? Ok("Livro adicionado com sucesso")
                : BadRequest("Erro ao salvar livro");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Livro livro)
        {
            var livroBanco = await _lrepository.BuscaLivro(id);
            if (livroBanco == null) return NotFound("Livro não encontrado");

            livroBanco.Nome = livro.Nome ?? livroBanco.Nome;
            livroBanco.Autor = livro.Autor ?? livroBanco.Autor;
            livroBanco.Genero = livro.Genero ?? livroBanco.Genero;
            livroBanco.Ano = livro.Ano ?? livroBanco.Ano;

            _lrepository.AtualizaLivro(livroBanco);

            return await _lrepository.SaveChangesAcync()
               ? Ok("Livro atualizado com sucesso")
               : BadRequest("Erro em atualizar livro");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var livroBanco = await _lrepository.BuscaLivro(id);
            if (livroBanco == null) return NotFound("Livro não encontrado");

            _lrepository.DeletaLivro(livroBanco);

            return await _lrepository.SaveChangesAcync()
               ? Ok("Livro deletado com sucesso")
               : BadRequest("Erro em deletar Livro");
        }
    }
}