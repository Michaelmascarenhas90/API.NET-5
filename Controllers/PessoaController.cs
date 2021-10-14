using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private DataContext dc;
        public PessoaController(DataContext context)
        {
            this.dc = context;
        }

        // metodo post na rota "/api" - para cadastro de novas pessoas
        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Pessoa p)
        {
            dc.pessoa.Add(p);
            await dc.SaveChangesAsync();

            return Created("Objeto pessoa", p);
        }

        [HttpGet("api")]

        public async Task<ActionResult> listar()
        {
            var dados = await dc.pessoa.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("api/{id}")]
        public Pessoa filtrar(int id)
        {
            Pessoa p = dc.pessoa.Find(id);
            return p;
        }

        [HttpPut("api")]
        public async Task<ActionResult> editar([FromBody] Pessoa p)
        {
            dc.pessoa.Update(p);
            await dc.SaveChangesAsync();
            return Ok(p);
        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> deletar(int id)
        {
            Pessoa p = filtrar(id);
            if (p == null)
            {
                return NotFound();
            }
            else
            {
                dc.pessoa.Remove(p);
                await dc.SaveChangesAsync();
                return Ok();
            }
        }

        // metodo get na rota "/oi" - vai retornar o valor explicito no return
        [HttpGet("oi")]
        public string oi()
        {
            return "Hello World";
        }
    }
}