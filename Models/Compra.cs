using ProAspNetCoreMvcValidation.Util.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProAspNetCoreMvcValidation.Models
{
    public class Compra
    {

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [Range(typeof(bool), "true", "true",ErrorMessage = "Informe se o número tem WhatsApp")]
        public bool NumeroComWhatsApp { get; set; }

        [Range(minimum:5,maximum:10,ErrorMessage ="Valor mínimo 5 e máximo 8")]
        public int Quantidade { get; set; }

        [StringLength(10)]
        public string Mensagem { get; set; }

        [MustBeTrue(ErrorMessage = "Você aceitar os termos de entraga")]
        public bool TermosEntrega { get; set; }
    }
}
