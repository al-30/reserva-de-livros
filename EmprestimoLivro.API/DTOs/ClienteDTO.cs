using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivro.API.DTOs
{
    public class ClienteDTO
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
       
        [Required]
        [StringLength(14)]
        public string CPF { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(50)]
        public string Numero { get; set; }

        [Required]
        [StringLength(14)]
        public string Celular { get; set; }
    }
}
