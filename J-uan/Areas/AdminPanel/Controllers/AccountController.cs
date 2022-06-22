using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using J_uan.DAL;
using J_uan.Models;
using J_uan.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace J_uan.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AccountController : Controller
    {
        private AppDbContext _context { get; }
        private UserManager<AppUser> _user;
        public AccountController(AppDbContext context, UserManager<AppUser> user)
        {
            _context = context;
            _user = user;
        }
        public IActionResult Index()
        {
            return View(_user);
        }
    }
}
