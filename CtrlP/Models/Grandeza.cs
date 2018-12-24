using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace CtrlP.Models
{
    [DataContract(Name="Grandeza")]
    public partial class Grandeza
    {
        public Grandeza()
        {
            DadoColetado = new HashSet<DadoColetado>();
        }

        [DataMember(Name="idGrandeza")]
        public int IdGrandeza { get; set; }
        [DataMember(Name="descricao")]
        public string Descricao { get; set; }

        public virtual ICollection<DadoColetado> DadoColetado { get; set; }
    }
}
