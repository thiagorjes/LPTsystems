using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medidor.Models;
using Medidor.Services;
using Microsoft.AspNetCore.Mvc;
namespace Medidor.Controllers
{
    [Route("Medidor/[controller]")]
    public class SensorSettingsController : Controller
    {
        SensorSettingsRepository repositorio;
        public SensorSettingsController(){
            if(repositorio == null){
                repositorio = Program.sensorSettingsRepo;
            }
        }
       
        [HttpGet]
        public IActionResult Read(){
            try {
                return this.Ok(repositorio.Read());
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody]SensorSettings newObject){
            try {
                var c = repositorio.Update(newObject );
                return this.Ok(c);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}       