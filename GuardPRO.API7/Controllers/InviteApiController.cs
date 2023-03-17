using GuardPRO.API7.Database;
using GuardPRO.API7.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace GuardPRO.API7.Controllers;

[ApiController]
[Route("api/invite")]
public class InviteApiController : ControllerBase
{
    private GuardDbContext _context { get; set; }

    public InviteApiController(GuardDbContext context)
    {
        _context = context;
    }

    [Route("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var invite = await _context.Invites.FirstOrDefaultAsync(x => x.Id == id);
            return NotFound();

        return Ok(invite);
    }

    public async Task<List<Invite>> GetAll()
    {
        var invite = await _context.Invites
            .AsNoTracking()
            .Include(x => x.Applicant)
            .Include(x => x.User)
            .Include(x => x.Group)
            .ToListAsync();

        invite.ForEach(x => x.Applicant.Invites = null);
        invite.ForEach(x =>
        {
            if (x.Group != null)
                x.Group.Users = null;
        });

        return invite;
    }
}
