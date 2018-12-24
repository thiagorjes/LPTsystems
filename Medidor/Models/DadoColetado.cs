using System;

namespace Medidor.Models
{
    public class DadoColetado
    {
        public int IdDadoColetado { get; set; }
        public int Experimento { get; set; }
        public double ValorLido { get; set; }
        public DateTime ColetadoEm { get; set; }
        public int TipoDeGrandeza { get; set; }
        public string Hwid { get; set; }
    }
}