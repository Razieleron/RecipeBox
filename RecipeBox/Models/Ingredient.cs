using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Ingredient
  {
    public int IngredientId { get; set; }
    public string IngredientName { get; set; }
    public int IngredientQty { get; set;}

    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    // Recipe.Tags or whatever
    // ingredient dictionary - [{tomato:1, cough drops: 3, dirt:69}]
  }
}