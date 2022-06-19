using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using J_uan.DAL;
using Microsoft.AspNetCore.Mvc;

namespace J_uan.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Slides);
        }
    }
}
