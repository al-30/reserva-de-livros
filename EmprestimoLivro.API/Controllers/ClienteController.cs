using AutoMapper;
using EmprestimoLivro.API.DTOs;
using EmprestimoLivro.API.Interface;
using EmprestimoLivro.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepositoty, IMapper mappper)
        {
            _clienteRepository = clienteRepositoty;
            _mapper = mappper;
        }

        [HttpGet("selecionartodos")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.SelecionarTodos();
            var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok(clientesDTO);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarCliente(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Incluir(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso");
            }
            return BadRequest("Ocorreu um erro ao salvar o cliente");
        }
        [HttpPut("atualizarCadastro/{id}")]
        public async Task<ActionResult> AlterarCliente(ClienteDTO clienteDTO, int id)
        {
            if(id== 0)
            {
                return BadRequest("Informe o Id do usuario");
            }

            var clienteExiste= await _clienteRepository.SelecionarbyPk(id);
            if (clienteExiste== null)
            {
                return NotFound("Usuario nao encontrado");
            }

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Alterar(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente alterado com sucesso");
            }
            return BadRequest("Ocorreu um erro ao alterar o cliente");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            if (id == null)
            {
                return NotFound("Cliente não encontrado");
            }

            var cliente = await _clienteRepository.SelecionarbyPk(id);
            _clienteRepository.Excluir(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente excluido com sucesso");
            }
            return BadRequest("Ocorreu um erro ao excluir o cliente");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> SelecionarCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarbyPk(id);

            if (cliente == null)
            {
                return BadRequest("Cliente nao encontrado");
            }

            ClienteDTO clienteDTO = new ClienteDTO
            {
                Nome = cliente.Nome,
                Celular = cliente.Celular,
                CPF = cliente.CPF,
                Endereco = cliente.Endereco,
                Numero = cliente.Numero,
                Bairro = cliente.Bairro,
                Cidade = cliente.Cidade,

            };

            return Ok(clienteDTO);
        }
    }
}