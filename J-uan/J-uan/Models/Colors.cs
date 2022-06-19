using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace J_uan.Models
{
    public class Colors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductColors> ProductColors { get; set; }
    }
}
