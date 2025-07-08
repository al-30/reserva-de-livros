using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivro.API.Models
{
    public class ControleEmprestimoLivroContext : DbContext
    {
        public ControleEmprestimoLivroContext()
        {
        }

        public ControleEmprestimoLivroContext(DbContextOptions<ControleEmprestimoLivroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Livro> Livro { get; set; }
        public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);
                entity.Property(e => e.Numero).IsUnicode(false);
                entity.Property(e => e.CPF).IsUnicode(false);
                entity.Property(e => e.Endereco).IsUnicode(false);
                entity.Property(e => e.Bairro).IsUnicode(false);
                entity.Property(e => e.Cidade).IsUnicode(false);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.Property(e => e.LivroAutor).IsUnicode(false);
                entity.Property(e => e.LivroEdicao).IsUnicode(false);
                entity.Property(e => e.LivroEditora).IsUnicode(false);
                entity.Property(e => e.LivroName).IsUnicode(false);
            });

            modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
            {
                entity.HasOne(d => d.LceIdClienteNavigation)
                    .WithMany(p => p.LivroClienteEmprestimo)
                    .HasForeignKey(d => d.LceIdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LIVRO_EMPRESTIMO_CLIENTE");

                entity.HasOne(d => d.LceIdLivroNavigation)
                    .WithMany(p => p.LivroClienteEmprestimo)
                    .HasForeignKey(d => d.LceIdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GK_LIVRO_CLIENTE_EMPRESTIMO_LIVRO");
            });

         }
    }
}
