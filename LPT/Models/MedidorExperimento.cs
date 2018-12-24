using System;
using System.Collections.Generic;

namespace LPT.Models
{
    public partial class MedidorExperimento
    {
        public int IdMedidorExperimento { get; set; }
        public string Medidor { get; set; }
        public int? Experimento { get; set; }

        public virtual Experimento ExperimentoNavigation { get; set; }
    }
}
