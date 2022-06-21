using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using J_uan.DAL;
using J_uan.Models;
using J_uan.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace J_uan.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AccountController : Controller
    {
        private AppDbContext _context { get; }
        private IEnumerable<AppUser> users;
        public AccountController(AppDbContext context)
        {
            _context = context;
            users = _context.Users.ToList();
        }
        public IActionResult Index()
        {
            return View(users);
        }
    }
}
