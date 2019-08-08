using System;

namespace ProAspNetCoreMvcValidation.Models
{
    public class Compromisso
    {
        public string NomeCliente { get; set; }
        public DateTime Data { get; set; }
        public bool AceitaTermos { get; set; }
    }
}
