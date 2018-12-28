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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CtrlP.Models;

namespace CtrlP.Pages.Experimentos
{
    public class DetailsModel : PageModel
    {
        public Experimento experimento {get;set;}
        private static readonly WebClient client = new WebClient();  
        public static string Page_Title = "Detalhes do Experimento ";
        public DetailsModel(){
            
        }

        public ActionResult OnGet(int id)
        {
            try
            {
                client.Headers["Content-type"] = "application/json";
                Stream data = client.OpenRead (Program.Baseurl+"/LPT/Experimento/"+id);
                StreamReader reader = new StreamReader (data);
                string s = reader.ReadToEnd();
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(s));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Experimento));
                experimento = ser.ReadObject(ms) as Experimento;
                ViewData["quantidadeDados"] = experimento.VolumeDeDados;
                data.Close ();
                reader.Close ();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                experimento = new Experimento();
                ViewData["quantidadeDados"] =0;
            }
            Page_Title = id+" - Detalhes do Experimento ";
            return Page();
        }
        public ActionResult OnPostCancel(int id)
        {
            if (id < 1)  
            {  
                return NotFound();  
            }  
  
            return RedirectToPage("./Experimentos"); 
        }
    }
}

