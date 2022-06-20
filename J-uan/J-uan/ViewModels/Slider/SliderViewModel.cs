using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace J_uan.ViewModels.Sliders
{
    public class SliderViewModel
    {
        [Required]
        public string Image { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
