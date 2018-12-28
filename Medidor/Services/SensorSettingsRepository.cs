using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using Medidor.Interfaces;
using Medidor.Models;

namespace Medidor.Services
{
    public class SensorSettingsRepository 
    {
        //private SensorSettings sensorSettings;
        public SensorSettingsRepository()
        {
            /* if(Program.sensorSettings!=null ){
                sensorSettings = Program.sensorSettings;
            }
            else {
                sensorSettings = new SensorSettings();
            }*/
        }
        
        public object Read(){
            try
            {
                return Program.sensorSettings;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public object Update(object newObject ){
            try
            {
                foreach(var att in ((SensorSettings) newObject).GetType().GetProperties()){
                    Program.sensorSettings.GetType().GetProperty(att.Name).SetValue(Program.sensorSettings,att.GetValue(newObject));
                }
                DataContractJsonSerializer tempser = new DataContractJsonSerializer(typeof(SensorSettings));
                Program.settingsConf.Close();
                Program.settingsConf = File.Open("settings.conf",FileMode.Truncate);
                //Program.settingsConf.Seek(0, SeekOrigin.Begin);
                tempser.WriteObject(Program.settingsConf,Program.sensorSettings);
                //sensorSettings = Program.sensorSettings;
                return Program.sensorSettings;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}