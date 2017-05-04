using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoard.Models.AdminViewModels
{
    public class IndexViewModel
    {
        [Required(ErrorMessage = "You have to write a role name")]
        public string RoleName { get; set; }

        public List<IdentityRole> Roles { get; set; } 
    }
}
