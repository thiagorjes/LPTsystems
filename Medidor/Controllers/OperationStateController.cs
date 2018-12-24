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
    public class OperationStateController : Controller
    {
        OperationStateRepository repositorio;
        public OperationStateController(){
            if(repositorio == null ){
                repositorio = Program.operationStateRepo;
                //OperationState op = new OperationState();
                //op.State = 2;
                //repositorio.Update(op);  //new OperationStateRepository setting the OpState to "calibrate"
            }            
        }
       
        [HttpGet]
        public IActionResult Read(){  //Read The OperationState from repository
            try {
                return this.Ok(repositorio.Read());
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut]
        public IActionResult Update([FromBody]OperationState newObject){ //Update The OperationState into Repository
            try {
                var c = repositorio.Update(newObject);
                return this.Ok(c);
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}   