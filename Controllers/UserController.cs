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

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Users u)
        {
            dc.user.Add(u);
            await dc.SaveChangesAsync();

            return Created("Usuário cadastrado", u);
        }

        [HttpGet("oi")]
        public string oi()
        {
            return "Hello World";
        }
    }
}