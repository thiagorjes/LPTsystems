using System;
using System.Collections.Generic;

namespace LPT.Models
{
    public partial class Experimento
    {
        public Experimento()
        {
            DadoColetado = new HashSet<DadoColetado>();
            MedidorExperimento = new HashSet<MedidorExperimento>();
        }

        public int IdExperimento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public virtual ICollection<DadoColetado> DadoColetado { get; set; }
        public virtual ICollection<MedidorExperimento> MedidorExperimento { get; set; }
    }
}
