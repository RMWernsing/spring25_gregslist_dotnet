namespace gregslist_dotnet.Models;

public class House
{
  public uint Id { get; set; }
  public uint Sqft { get; set; }
  public uint Bedrooms { get; set; }
  public uint Bathrooms { get; set; }
  public string ImgUlr { get; set; }
  public string Description { get; set; }
  public uint Price { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public Account Creator { get; set; }
}