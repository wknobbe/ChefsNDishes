using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context {get;set;}
        public HomeController(MyContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> chefsInDb = _context.Chefs.Include(c => c.MyDishes).ToList();
            return View(chefsInDb);
        }
        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> dishesInDb = _context.Dishes.Include(c => c.Cook).ToList();
            return View(dishesInDb);
        }
        [HttpGet("newchef")]
        public IActionResult AddChef()
        {
            return View();
        }
        [HttpPost("createchef")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                _context.Chefs.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddChef");
            }
        }
        [HttpGet("dishes/new")]
        public IActionResult AddDish()
        {
            ViewBag.Chefs = _context.Chefs.ToList();
            return View();
        }
        [HttpPost("dishes/newdish")]
        public IActionResult CreateDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _context.Dishes.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                ViewBag.Chefs = _context.Chefs.ToList();
                return View("AddDish");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
