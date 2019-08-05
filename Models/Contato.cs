using System.ComponentModel.DataAnnotations;

namespace ProAspNetCoreMvcValidation.Models
{
    public class Contato
    {
        [Required]
        [StringLength(maximumLength: 10 , MinimumLength = 5)]
        public string Nome { get; set; }
    }
}
