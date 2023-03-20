namespace RecipeBox.Models
{
  public class Instruction
  {
    public int InstructionId { get; set; }
    public string Instructions { get; set; }
    public Recipe Recipe { get; set; }
    public int RecipeId { get; set; }
  }
}