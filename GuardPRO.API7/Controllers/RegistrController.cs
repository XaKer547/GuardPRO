using GuardPRO.API7.Database;
using GuardPRO.API7.Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GuardPRO.API7.Controllers;

public class RegistrController : Controller
{
    private GuardDbContext _context { get; set; }

    public RegistrController(GuardDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromForm] RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var userExists = await _context.Users.AnyAsync(x => x.Login == model.UserLogin);
        if (userExists)
        {
            ModelState.AddModelError(nameof(model.UserLogin), "Такой логин уже занят!");
            return View(model);
        }

        using var hasher = MD5.Create();
        var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(model.UserPassword));

        await _context.Users.AddAsync(new User
        {
            Sername = "",
            Name = model.UserName,
            Patronic = "",
            Telephone = "",
            DateOfBird = model.UserBird,
            SerialPassport = "",
            NumberPassport = "",
            Login = model.UserLogin,
            Email = model.UserEmail,
            Password = Convert.ToHexString(hash)
        });

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(SuccessRegistration));
    }

    public IActionResult SuccessRegistration()
    {
        return View();
    }
}

public class RegisterViewModel
{
    [Display(Name = "Email")]
    [Required]
    [EmailAddress]
    public string UserEmail { get; set; }

    [Display(Name = "Логин")]
    [Required(ErrorMessage = "Требуется указать логин")]
    public string UserLogin { get; set; }

    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "Требуется указать пароль")]
    [PasswordPropertyText]
    public string UserPassword { get; set; }

    [Display(Name = "Дата рождения")]
    [Required(ErrorMessage = "Требуется указать дату рождения")]
    public DateTime UserBird { get; set; }

    [Display(Name = "Имя пользователя")]
    [Required(ErrorMessage = "Требуется указать имя пользователя")]
    public string UserName { get; set; }
}