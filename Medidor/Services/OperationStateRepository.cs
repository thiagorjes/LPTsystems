using System;
using System.Collections.Generic;
using System.Linq;
using Medidor.Interfaces;
using Medidor.Models;

namespace Medidor.Services
{
    public class OperationStateRepository 
    {
        private OperationState OpState; 
        public OperationStateRepository()
        {
            OpState = new OperationState();
            OpState.State = 0;//start in stand by mode , off(0)... 
        }
        public OperationStateRepository(int state){
            OpState = new OperationState();
            OpState.State = state; //start in specific state 0, 1 or 2
        }
        public object Read(){ //Read de Operation State
            try
            {
                return OpState;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Update(object newObject ){ //Update de Operation State
            try
            {
                OpState = (OperationState) newObject;
                return OpState;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}       