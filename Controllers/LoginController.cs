using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingdojo3.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;


namespace quotingdojo3.Controllers
{
    public class LoginController : Controller
    {
        private Quotingdojo3Context _context;
        public LoginController(Quotingdojo3Context context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                User ReturnedValue = _context.Users.SingleOrDefault(item => item.email == model.email);
                if(ReturnedValue != null)
                {
                
                    ViewBag.ManualError = "This email is already registered";
                    return View("Index");
                }
                User user = new User
                {
                    first_name = model.first_name,
                    last_name = model.last_name,
                    email = model.email,
                    password = model.password,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now

                };
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.password = Hasher.HashPassword(user, user.password);
                _context.Users.Add(user);
                _context.SaveChanges();
                User loggedin = _context.Users.SingleOrDefault(item => item.email == user.email);
                HttpContext.Session.SetInt32("id", (int)loggedin.id);
                return RedirectToAction("addquote", "Quote");
            }
            return View("Index",model);
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string login_email, string login_password)
        {
            User check = _context.Users.SingleOrDefault(item => item.email == login_email);
            if(check != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(check, check.password, login_password))
                {
                    HttpContext.Session.SetInt32("id", (int)check.id);
                    return RedirectToAction("addquote", "Quote");
                }
            }
            ViewBag.ManualError = "Email or Password not found";
            return View("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
