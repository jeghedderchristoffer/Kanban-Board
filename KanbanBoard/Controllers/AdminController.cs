using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KanbanBoard.Models.AdminViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using KanbanBoard.Models;

namespace KanbanBoard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.Roles = new List<IdentityRole>();

            foreach (var role in _roleManager.Roles)
            {
                model.Roles.Add(role);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(IndexViewModel model)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(model.RoleName));

            if (result.Succeeded)
            {      
                return RedirectToAction(nameof(Index), new { Message = "Sucess!!" });
            }

            return RedirectToAction(nameof(Index), new { Message = "Failed!!" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string name)
        {
            var roleName = await _roleManager.FindByNameAsync(name);
            var result = await _roleManager.DeleteAsync(roleName);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index), new { Message = "Sucess!!" });
            }

            return RedirectToAction(nameof(Index), new { Message = "Failed!!" });
        }

    }
}