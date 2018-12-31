using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LPT.Models;
using LPT.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
namespace LPT
{
    public class Program
    {
        
        public static string[] endereco ;
        public static int experimentoAtivo; //é "settado" quando um novo experimento é criado.
        public static string conexao;
        public static HubConnection connection;
        public static string CtrlP;
        public static void Main(string[] args)
        {    
             try
            {
                List<string> url = new List<string>();
                string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
                Console.WriteLine(hostName);  
                // Get the IP  
                foreach(var ip in Dns.GetHostEntry(hostName).AddressList){
                    ip.ToString();
                    Console.WriteLine("My IP Address is :"+ip); 
                    var temp = (ip.ToString().Contains(":")?"["+ip+"]":ip.ToString());
                    url.Add("http://"+temp+":2005");
                }  
                endereco = url.ToArray();
                if(args!=null && args.Count()>0 && args[0].Contains("http://") && args[0].Contains(":5000") ){
                    CtrlP = args[0];
                }
                else {
                    Console.WriteLine(args.ToString());
                    throw(new Exception("Precisa de argumento string: http://enderecoCtrlP:5000"));
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            connection =new HubConnectionBuilder()
                .WithUrl(CtrlP+"/chatHub")
                .Build();
            

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseUrls(endereco);
                
    }
}
