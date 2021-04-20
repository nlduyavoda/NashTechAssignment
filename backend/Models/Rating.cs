using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
  public class Rating
  {
    public int Id { get; set; }
    public int Value { get; set; }
    public string UserId { get; set; }
    public virtual IdentityUser User { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
  }
}