using GuardPRO.API7.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuardPRO.API7.Controllers;
public class InviteController : Controller
{
    private GuardDbContext _context { get; set; }

    public InviteController(GuardDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _context.Invites
            .Include(x => x.User)
            .ToArrayAsync();

        return View(data);
    }
}