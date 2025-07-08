using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivro.API.Models
{
    public class Livro
    {
        public Livro()
        {
            LivroClienteEmprestimo = new HashSet<LivroClienteEmprestimo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LivroName { get; set; }

        [Required]
        [StringLength(200)]
        public string LivroAutor { get; set; }

        [Required]
        [StringLength(100)]
        public string LivroEditora{ get; set; }

        public DateTime LivroAnoPublicacao { get; set; }

        [Required]
        [StringLength(50)]
        public string LivroEdicao { get; set; }

        [InverseProperty("LceIdLivroNavigation")]

        public virtual ICollection<LivroClienteEmprestimo> LivroClienteEmprestimo { get; set; }
    }
}
