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
using Medidor.Models;
using Medidor.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Medidor
{
    public class Program
    {
        public static SensorSettings sensorSettings;
        public static FileStream settingsConf;
        public static SensorSettingsRepository sensorSettingsRepo = new SensorSettingsRepository();
        public static OperationStateRepository operationStateRepo = new OperationStateRepository(0);
        public static string DadoLido = "";
        public static Thread longThread = new Thread(() => EnviaDados());
        private static readonly WebClient client = new WebClient();        
        public static string TipoGrandeza = "";
        public static string endereco;
        public static void Main(string[] args)
        {
            try
            {
                settingsConf = File.Open("settings.conf",FileMode.OpenOrCreate);
                sensorSettings = new SensorSettings();           
                DataContractJsonSerializer tempser = new DataContractJsonSerializer(typeof(SensorSettings));
                sensorSettings = tempser.ReadObject(settingsConf) as SensorSettings;

                if(args[0].Contains("http://")){
                    endereco = args[0];
                }
                else {
                    Console.WriteLine(args.ToString());
                }
            }
            catch (System.Exception ex)
            {
                endereco = "http://localhost:1000";
                sensorSettings.OperationType=1;
                sensorSettings.ServersIP="http://localhost:2005";
                sensorSettings.HWIP=endereco;
                System.Console.Write(ex.Message);
            }
            
            sensorSettingsRepo.Update(sensorSettings);
          
            longThread.Start();
            CreateWebHostBuilder(args).Build().Run();
            
        }

        private static void EnviaDados()
        {
            while(true){

                //simula a leitura dos dados a cada 1000 milisegundos
                Thread.Sleep(1000);
                
                switch(((OperationState)operationStateRepo.Read()).State)
                {
                    //verifica o estado de operacao do medidor
                    case 0://offline - standby
                    {
                        //System.Console.Clear();
                        break;
                    }
                    case 1://on - enviando dados ao servidor de dados
                    {
                        var temp = new DadoColetado();
                        temp.Experimento=0;
                        temp.ColetadoEm=DateTime.Now;
                        temp.Hwid = ((SensorSettings)sensorSettingsRepo.Read()).HWID;
                        
                        var valorReal = 0.0;
                        /*
                            converte o valor lido em valor real, assumindo que seja um polinomio A*x + B*x^2 + C*x^3 etc etc
                            OS coeficientes sao os elementos da lista CalibrationParameters, os expoentes sao os indices dos elementos na  lista e o X é 
                            a variavel ValorLido.

                            caso polinomios nao sejam a melhor aproximacao, uma nova abordagem deve ser feita e implementada aqui!
                         */

                        foreach(var coef in sensorSettings.CalibrationParameters){
                            int idx =sensorSettings.CalibrationParameters.ToList().IndexOf(coef);
                            double pot = Math.Pow(Int32.Parse(DadoLido),idx);
                            valorReal += coef*pot;
                        }
                        // fim da funcao que converte valorlido em valor real
                        temp.ValorLido = valorReal; 
                        temp.IdDadoColetado=0;
                        temp.TipoDeGrandeza = ((SensorSettings)sensorSettingsRepo.Read()).OperationType;

                        client.Headers["Content-type"] = "application/json";
                        MemoryStream ms = new MemoryStream();
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DadoColetado));
                        ser.WriteObject(ms,temp);
                        byte[] data = client.UploadData(
                            ((SensorSettings)sensorSettingsRepo.Read()).ServersIP+"/LPT/AcquiredData",
                            "POST",
                            ms.ToArray()
                        );
                        ms = new MemoryStream(data);
                        DadoColetado returned = ser.ReadObject(ms) as DadoColetado;
                        System.Console.WriteLine(returned.Experimento +" -- "+temp.Experimento);
                        System.Console.WriteLine("Enviando "+((SensorSettings)sensorSettingsRepo.Read()).OperationType+":"+DadoLido);
                        break;
                    }
                    case 2: //calibrate - enviando dados raw para o servidor de dados afim de realizar a calibracao do medidor
                    {
                        var temp = new DadoColetado();
                        temp.Experimento=0;
                        temp.ColetadoEm=DateTime.Now;
                        temp.Hwid = ((SensorSettings)sensorSettingsRepo.Read()).HWID;
                        temp.ValorLido = Int32.Parse(DadoLido);
                        temp.IdDadoColetado=0;
                        temp.TipoDeGrandeza = 5 ;//raw;

                        client.Headers["Content-type"] = "application/json";
                        MemoryStream ms = new MemoryStream();
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(DadoColetado));
                        ser.WriteObject(ms,temp);
                        byte[] data = client.UploadData(
                            ((SensorSettings)sensorSettingsRepo.Read()).ServersIP+"/LPT/AcquiredData",
                            "POST",
                            ms.ToArray()
                        );
                        ms = new MemoryStream(data);
                        DadoColetado returned = ser.ReadObject(ms) as DadoColetado;
                        System.Console.WriteLine(returned.Experimento +" -- "+temp.Experimento);
                        System.Console.WriteLine("Enviando "+((SensorSettings)sensorSettingsRepo.Read()).OperationType+":"+DadoLido);
                        break;
                    }
                }
            }
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseUrls(sensorSettings.HWIP);
    }
}
