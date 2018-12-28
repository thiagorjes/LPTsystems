 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using CtrlP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CtrlP.Pages
{
    public class MedidoresModel : PageModel
    {
        public static List<SensorSettings> Medidores { get; set; }
       // public static List<OperationState> MedidoresState { get; set; }
        public void OnGet()
        {
            if(Medidores == null || Medidores.Count == 0){
                Medidores = new List<SensorSettings>();
                //MedidoresState = new List<OperationState>();
                /*
                    deve ser substituido por um "broadcast" na rede procurando por http://IP:porta/Medidor/Running
                    sempre que responder ["running","ok"] deve ser adicionado à lista
                    list ip = { 1,2,3,4,5,6,7,8,9,0};
                    foreach (var final in ip){
                        tenta httpwebrequest em network+final:porta/Medidor/Running
                        if(retornou ok)
                        {
                            httpwebrequest em network+final:porta/Medidor/SensorSettings
                            httpwebrequest em network+final:porta/Medidor/OperationState
                            Medidores.Add(sensorSetting);
                            MedidoresState.Add(operationState);
                        }
                    }
                 */
                 
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:1000/Medidor/Running"); 
                request.Method = "GET"; 
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream sr = response.GetResponseStream();
                string returnString = response.StatusCode.ToString(); 
                if(returnString=="OK"){
                    request = (HttpWebRequest)HttpWebRequest.Create("http://localhost:1000/Medidor/SensorSettings"); 
                    request.Method = "GET"; 
                    response = (HttpWebResponse)request.GetResponse();
                    sr = response.GetResponseStream();
                    Type[] kt = {typeof(List<double>),typeof(string),typeof(int)};
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SensorSettings),kt);
                    Medidores.Add(ser.ReadObject(sr) as SensorSettings);
                    returnString = response.StatusCode.ToString(); 
                }
            }
        }
    }
}
