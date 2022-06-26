using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace J_uan.ViewModels.Sliders
{
    public class SliderViewModel
    {
        [Required]
        public IFormFile Photo { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
    }
}
