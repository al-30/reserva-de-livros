using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivro.API.Models
{
    public class LivroClienteEmprestimo
    {

        [Key]
        public int Id { get; set; }
        public int LceIdCliente { get; set; }
        public int LceIdLivro { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime LceDataEmprestimo { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime LceDataEntrega { get; set; }

        public bool LceEntregue { get; set; }

        [ForeignKey(nameof(LceIdCliente))]
        [InverseProperty(nameof(Cliente.LivroClienteEmprestimo))]
        public virtual Cliente LceIdClienteNavigation { get; set; }

        [ForeignKey(nameof(LceIdLivro))]
        [InverseProperty(nameof(Livro.LivroClienteEmprestimo))]
    public virtual Livro LceIdLivroNavigation { get; set; }
    }
}
