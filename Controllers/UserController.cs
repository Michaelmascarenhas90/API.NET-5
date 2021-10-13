using System.Threading.Tasks;
using DOTNETAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOTNETAPI.Models;

namespace DOTNETAPI.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private DataContext dc;

        public UserController(DataContext context)
        {
            this.dc = context;
        }

        [HttpGet("api")]
        public async Task<ActionResult> listar()
        {
            var dados = await dc.user.ToListAsync();
            return Ok(dados);
        }

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Users p)
        {
            dc.user.Add(p);
            await dc.SaveChangesAsync();

            return Created("Objeto user", p);
        }


        [HttpGet("oi")]
        public string oi()
        {
            return "Hello World";
        }
    }
}
