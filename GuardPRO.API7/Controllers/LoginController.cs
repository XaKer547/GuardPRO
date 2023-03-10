using GuardPRO.API7.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GuardPRO.API7.Controllers;
public class LoginViewModel
{
    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email не введен.")]
    public string Email { get; set; }

    [Display(Name = "Пароль")]
    [Required(ErrorMessage = "Пароль не введен.")]
    public string Password { get; set; }
}

public class LoginController : Controller
{
    private readonly GuardDbContext _context;

    public LoginController(GuardDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromForm] LoginViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        using var hasher = MD5.Create();
        var hash = Convert.ToHexString(hasher.ComputeHash(Encoding.UTF8.GetBytes(viewModel.Password)));

        var user = _context.Users
            .Where(x => x.Email == viewModel.Email && x.Password == hash)
            .FirstOrDefault();

        if (user == null)
        {
            ModelState.AddModelError(nameof(LoginViewModel.Email), "Email или пароль не верный");
            return View(viewModel);
        }

        var claims = new Claim[]
        {
            new(ClaimsIdentity.DefaultNameClaimType, user.Email)
        };
        var claimsId = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsId));

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}