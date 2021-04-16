namespace backend.Models
{
  public class Image
  {

    public int Id { get; set; }
    public string pathImage { get; set; }
    public string DescriptionImage { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

  }
}