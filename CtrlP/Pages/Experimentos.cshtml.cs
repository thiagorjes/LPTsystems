

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

namespace CtrlP.Pages
{
    public class ExperimentosModel : PageModel
    {
        public static List<Experimento> experimentos;
        private static readonly WebClient client = new WebClient();  
        public static string Page_Title = "Gerencie Experimentos ";
        public ExperimentosModel(){
            try
            {
                client.Headers["Content-type"] = "application/json";
                Stream data = client.OpenRead (Program.Baseurl+"/LPT/Experimento");
                StreamReader reader = new StreamReader (data);
                string s = reader.ReadToEnd();
                MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(s));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Experimento>));
                experimentos = ser.ReadObject(ms) as List<Experimento>;
                data.Close ();
                reader.Close ();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                experimentos = new List<Experimento>();
            }
        }

        public void OnGet()
        {
            Page_Title = "Gerencie Experimentos";
        }
    }
}

