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
    public class LeitorController : ControllerBase
    {
        private readonly ULeitorRepository _repository;

        public LeitorController(ULeitorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leitores = await _repository.BuscaLeitores();
            return leitores.Any()
            ? Ok(leitores)
            : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leitor = await _repository.BuscaLeitor(id);
            return leitor != null
            ? Ok(leitor)
            : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Leitor leitor)
        {
            _repository.AdicionaLeitor(leitor);
            return await _repository.SaveChangesAcync()
                ? Ok("Usuário adicionado com sucesso")
                : BadRequest("Erro ao salvar usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Leitor leitor)
        {
            var leitorBanco = await _repository.BuscaLeitor(id);
            if (leitorBanco == null) return NotFound("Usuário não encontrado");

            leitorBanco.Nome = leitor.Nome ?? leitorBanco.Nome;
            leitorBanco.Email = leitor.Email ?? leitorBanco.Email;
            leitorBanco.DataNascimento = leitor.DataNascimento != new DateTime()
            ? leitor.DataNascimento : leitorBanco.DataNascimento;

            _repository.AtualizaLeitor(leitorBanco);

            return await _repository.SaveChangesAcync()
               ? Ok("Usuário atualizado com sucesso")
               : BadRequest("Erro em atualizar usuário");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var leitorBanco = await _repository.BuscaLeitor(id);
            if (leitorBanco == null) return NotFound("Usuário não encontrado");

            _repository.DeletaLeitor(leitorBanco);

            return await _repository.SaveChangesAcync()
               ? Ok("Usuário deletado com sucesso")
               : BadRequest("Erro em deletar usuário");
        }
    }
}