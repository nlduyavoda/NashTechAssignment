using System.Collections.Generic;
using LibraryShare.Product;

namespace LibraryShare.Categories
{
  public class CategoriesVM
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string pathImage { get; set; }
    public List<ProductVM> Products { get; set; }

  }
}