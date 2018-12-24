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
    public class GrandezaController : Controller
    {
        GrandezaRepository repositorio;
        public GrandezaController(){
            repositorio = new GrandezaRepository(new LPTContext());
        }
        [HttpPost]
        public IActionResult Create([FromBody]Grandeza t){
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
        [HttpGet("{IdGrandeza}")]
        public IActionResult Read(int IdGrandeza){
            try {
                return this.Ok(repositorio.Read(IdGrandeza));
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut("{IdGrandeza}")]
        public IActionResult Update(int IdGrandeza,[FromBody]Grandeza newObject){
            try {
                var c = repositorio.Update(IdGrandeza, newObject );
                return this.Ok(c);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{IdGrandeza}")]
        public IActionResult Delete(int IdGrandeza){
            try {
                //Console.WriteLine("ok " + IdGrandeza);
                repositorio.Delete(IdGrandeza);
                return this.Ok("Grandeza " + IdGrandeza + " deletado.");
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public IEnumerable<object> GrandezaAll(){
            return repositorio.GrandezaAll();
        }
    }
}