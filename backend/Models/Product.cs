using System.Collections.Generic;

namespace backend.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public virtual IEnumerable<Image> Images { get; set; }
    public int? CategoryId { get; set; }
    public virtual Category Category { get; set; }
  }
}