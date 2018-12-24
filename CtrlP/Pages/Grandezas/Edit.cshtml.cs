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

namespace CtrlP.Pages.Grandezas
{
    public class EditModel : PageModel
    {
        [BindProperty] 
        public Grandeza grandeza {get;set;}
        private static readonly WebClient client = new WebClient();  
        public static string Page_Title = "Detalhes do Grandeza ";
        static DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Grandeza));
        public EditModel(){
            
        }

        public ActionResult OnGet(int? id)
        {
            
            if(id == null)
            {
                return NotFound();
            }

            try
            {
                client.Headers["Content-type"] = "application/json";
                Stream data = client.OpenRead (Program.Baseurl+"/LPT/Grandeza/"+id);
                StreamReader reader = new StreamReader (data);
                string s = reader.ReadToEnd();
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(s));
                grandeza = ser.ReadObject(ms) as Grandeza;
                data.Close ();
                reader.Close ();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                grandeza = new Grandeza();
            }
            
            if(grandeza.IdGrandeza==0)
            {
                return NotFound();
            }

            Page_Title = id+" - Alterar Grandeza ";
            return Page();
        }
        public ActionResult OnPost()  
        {  
            if (!ModelState.IsValid)  
            {  
                return Page();  
            }  
            //metodo que altera o grandeza
            try
            { 
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding(); 
                MemoryStream ms = new MemoryStream();
                ser.WriteObject(ms,grandeza);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Program.Baseurl+"/LPT/Grandeza/"+grandeza.IdGrandeza); 
                request.Method = "PUT"; 
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
            return RedirectToPage("../Grandezas");
        }

    }
}

