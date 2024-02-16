using System.Collections.Generic;

namespace Candy.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<FlavorTreat> JoinEntities { get; set; }
  }
}