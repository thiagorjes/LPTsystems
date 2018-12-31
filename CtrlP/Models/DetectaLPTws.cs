using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace CtrlP.Models{

    public abstract class DetectaLPTws
    {
        public static string LptWsAddress()
        {
            string LPT = Program.ServerProtocol+"localhost"+":"+Program.ServerPort;
            List<int> EndOfIp = Enumerable.Range(200,25).ToList();
            var foi = false;
            foreach(var ip in Program.ips)
            {
                if(ip.Contains("."))
                {
                    var bebinIp = ip.Remove(ip.Length-3);
                    foreach (var final in EndOfIp)
                    {
                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Program.ServerProtocol+bebinIp+final+":"+Program.ServerPort+"/LPT/Running"); 
                            request.Method = "GET"; 
                            request.Timeout=100;
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            Stream sr = response.GetResponseStream();
                            string returnString = response.StatusCode.ToString(); 
                            if(returnString=="OK"){
                                LPT=Program.ServerProtocol+bebinIp+final+":"+Program.ServerPort;
                                foi = true;
                                break;
                            }
                            else {
                                Console.WriteLine(Program.ServerProtocol+bebinIp+final+":"+Program.ServerPort+"/LPT/Running nao deu status ok... Tentando outro...");    
                            }    
                        }
                        catch (System.Exception)
                        {
                            Console.WriteLine(Program.ServerProtocol+bebinIp+final+":"+Program.ServerPort+"/LPT/Running nao respondeu FALHA GERAL... Tentando outro...");
                        }
                    }
                }
                if(foi)break;
            }
            return LPT;
        }
    }
}