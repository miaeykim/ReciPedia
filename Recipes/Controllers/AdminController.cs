using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Recipes.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private IRecipeRepository repository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public int PageSize = 5;

        public AdminController(UserManager<IdentityUser> userMgr, IRecipeRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            userManager = userMgr;
            repository = repo;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ActionResult> Index(int recipePage = 1)
        {
            var recipes = from r in repository.Recipes select r;

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            IdentityUser user = await userManager.GetUserAsync(User);
            
            return View(new RecipeListViewModel
            {
                Recipes = recipes
                        .Where(r => r.UserId == userId)
                        .OrderBy(r => r.Name)
                        .Skip((recipePage - 1) * PageSize)
                        .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = recipePage,
                    ItemsPerPage = PageSize,
                    TotalItems = recipes.Where(r => r.UserId == userId).Count()
                }
            });
        }

        public ViewResult AddRecipe() => View("EditRecipe", new Recipe());

        [HttpPost]
        public IActionResult DeleteRecipe(int RecipeID)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(RecipeID);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} is deleted";
            }

            return RedirectToAction("Index");
        }
        public ViewResult EditRecipe(int RecipeID)
        {
            return View(repository.Recipes.FirstOrDefault(x => x.RecipeID == RecipeID));
        }

        [HttpPost]
        public IActionResult EditRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(recipe);
            }
        } 
    }
}