using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Models
{
    public class ApplicationUser : User
    {
        [StringLength(100, MinimumLength=5)]
        public string Email { get; set; }
    }
}
