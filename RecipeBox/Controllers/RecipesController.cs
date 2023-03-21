using System.Net.Mail;
using System.Reflection.PortableExecutable;
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
        .Include(recipe => recipe.JoinEntities)
        .ThenInclude(recipe => recipe.Tag)
        .FirstOrDefault(recipe => recipe.RecipeId == id);

      return View(targetRecipe);
    }

    public ActionResult Edit(int id)
    {
      Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);

    }

    [HttpPost]
    public ActionResult Edit(Recipe recipe)
    {
      _db.Recipes.Update(recipe);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTag(int id)
    {
        Recipe thisRecipe = _db.Recipes.FirstOrDefault(recipes => recipes.RecipeId == id);
        ViewBag.TagId = new SelectList(_db.Tags, "TagId", "TagName");
        return View(thisRecipe);
    }

    [HttpPost]
    public ActionResult AddTag (Recipe recipe,int tagId)
    {
    #nullable enable
        RecipeTag? joinEntity = _db.RecipeTags.FirstOrDefault(join => (join.TagId == tagId && join.RecipeId == recipe.RecipeId));
    #nullable disable
        if(joinEntity == null && tagId != 0)
        {
            _db.RecipeTags.Add(new RecipeTag() {TagId = tagId, RecipeId = recipe.RecipeId});
            _db.SaveChanges();
        }  
        return RedirectToAction("Details", new { id = recipe.RecipeId});

        }




    }
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
  
