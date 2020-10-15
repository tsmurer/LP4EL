using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopJoin.API.Data;
using ShopJoin.API.Dtos;


namespace ShopJoin.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoacaoController : ControllerBase
    {

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
        private readonly IDoacaoRepository _repo;
        public DoacaoController(IDoacaoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("usuarioDoacao/{id}")]
        public async Task<IActionResult> GetDoacoesCliente(int id)
        {
            var data = await _repo.GetDoacoesCliente(id);

            return Ok(data);
        }

        [HttpGet("hospitalDoacao/{id}")]
        public async Task<IActionResult> GetDoacoesHospital(int id)
        {
            var data = await _repo.GetDoacoesHospital(id);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoacao(int id)
        {
            var data = await _repo.GetDoacao(id);
            return Ok(data);
        }

        [HttpPut("mudarStatus/{idDoacao}/{idHospital}")]
        public async Task<IActionResult> MudarStatusDoacao(int idDoacao, int idHospital)
        {
            try
            {
                var doacao = await _repo.AlterarStatus(idDoacao, idHospital);

                return Ok(doacao);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

        }


    }

}