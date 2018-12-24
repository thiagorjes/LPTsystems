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
    public class CreateModel : PageModel
    {
        [BindProperty] 
        public Experimento experimento {get;set;}
        private static readonly WebClient client = new WebClient();  
        public static string Page_Title = "Detalhes do Experimento ";
        static DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Experimento));
        public CreateModel(){
            
        }

        public ActionResult OnGet()
        {
            experimento = new Experimento();   
            Page_Title = " - novo Experimento ";
            return Page();
        }
        public ActionResult OnPost()  
        {  
            if (!ModelState.IsValid)  
            {  
                return Page();  
            }  
            //metodo que altera o experimento
            try
            { 
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding(); 
                MemoryStream ms = new MemoryStream();
                ser.WriteObject(ms,experimento);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Program.Baseurl+"/LPT/Experimento/"); 
                request.Method = "POST"; 
                request.ContentType = "application/json"; 
                request.ContentLength = ms.ToArray().Length; 
                request.KeepAlive = true; 
                Stream dataStream = request.GetRequestStream(); 
                dataStream.Write(ms.ToArray(), 0, ms.ToArray().Length); 
                dataStream.Close(); 
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string returnString = response.StatusCode.ToString(); 
            }
            catch (System.Exception)
            {
                return NotFound();
            }
            //fim do metodo
            return RedirectToPage("../Experimentos");
        }

    }
}

