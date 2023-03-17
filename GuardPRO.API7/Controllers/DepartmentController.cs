using GuardPRO.API7.Database;
using GuardPRO.API7.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GuardPRO.API7.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private GuardDbContext _context { get; set; }

    public DepartmentController(GuardDbContext context)
    {
        _context = context;
    }

    public List<Department> Get()
    {
        return _context.Departments.ToList();
    }
}
