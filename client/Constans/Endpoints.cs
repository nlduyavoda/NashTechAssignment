namespace client.Constatnts
{
  public class Endpoints
  {
    public const string Product = "api/product";
    public static string ProductById(int id) => $"{Product}/{id}";

  }
}