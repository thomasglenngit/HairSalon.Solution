using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Client
  {
    public Client()
    {
      this.Reviews = new HashSet<Review>();
    }
    public int ClientId { get; set; }
    public int StylistId { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public virtual Stylist Stylist { get; set; }
    
    // public virtual ICollection<Review> Reviews { get; set; }
  }
}