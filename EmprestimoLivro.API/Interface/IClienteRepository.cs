using EmprestimoLivro.API.Models;
using System.Data.SqlTypes;

namespace EmprestimoLivro.API.Interface
{
    public interface IClienteRepository
    {
        void Incluir(Cliente cliente);
        void Alterar(Cliente cliente);
        void Excluir(Cliente cliente);
        Task<Cliente> SelecionarbyPk(int id);
        Task<IEnumerable<Cliente>> SelecionarTodos();
        Task<bool> SaveAllAsync();
    }
}
