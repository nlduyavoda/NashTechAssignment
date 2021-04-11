namespace client.Constatnts
{
  public class Endpoints
  {
    public const string Product = "api/product";
    public static string ProductById(int id) => $"{Product}/{id}";
    public const string Categories = "api/Categories";
    public static string CategoriesById(int id) => $"{Categories}/{id}";


  }
}