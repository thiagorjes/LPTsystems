using System;
using System.Collections.Generic;

namespace LPT.Models
{
    public partial class Grandeza
    {
        public Grandeza()
        {
            DadoColetado = new HashSet<DadoColetado>();
        }

        public int IdGrandeza { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<DadoColetado> DadoColetado { get; set; }
    }
}
