using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using WebApplication_MVC.Models;

namespace WebApplication_MVC.Controllers
{
    public class AuthController : Controller
    {

        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult LoginIn()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> LoginIn(LoginViewModel Lvm)
        {
            var usuarios = _context.Usuarios.ToList();
            if (usuarios.Count == 0)
            {
                var U = new Usuario();
                U.Name = "Administrador";
                U.Email = "Admin@admin.com";
                U.Username = "admin";
                U.Rol = "SuperAdministrador";
                CreatePasswordHash("admin", out byte[] passwordHash, out byte[] passwordSalt);
                U.PasswordHash = passwordHash;
                U.PasswordSalt = passwordSalt;

                _context.Usuarios.Add(U);
                _context.SaveChanges();
            }

            //user=pedrito pass=123

            var us = _context.Usuarios
                .Where(u => u.Username.Equals(Lvm.Username)).FirstOrDefault();

            if (us != null)
            {
                //pedrito existe en la base de datos
                if (VerificarPass(Lvm.Password, us.PasswordHash, us.PasswordSalt))
                {
                    //Login Correcto

                    //Crear credenciales

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, us.UsuarioId.ToString()),
                        new Claim(ClaimTypes.Name, us.Name),
                        new Claim(ClaimTypes.Role, us.Rol)
                    };

                    var identity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    //Login In
                    await HttpContext
                        .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    //password mala
                    ModelState.AddModelError("", "Contraseña Incorrecta!!!");
                    return View(Lvm);
                }
            }
            else
            {
                ModelState.AddModelError("", "Usuario no existe!!!");
                return View(Lvm);
            }


        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(LoginIn));
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //administrador 123456
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerificarPass(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var pass = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return pass.SequenceEqual(passwordHash);
            }
        }
    }
}
