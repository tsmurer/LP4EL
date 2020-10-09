using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Data;

namespace ShopJoin.API.Controllers
{
    // [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProdutoResgateController : ControllerBase
    {
        private readonly IProdutoResgateRepository _repo;
        public ProdutoResgateController(IProdutoResgateRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetProdutosResgatadosCliente(int id)
        {
            var data = await _repo.GetProdutosResgatadosCliente(id);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutosResgatado(int id)
        {
            var data = await _repo.GetProdutosResgatado(id);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> ResgatarProduto(int idProduto, int idUsuario)
        {
            try
            {
                await _repo.ResgatarProduto(idProduto, idUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}