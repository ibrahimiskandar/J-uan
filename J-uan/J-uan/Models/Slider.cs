using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace J_uan.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Subtitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [NotMapped, Required]
        public IFormFile Photo { get; set; }
    }
}
