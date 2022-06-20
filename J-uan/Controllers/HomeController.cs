using J_uan.DAL;
using J_uan.Models;
using J_uan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace J_uan.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel home = new HomeViewModel
            {
                Slides = _context.Slides.ToList(),
                Features = _context.Features.ToList(),
                Categories = _context.Categories.Where(c => !c.IsDeleted)
                .Include(pc => pc.ProductsCategories).ThenInclude(ct => ct.Product).ToList(),
                Products = _context.Products.Where(p => !p.IsDeleted).Include(p => p.Images).ToList(),
                Images = _context.ProductImages.ToList(),
                Blogs = _context.Blogs.ToList(),
                Brands = _context.Brands.ToList()
            };

            return View(home);
        }
    }
}

