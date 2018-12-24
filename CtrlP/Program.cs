using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CtrlP
{
    public class Program
    {
        public static string Baseurl = "http://10.10.10.211:2005";
        public static void Main(string[] args)
        {
            //System.Diagnostics.Process.Start(@"C:\Users\thiag\DOTNET\GITHUB\SistemaDeOperacaoDoPlasma\LPT\bin\Debug\netcoreapp2.2\win-x64\LPT.exe","http://10.10.10.211:2005");
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
