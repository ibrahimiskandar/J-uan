using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using J_uan.DAL;
using J_uan.Helpers;
using J_uan.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace J_uan.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment _env { get; }
        private IEnumerable<Slider> Slides;
        public SliderController(AppDbContext context,IEnumerable<Slider>slides, IWebHostEnvironment env)
        {
            _context = context;
            Slides = _context.Slides;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(Slides);
        }
        public IActionResult Create()
        {
            return View();
        }
      

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(Slider slide)
        {

            slide.Image = await slide.Photo.SaveFileAsync(_env.WebRootPath, "img");
            await _context.Slides.AddAsync(slide);
                   await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                
                return View(Slides);

            
            
        }
    }
}
