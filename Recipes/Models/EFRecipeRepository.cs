using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;


namespace Recipes.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EFRecipeRepository(ApplicationDbContext ctx, IHttpContextAccessor httpContextAccessor)
        {
            context = ctx;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;
        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeID == 0)
            {
                context.Recipes.Add(recipe);
            }
            else
            {
                Recipe recipeEntry = context.Recipes.FirstOrDefault(p => p.RecipeID == recipe.RecipeID);
                if(recipeEntry != null)
                {
                    recipeEntry.Name = recipe.Name;
                    recipeEntry.Category = recipe.Category;
                    recipeEntry.Ingredients = recipe.Ingredients;
                    recipeEntry.Instruction = recipe.Instruction;
                }
            }
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            recipe.UserId = userId;
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeID)
        {
            Recipe recipeEntry = context.Recipes.FirstOrDefault(p => p.RecipeID == recipeID);

            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }
            return recipeEntry;
        }
    }
}
