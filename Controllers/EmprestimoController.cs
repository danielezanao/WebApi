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
    public class EmprestimoController : ControllerBase
    {

        private readonly IEmprestimosRepository _erepository;

        public EmprestimoController(IEmprestimosRepository erepository)
        {
            _erepository = erepository;
        }

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var emprestimos = await _erepository.BuscaEmprestimos();
            return emprestimos.Any()
            ? Ok(emprestimos)
            : NoContent();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var emprestimo = await _erepository.BuscaEmprestimo(id);
            return emprestimo != null
            ? Ok(emprestimo)
            : NotFound("Emprestimo não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Emprestimo emprestimo)
        {
            _erepository.AdicionaEmprestimo(emprestimo);
            return await _erepository.SaveChangesAcync()
                ? Ok("Emprestimo adicionado com sucesso")
                : BadRequest("Erro ao salvar Emprestimo");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Emprestimo emprestimo)
        {
            var emprestimoBanco = await _erepository.BuscaEmprestimo(id);
            if (emprestimoBanco == null) return NotFound("Emprestimo não encontrado");

            emprestimoBanco.Id_leitor = emprestimo.Id_leitor;
            emprestimoBanco.Id_livro = emprestimo.Id_livro;
            emprestimoBanco.DataEmprestimo = emprestimo.DataEmprestimo != new DateTime()
            ? emprestimoBanco.DataEmprestimo : emprestimoBanco.DataEmprestimo;
            emprestimoBanco.DataDevolucao = emprestimo.DataDevolucao != new DateTime()
            ? emprestimoBanco.DataDevolucao : emprestimoBanco.DataDevolucao;

            _erepository.AtualizaEmprestimo(emprestimoBanco);

            return await _erepository.SaveChangesAcync()
               ? Ok("Emprestimo atualizado com sucesso")
               : BadRequest("Erro em atualizar emprestimo");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var emprestimoBanco = await _erepository.BuscaEmprestimo(id);
            if (emprestimoBanco == null) return NotFound("Emprestimo não encontrado");

            _erepository.DeletaEmprestimo(emprestimoBanco);

            return await _erepository.SaveChangesAcync()
               ? Ok("Emprestimo deletado com sucesso")
               : BadRequest("Erro em deletar emprestimo");
        }
    }
}