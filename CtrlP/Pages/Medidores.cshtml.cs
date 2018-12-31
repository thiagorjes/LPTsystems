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
       public static List<Grandeza> grandezas {get;set;}
       public static List<string> opstates {get;set;}
       public MedidoresModel(){
           opstates=new List<string>(){"Off","On","Calibrate"};
       }
        public void OnGet()
        {
            try
            {
                if(GrandezasModel.grandezas.Count()==0){
                    var grand = new GrandezasModel();
                }
                grandezas = GrandezasModel.grandezas;
                if(Medidores == null || Medidores.Count == 0)
                {
                    Medidores = UpdateMedidores();
                }    
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public ActionResult OnPostUpdateMedidores()
        {
            Medidores = UpdateMedidores();
            return Page();
        }
        public static void UpdateMedidores(List<SensorSettings> lista){
            foreach(var sensor in lista){
                try
                {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(sensor.HWIP+"/Medidor/Running"); 
                    request.Method = "GET"; 
                    request.Timeout=50;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream sr = response.GetResponseStream();
                    string returnString = response.StatusCode.ToString(); 
                    if(returnString=="OK"){
                        request = (HttpWebRequest)HttpWebRequest.Create(sensor.HWIP+"/Medidor/SensorSettings"); 
                        request.Method = "GET"; 
                        response = (HttpWebResponse)request.GetResponse();
                        sr = response.GetResponseStream();
                        Type[] kt = {typeof(List<double>),typeof(string),typeof(int)};
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SensorSettings),kt);
                        var atualizado = (ser.ReadObject(sr) as SensorSettings);
                        Medidores[Medidores.IndexOf(sensor)].CalibrationParameters=atualizado.CalibrationParameters;
                        Medidores[Medidores.IndexOf(sensor)].HWID=atualizado.HWID;
                        Medidores[Medidores.IndexOf(sensor)].HWIP=atualizado.HWIP;
                        Medidores[Medidores.IndexOf(sensor)].OperationType=atualizado.OperationType;
                        Medidores[Medidores.IndexOf(sensor)].ServersIP=atualizado.ServersIP;
                        Medidores[Medidores.IndexOf(sensor)].State=atualizado.State;
                        returnString = response.StatusCode.ToString(); 
                    }
                    else {
                        Console.WriteLine(sensor.HWIP+"/Medidor/Running nao respondeu... Tentando outro...");    
                    }    
                }
                catch (System.Exception)
                {
                    Console.WriteLine(sensor.HWIP+"/Medidor/Running nao respondeu... Tentando outro...");
                }
            }
        }
        public List<SensorSettings> UpdateMedidores()
        {
            List<SensorSettings> Medidores= new List<SensorSettings>();
            List<int> EndOfIp = Enumerable.Range(200,25).ToList();
            foreach(var ip in Program.ips)
            {
                if(ip.Contains(".")){
                    var bebinIp = ip.Remove(ip.Length-3);
                    foreach (var final in EndOfIp)
                    {
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://"+bebinIp+final+":1000/Medidor/Running"); 
                            request.Method = "GET"; 
                            request.Timeout=50;
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            Stream sr = response.GetResponseStream();
                            string returnString = response.StatusCode.ToString(); 
                            if(returnString=="OK"){
                                request = (HttpWebRequest)HttpWebRequest.Create("http://"+bebinIp+final+":1000/Medidor/SensorSettings"); 
                                request.Method = "GET"; 
                                response = (HttpWebResponse)request.GetResponse();
                                sr = response.GetResponseStream();
                                Type[] kt = {typeof(List<double>),typeof(string),typeof(int)};
                                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SensorSettings),kt);
                                Medidores.Add(ser.ReadObject(sr) as SensorSettings);
                                returnString = response.StatusCode.ToString(); 
                            }
                            else {
                                Console.WriteLine("http://"+bebinIp+final+":1000/Medidor/Running nao respondeu... Tentando outro...");    
                            }    
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine("http://"+bebinIp+final+":1000/Medidor/Running nao respondeu... Tentando outro...");
                        }
                    }
                }
            }
            
            return Medidores;
        }
    }
}
