using GuardPRO.API7.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuardPRO.API7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutorizeController : ControllerBase
{
    private GuardDbContext _context { get; set; }

    public AutorizeController(GuardDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Login(int number)
    {
        var applicant = await _context.Applicants.FirstOrDefaultAsync(x => x.Number == number);
        if (applicant == null)
            return NotFound();

        return Ok(applicant);
    }
}
