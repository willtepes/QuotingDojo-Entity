using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using quotingdojo3.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using quotingdojo3.Models;
using Microsoft.EntityFrameworkCore;

namespace quotingdojo3.Controllers
{
    public class QuoteController : Controller
    {
        private Quotingdojo3Context _context;
        public QuoteController(Quotingdojo3Context context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("addquote")]
        public IActionResult Addquote()
        {
            if(HttpContext.Session.GetInt32("id")!=null){
                 User login = _context.Users.SingleOrDefault(item => item.id == (int)HttpContext.Session.GetInt32("id"));
                 ViewBag.first_name = login.first_name;
                 ViewBag.last_name = login.last_name;
                 return View("addquote");
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [Route("quotes")]
        public IActionResult Quotes(Registerquote model)
        {
            if(ModelState.IsValid)
            {
                Quote quote = new Quote 
                {
                    quote = model.quote,
                    userid = (int)HttpContext.Session.GetInt32("id"),
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                _context.Quotes.Add(quote);
                _context.SaveChanges();
                return RedirectToAction("Allquotes");
            }
            return View("addquote",model);

        }
        [HttpGet]
        [Route("allquotes")]
        public IActionResult Allquotes()
        {
            if(HttpContext.Session.GetInt32("id")!=null)
            {
                List<Quote> Quotes = _context.Quotes.Include(quote => quote.user).ToList();
                ViewBag.UserId = (int)HttpContext.Session.GetInt32("id");
                return View(_context.Quotes.Include(quote => quote.user).OrderByDescending(quote => quote.created_at).ToList());
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        [Route("delete/{parameter}")]
        public IActionResult Delete(int parameter)
        {
             Quote quote = _context.Quotes.SingleOrDefault(item => item.id == parameter);
             _context.Quotes.Remove(quote);
             _context.SaveChanges();
             return RedirectToAction("Allquotes");
        }

    }
}
       