using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace CtrlP.Models
{
    [DataContract(Name="Experimento")]
    public partial class Experimento
    {
        public Experimento()
        {
            DadoColetado = new HashSet<DadoColetado>();
            MedidorExperimento = new HashSet<MedidorExperimento>();
        }
        
        [DataMember(Name="idExperimento")]
        public int IdExperimento { get; set; }
        [DataMember(Name="descricao")]
        public string Descricao { get; set; }
        [DataMember(Name="dataInicio")]
        public string JsonDateIni { get; set; }

        [IgnoreDataMember]
        public string DataInicio
        {
            get
            {
                if(JsonDateIni != null)
                    return DateTime.ParseExact(JsonDateIni.Replace('T',' '), "yyyy-MM-dd HH:mm:ss",  CultureInfo.CurrentCulture.DateTimeFormat).ToString();
                else 
                    return null;
            }
        }

        [DataMember(Name="dataFim")]
        public string JsonDateFim { get; set; }
        
        [IgnoreDataMember]
        public string DataFim
        {
            get
            {
                if(JsonDateFim != null)
                    return DateTime.ParseExact(JsonDateFim.Replace('T',' '), "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture.DateTimeFormat).ToString();
                else 
                    return null;
            }
        }
        [DataMember(Name="volumeDeDados")]
        public int VolumeDeDados { get; set; }
        public virtual ICollection<DadoColetado> DadoColetado { get; set; }
        public virtual ICollection<MedidorExperimento> MedidorExperimento { get; set; }
    }
}
