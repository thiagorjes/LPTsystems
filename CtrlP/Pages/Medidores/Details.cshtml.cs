using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
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

namespace CtrlP.Pages.Medidores
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public SensorSettings medidor {get;set;}
        public static List<SelectListItem> listaGrandezas = new List<SelectListItem>();
        public static List<SelectListItem> listaOpStates = new List<SelectListItem>();
        private static readonly WebClient client = new WebClient();  
        public static string Page_Title = "Detalhes do Medidor ";

        public DetailsModel(){
            
        }

        public ActionResult OnGet(string HWIP)
        {
            try
            {
                client.Headers["Content-type"] = "application/json";
                Stream data = client.OpenRead (HWIP+"/medidor/sensorsettings");
                StreamReader reader = new StreamReader (data);
                string s = reader.ReadToEnd();
                medidor = (SensorSettings)JsonConvert.DeserializeObject(s,typeof(SensorSettings));
                bool isSelected= false;
                new GrandezasModel();
                string[] lista = {"Off","On","Calibrate"};
                for(int id=0;id<lista.Count();id++){
                    isSelected = false;
                    if(id == medidor.State){
                        isSelected = true;
                    }
                    listaOpStates.Add(new SelectListItem
                    {
                        Text = lista[id],
                        Value = id.ToString(),
                        Selected = isSelected
                    });
                }
                isSelected=false;
                foreach(var item in GrandezasModel.grandezas){
                    isSelected = false;
                    if(item.IdGrandeza == medidor.OperationType){
                        isSelected = true;
                    }
                    listaGrandezas.Add(new SelectListItem
                    {
                        Text = item.Descricao,
                        Value = item.IdGrandeza.ToString(), 
                        Selected = isSelected
                    });
                }
                data.Close ();
                reader.Close ();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                medidor = new SensorSettings();
            }
            Page_Title = "Detalhes do Medidor";
            return Page();
        }
    }
}

