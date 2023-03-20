using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RecipeBox.Models;

namespace RecipeBox.Controllers
{
    public class TagsController : Controllers
    {
        private readonly TagsController _dbs;

        public TagsController(RecipeBoxContext db)
        {
            _dbs = db;
        }
        
        public ActionResult Index()
        {
            return View (_dbs.Tags.ToList());
        }

        public ActionResult Create()
  
  
  
  
  
    }
}