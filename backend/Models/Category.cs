using System.Collections.Generic;

namespace backend.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string pathImage { get; set; }

    // public virtual IEnumerable<Product> Products { get; set; }
    public virtual List<Product> Products { get; set; }

  }
}