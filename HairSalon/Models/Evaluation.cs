namespace HairSalon.Models
{
  public class Evaluation
  {
    public int EvaluationId { get; set; }
    public int StylistId { get; set; }
    public string Rank { get; set; }
    public string Text { get; set; }
    public virtual Stylist Stylist { get; set; }
  }
}