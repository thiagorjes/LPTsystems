using System;
using System.Collections.Generic;

namespace LPT.Models
{
    public partial class DadoColetado
    {
        public int IdDadoColetado { get; set; }
        public int Experimento { get; set; }
        public double ValorLido { get; set; }
        public DateTime ColetadoEm { get; set; }
        public int TipoDeGrandeza { get; set; }
        public string Hwid { get; set; }

        public virtual Experimento ExperimentoNavigation { get; set; }
        public virtual Grandeza TipoDeGrandezaNavigation { get; set; }
    }
}
