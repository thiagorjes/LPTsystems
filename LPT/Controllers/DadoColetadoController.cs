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
    public class DadoColetadoController : Controller
    {
        DadoColetadoRepository repositorio;
        public DadoColetadoController(){
            repositorio = new DadoColetadoRepository(new LPTContext());
        }
        [HttpPost]
        public IActionResult Create([FromBody]DadoColetado t){
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
        [HttpGet("{IdDadoColetado}")]
        public IActionResult Read(int IdDadoColetado){
            try {
                return this.Ok(repositorio.Read(IdDadoColetado));
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut("{IdDadoColetado}")]
        public IActionResult Update(int IdDadoColetado,[FromBody]DadoColetado newObject){
            try {
                var c = repositorio.Update(IdDadoColetado, newObject );
                return this.Ok(c);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{IdDadoColetado}")]
        public IActionResult Delete(int IdDadoColetado){
            try {
                //Console.WriteLine("ok " + IdDadoColetado);
                repositorio.Delete(IdDadoColetado);
                return this.Ok("DadoColetado " + IdDadoColetado + " deletado.");
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        [HttpGet]
        public IEnumerable<object> DadoColetadoAll(){
            return repositorio.DadoColetadoAll();
        }
    }
}