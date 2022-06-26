using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using J_uan.DAL;
using J_uan.Helpers;
using J_uan.Models;
using J_uan.ViewModels.Sliders;
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
        public async Task<IActionResult> Create(Slider slide)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(slide);

                Slider slider = new Slider
                {
                    Image = uniqueFileName,
                    Title = slide.Title,
                    Subtitle = slide.Subtitle,
                    Description = slide.Description,


                };
                _context.Slides.Add(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        private string UploadedFile(Slider slide)
        {
            string uniqueFileName = null;

            if (slide.Photo != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "img/slider");


                uniqueFileName = Guid.NewGuid().ToString() + slide.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    slide.Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task UpdateSlider( int id, string img, string title, string subtitle)
        {
            Slider slider = await _context.Slides.FindAsync(id);

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/slider/", slider.Image);

            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }

            slider.Image = img;
            slider.Title = title;
            slider.Subtitle = subtitle;

            await _context.SaveChangesAsync();
        }

        public IActionResult EditSlider(int id)
        {
            Slider slider =  _context.Slides.FirstOrDefault(slider => slider.Id == id);

            SliderViewModel viewModel = new SliderViewModel()
            {
                Title = slider.Title,
                Subtitle=slider.Subtitle,
                Description=slider.Description,
                Photo=slider.Photo
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SliderViewModel viewModel, int id)
        {
            if (ModelState.IsValid)
            {
                Slider slider =  _context.Slides.FirstOrDefault(slider => slider.Id == id); 

                string sliderImg = slider.Image;
                string uniqueFileName = null;

                if (viewModel.Photo != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "img/slider");


                uniqueFileName = Guid.NewGuid().ToString() + viewModel.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Photo.CopyTo(fileStream);
                }

                    sliderImg = uniqueFileName;
                }

                await UpdateSlider(id, sliderImg, viewModel.Title, viewModel.Subtitle);

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }
    }
}
