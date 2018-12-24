using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LPT
{
    public class Program
    {
        
        public static string endereco;
        public static int experimentoAtivo; //é "settado" quando um novo experimento é criado.
        public static void Main(string[] args)
        {
             try
            {
                if(args[0].Contains("http://")){
                    endereco = args[0];
                }
                else {
                    Console.WriteLine(args.ToString());
                }
            }
            catch (System.Exception ex)
            {
                endereco = "http://10.10.10.211:2005";            
                Console.WriteLine(ex.Message);
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseUrls(endereco);
    }
}
