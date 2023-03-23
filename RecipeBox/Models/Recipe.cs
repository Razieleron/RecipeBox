using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace RecipeBox.Models;

  public class Recipe
  {
    public int RecipeId { get; set; }
    [Required(ErrorMessage = "The recipe's description can't be empty!")]
    public string RecipeName { get; set; }
    [Required(ErrorMessage = "The recipe's Name can't be empty!")]

    public string RecipeIngredients { get; set;}
    public string RecipeInstructions { get; set;}
    
    public int RecipeRating { get; set; }
    public Tag Tag { get; set; }
    public List<RecipeTag> JoinEntities { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public ApplicationUser User { get; set; 

    
    // public Dictionary<Ingredient, Ingredient.IngredientQty> IngredientTypeAndQty { get; set; } 
    
    // foreach item in IngredientTypeAndQty
    // {(ingredient[0], ingredientqty[0])}
  }
}