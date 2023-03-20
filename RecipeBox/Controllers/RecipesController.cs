using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using RecipeBox.Models;

namespace RecipeBox.Controllers
{
    public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;
    public RecipesController(RecipeBoxContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
        return View(_db.Recipes.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Recipe recipe)
    {
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Recipe targetRecipe = _db.Recipes
                              .Include(recipe => recipe.Tags)
                              .FirstOrDefault(recipe => recipe.RecipeId == id);
      
      return View(targetRecipe);
    }

    // public ActionResult Details(int id)
    // {
    //   Recipe thisRecipe = _db.Recipes
    //                           .Include(fish => fish.JoinEntities)
    //                           .Include(fish => fish.Tag)
    //                           .ThenInclude(join =>join.TagId)
    //                           .FirstOrDefault(fish => fish.TagId == id);
    //   return View(thisRecipe);
    // }
  }
}