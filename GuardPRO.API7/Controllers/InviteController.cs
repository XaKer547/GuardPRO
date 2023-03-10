using GuardPRO.API7.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GuardPRO.API7.Controllers;
public class InviteController : Controller
{
    private GuardDbContext _context { get; set; }

    public InviteController(GuardDbContext context)
    {
        _context = context;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var email = User.Identity.Name;

        var data = await _context.Invites
            .Include(x => x.User)
            .Where(x => x.User.Email == email)
            .ToArrayAsync();

        return View(data);
    }
}