using System.Collections.Generic;

namespace Candy.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<FlavorTreat> JoinEntities { get; set; }
  }
}