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
    public class MedidorExperimentoController : Controller
    {
        MedidorExperimentoRepository repositorio;
        public MedidorExperimentoController(){
            repositorio = new MedidorExperimentoRepository(new LPTContext());
        }
        [HttpPost]
        public IActionResult Create([FromBody]MedidorExperimento t){
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
        [HttpGet("{IdMedidorExperimento}")]
        public IActionResult Read(int IdMedidorExperimento){
            try {
                return this.Ok(repositorio.Read(IdMedidorExperimento));
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut("{IdMedidorExperimento}")]
        public IActionResult Update(int IdMedidorExperimento,[FromBody]MedidorExperimento newObject){
            try {
                var c = repositorio.Update(IdMedidorExperimento, newObject );
                return this.Ok(c);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{IdMedidorExperimento}")]
        public IActionResult Delete(int IdMedidorExperimento){
            try {
                //Console.WriteLine("ok " + IdMedidorExperimento);
                repositorio.Delete(IdMedidorExperimento);
                return this.Ok("MedidorExperimento " + IdMedidorExperimento + " deletado.");
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public IEnumerable<object> MedidorExperimentoAll(){
            return repositorio.MedidorExperimentoAll();
        }
    }
}