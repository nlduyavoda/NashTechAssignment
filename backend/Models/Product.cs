using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    [Range(0, 5)]
    [Column(TypeName = "TINYINT")]
    public int Rated { get; set; }

    public virtual List<Image> Images { get; set; }
    public int? CategoryId { get; set; }
    public virtual Category Category { get; set; }
  }
}