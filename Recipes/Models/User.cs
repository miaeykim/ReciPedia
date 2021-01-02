using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}