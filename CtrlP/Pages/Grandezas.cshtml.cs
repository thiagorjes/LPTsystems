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
    public class GrandezasModel : PageModel
    {
        public static List<Grandeza> grandezas;
        private static readonly WebClient client = new WebClient();  
        static DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Grandeza>));
        public static string Page_Title = "Gerencie Grandezas ";
        public GrandezasModel(){
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Program.Baseurl+"/LPT/Grandeza/"); 
                request.Method = "GET"; 
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream sr = response.GetResponseStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Grandeza>));
                grandezas = ser.ReadObject(sr) as List<Grandeza>;
                string returnString = response.StatusCode.ToString(); 
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                grandezas = new List<Grandeza>();
            }
        }
        public void OnGet()
        {
            Page_Title = "Gerencie Grandezas";
        }
    }
}
