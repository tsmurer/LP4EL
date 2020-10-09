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
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;
        public ProdutoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> GetProdutos()
        {
            var data = await _context.produtos.ToListAsync();

            return Ok(data);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            var value = await _context.users.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }
    }
}