using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Data;

namespace ShopJoin.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var data = await _context.users.ToListAsync();

            return Ok(data);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]

        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.users.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value); 
        }

    }

}