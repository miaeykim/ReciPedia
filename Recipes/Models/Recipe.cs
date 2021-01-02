using Recipes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        [Required(ErrorMessage = "Please enter recipe name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select category.")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter ingredients.")]
        public string Ingredients { get; set; }
        [Required(ErrorMessage = "Please enter instruction.")]
        public string Instruction { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
{
    public virtual Recipe Recipe { get; set; }
}