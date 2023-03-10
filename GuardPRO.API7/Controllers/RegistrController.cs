using GuardPRO.API7.Database;
using GuardPRO.API7.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GuardPRO.API7.Controllers;

public class RegisterViewModel
{
    public bool IsSessuful { get; set; }
    public string ErrorMessage { get; set; }
}

public class RegistrController : Controller
{
    private GuardDbContext _context { get; set; }

    public RegistrController(GuardDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(new RegisterViewModel { IsSessuful = true});
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromForm] RegistrFormData formData)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == formData.UserLogin);
        if (user != null)
            return View(new RegisterViewModel { IsSessuful = false, ErrorMessage = "Такой пользователь уже существует"});

        using var hasher = MD5.Create();
        var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(formData.UserPassword));

        await _context.Users.AddAsync(new User
        {
            Sername = "",
            Name = formData.UserName,
            Patronic = "",
            Telephone = "",
            DateOfBird = formData.UserBird,
            SerialPassport = "",
            NumberPassport = "",
            Login = formData.UserLogin,
            Email = formData.UserEmail,
            Password = Convert.ToHexString(hash)
        });

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(LoginController.Index), nameof(LoginController));
    }
}

public class RegistrFormData
{
    public string UserEmail { get; set; }
    public string UserLogin { get; set; }
    public string UserPassword { get; set; }
    public DateTime UserBird { get; set; }
    public string UserName { get; set; }
}