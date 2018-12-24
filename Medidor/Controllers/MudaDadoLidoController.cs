using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Medidor.Controllers
{
    [Route("Medidor/[controller]")]
    public class MudaDadoLidoController : Controller
    {
        [HttpPut("{DadoLido}")]
        public IActionResult Update(string DadoLido){
            try {
                Program.DadoLido=DadoLido;
                return this.Ok("atualizado");
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}       