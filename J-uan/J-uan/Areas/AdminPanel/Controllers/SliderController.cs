using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using J_uan.DAL;
using J_uan.Models;
using Microsoft.AspNetCore.Mvc;

namespace J_uan.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }
        private IEnumerable<Slider> Slides;
        public SliderController(AppDbContext context)
        {
            _context = context;
            Slides = _context.Slides;
        }
        public IActionResult Index()
        {
            return View(Slides);
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
