using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CtrlP.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Text;

namespace CtrlP.Pages.Medidores
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public SensorSettings medidor {get;set;}
        public static List<SelectListItem> listaGrandezas = new List<SelectListItem>();
        public static List<SelectListItem> listaOpStates = new List<SelectListItem>();
        private static readonly WebClient client = new WebClient();  
        public static string Page_Title = "Editar o Medidor ";
        static DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Experimento));
        NumberStyles styles;
        IFormatProvider provider;
        public EditModel(){
            styles = NumberStyles.Float;
            provider = CultureInfo.CreateSpecificCulture("en-US");
            if(listaOpStates.Count==0){
                string[] lista = {"Off","On","Calibrate"};
                for(int id=0;id<lista.Count();id++){
                    listaOpStates.Add(new SelectListItem
                    {
                        Text = lista[id],
                        Value = id.ToString(),
                        Selected = false
                    });
                }
            }
            new GrandezasModel();
            if(listaGrandezas.Count==0){
                foreach(var item in GrandezasModel.grandezas){
                    listaGrandezas.Add(new SelectListItem
                    {
                        Text = item.Descricao,
                        Value = item.IdGrandeza.ToString(), 
                        Selected = false
                    });
                }
            }
        }

        public ActionResult OnGet(int idx)
        {
            if(idx<0){
               return NotFound();
            }

            try
            {
                medidor = MedidoresModel.Medidores.ElementAt(idx);
                /*client.Headers["Content-type"] = "application/json";
                Stream data = client.OpenRead (HWIP+"/medidor/sensorsettings");
                StreamReader reader = new StreamReader (data);
                string s = reader.ReadToEnd();
                medidor = (SensorSettings)JsonConvert.DeserializeObject(s,typeof(SensorSettings));*/
                string[] lista = {"Off","On","Calibrate"};
                for(int id=0;id<lista.Count();id++){
                    if(id == medidor.State){
                        listaOpStates.ElementAt(id).Selected=true;
                    }
                }
                foreach(var item in GrandezasModel.grandezas){
                    if(item.IdGrandeza == medidor.OperationType){
                        listaGrandezas.ElementAt(item.IdGrandeza-1).Selected=true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                medidor = new SensorSettings();
                return NotFound();
            }

            Page_Title = "Editar Medidor";
            return Page();
        
        }

        public ActionResult OnPostSave()  {
            return  OnPost();
        }
        public ActionResult OnPost()  
        {  
            if (!ModelState.IsValid)  
            {  
                return Page();  
            }  
            //metodo que altera o medidor
            try
            { 
                
                for( int i =0; i<medidor.CalibrationParameters.Count;i++){
                    var temp = Double.Parse((Request.Form["medidor.CalibrationParameters["+i+"]"]).ToString(),styles,provider);
                    medidor.CalibrationParameters[i]= temp;
                }
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding(); 
                var jsonstring = JsonConvert.SerializeObject(medidor);
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonstring));
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(medidor.HWIP+"/Medidor/SensorSettings"); 
                request.Method = "PUT"; 
                request.ContentType = "application/json"; 
                request.ContentLength = ms.ToArray().Length; 
                request.KeepAlive = true; 
                Stream dataStream = request.GetRequestStream(); 
                dataStream.Write(ms.ToArray(), 0, ms.ToArray().Length); 
                dataStream.Close(); 
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string returnString = response.StatusCode.ToString(); 
                MedidoresModel.UpdateMedidores(MedidoresModel.Medidores);
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
            //fim do metodo
            return RedirectToPage("../Medidores/","Details",new { HWIP = medidor.HWIP });
        }

        public ActionResult OnPostAddCalParam()
        {
            medidor.CalibrationParameters.Add(0);
            return Page();
        }
        public ActionResult OnPostRemoveLast()
        {
            medidor.CalibrationParameters.RemoveAt(medidor.CalibrationParameters.Count - 1);
            return Page();
        }

    }
}

