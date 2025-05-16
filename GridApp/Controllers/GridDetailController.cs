using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GridApp.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridDetailController : ControllerBase
    {
        private readonly PalkDbContext _context;

        public GridDetailController(PalkDbContext context,IConfiguration configuration)
        {
            _context = context;
           

        }
        
        [HttpGet("AllData")]
        public async Task<IActionResult> GetGridDetails()
        {
            return Ok(await _context.GridDetails.ToListAsync());
        }

        
        [HttpGet("Top100Data")]
        public async Task<ActionResult<IQueryable<GridDetail>>> GetTop100Users()
        {
            var top100 = await _context.GridDetails.Take(100).ToListAsync();
            if (top100 == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(top100);
            }
        }

        
        [HttpGet("SAData")]
        public async Task<ActionResult<IQueryable<GridDetail>>> GetSouthAfricaUsers()
        {
            var SaUsers = await _context.GridDetails.Where(a=>a.Country =="South Africa").ToListAsync();
            if (SaUsers == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(SaUsers);
            }
        }
    }
}
