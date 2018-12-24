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
    public class ExperimentoController : Controller
    {
        ExperimentoRepository repositorio;
        public ExperimentoController(){
            repositorio = new ExperimentoRepository(new LPTContext());
        }
        [HttpPost]
        public IActionResult Create([FromBody]Experimento t){
            try {
                var c = repositorio.Create(t);
                Console.WriteLine("ok ");
                return this.Ok(c);
            }
            catch (Exception){
                Console.WriteLine("erro");
                return BadRequest();
            }
        }
        [HttpGet("{IdExperimento}")]
        public IActionResult Read(int IdExperimento){
            try {
                return this.Ok(repositorio.Read(IdExperimento));
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut("{IdExperimento}")]
        public IActionResult Update(int IdExperimento,[FromBody]Experimento newObject){
            try {
                var c = repositorio.Update(IdExperimento, newObject );
                return this.Ok(c);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{IdExperimento}")]
        public IActionResult Delete(int IdExperimento){
            try {
                //Console.WriteLine("ok " + IdExperimento);
                repositorio.Delete(IdExperimento);
                return this.Ok("Experimento " + IdExperimento + " deletado.");
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public IEnumerable<object> ExperimentoAll(){
            return repositorio.ExperimentoAll();
        }
    }
}