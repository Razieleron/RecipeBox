using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RecipeBox.Models;

namespace RecipeBox.Controllers
{
    public class TagsController : Controller
    {
      private readonly RecipeBoxContext _db;

      public TagsController(RecipeBoxContext db)
      {
          _db = db;
      }
      
      public ActionResult Index()
      {
          return View(_db.Tags.ToList());
      }

      public ActionResult Create()
      {
          return View();
      }

      [HttpPost]
      public ActionResult Create(Tag tag)
      {
          _db.Tags.Add(tag);
          _db.SaveChanges();
          return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        Tag thisTag = _db.Tags
            .Include(fish => fish.JoinEntities)
            .ThenInclude(fish => fish.Recipe)
            .FirstOrDefault(tag => tag.TagId == id);
            return View(thisTag);
      }

        public ActionResult Edit(int id)
        {
            Tag thisTag = _db.Tags.FirstOrDefault(tag => tag.TagId == id);
            ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "RecipeName");
            return View(thisTag);
            
        }

        [HttpPost]
      public ActionResult Edit (Tag tag)
      {
        _db.Tags.Update(tag);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

    }
}