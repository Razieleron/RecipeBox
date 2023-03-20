using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    public string RecipeName { get; set; }
    public int RecipeRating { get; set; }
    public Tag Tags { get; set; }
    public List<RecipeTag> JoinEntities { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    
    // public Dictionary<Ingredient, Ingredient.IngredientQty> IngredientTypeAndQty { get; set; } 
    
    // foreach item in IngredientTypeAndQty
    // {(ingredient[0], ingredientqty[0])}
  }
}