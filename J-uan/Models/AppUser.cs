using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace J_uan.Models
{
        public class AppUser : IdentityUser
        {
            public string Fullname { get; set; }
            public bool IsActivated { get; set; }
        }
    
}
