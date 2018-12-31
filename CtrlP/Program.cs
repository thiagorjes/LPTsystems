using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using CtrlP.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CtrlP
{
    public class Program
    {
        public static string ServerIp = "localhost";
        public static string ServerProtocol = "http://";
        public static string ServerPort = "2005";
        public static string Baseurl = ServerProtocol+ServerIp+ServerPort;
        public static List<string> endereco = new List<string>();
        public static List<string> ips = new List<string>();
        public static void Main(string[] args)
        {

            try
            {
                List<string> url = new List<string>();
                string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
                Console.WriteLine(hostName);  
                // Get the IP  
                foreach(var ip in Dns.GetHostEntry(hostName).AddressList){
                    if(ip.ToString().Contains("."))
                    {
                        ips.Add(ip.ToString());
                        Console.WriteLine("My IP Address is :"+ip); 
                        var temp = ip.ToString();
                        url.Add("http://"+temp+":5000");
                    }
                }  
                endereco = url;
                Baseurl = DetectaLPTws.LptWsAddress();
                /* if(args!=null && args.Count()>0 && args[0].Contains("http://") && args[0].Contains(":2005") )
                {
                    Baseurl = args[0];
                }
                else {
                    Console.WriteLine(args.ToString());
                    throw(new Exception("Precisa de argumento string: http://enderecoDataBase:2005"));
                }*/
                var nfInfo = new System.Globalization.CultureInfo("en-US", false)
                {
                    NumberFormat =
                    {
                        NumberDecimalSeparator = "."
                    }
                };
                Thread.CurrentThread.CurrentCulture = nfInfo;
                Thread.CurrentThread.CurrentUICulture = nfInfo;
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(endereco.ToArray());
    }
}
