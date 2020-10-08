using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Data;
using ShopJoin.API.Dtos;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace ShopJoin.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class DoacaoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly DoacaoRepository _repo;
        public DoacaoController(DoacaoRepository repo, DataContext context)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetDoacoesCliente(int id)
        {
            var data = await _context.doacoes.Where(x => x.User.Id == id).ToListAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoacao(int id)
        {
            var data = await _context.produtosResgatados.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(data);
        }

        [HttpPut("mudarStatus/{id}")]
        public async Task<IActionResult> MudarStatusDoacao(int idDoacao)
        {
            try
            {
                var doacao = await _repo.AlterarStatus(idDoacao);

                return Ok(doacao);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarDoacao(DoacaoCadastroDto doacaoDto)
        {
            try
            {
                var doacao = await _repo.CadastrarDoacao(doacaoDto);

                return Ok(doacao);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }

}