using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Medidor.Models;
using Medidor.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
                SensorSettings temp = (SensorSettings)repositorio.Read();
                string jsonstring = JsonConvert.SerializeObject(temp);
                return this.Ok(jsonstring);
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