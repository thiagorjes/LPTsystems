using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LPT.Models;
using LPT.Services;
using Microsoft.AspNetCore.Mvc;
namespace LPT.Controllers
{
    [Route("LPT/[controller]")]
    public class AcquiredDataController : Controller //Classe utilizada para salvar os dados vindos dos arduinos (medidores) que nao enviam o idExperimento.. 
    {
        DadoColetadoRepository repositorio;
        public AcquiredDataController(){
            repositorio = new DadoColetadoRepository(new LPTContext());
        }
        [HttpPost]
        public IActionResult Create([FromBody]DadoColetado t){
            try {
                t.Experimento = 3;//Program.experimentoAtivo; // Os dados sao recebidos e o idExperimento é "settado" com base no experimento ativo
                var c = repositorio.Create(t);
                Console.WriteLine("ok ");
                return this.Ok(c);
            }
            catch (Exception){
                Console.WriteLine("erro");
                return BadRequest();
            }
        }
    }
}