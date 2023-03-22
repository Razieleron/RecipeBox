using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace RecipeBox.Models
{
  public class Tag
  {
    public int TagId { get; set; }
   [Required(ErrorMessage = "The recipe's description can't be empty!")]

    public string TagName { get; set; }
    [Required(ErrorMessage = "The recipe's description can't be empty!")]

    public List<RecipeTag> JoinEntities { get; set; }

  }
}