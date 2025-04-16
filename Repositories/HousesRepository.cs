


namespace gregslist_dotnet.Repositories;


public class HousesRepository
{
  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal House CreateHouse(House houseData)
  {
    string sql = @"
    INSERT INTO 
    houses (sqft, bedrooms, bathrooms, img_url, description, price, creator_id)
    VALUES(@Sqft, @Bedrooms, @Bathrooms, @ImgUrl, @Description, @Price, @CreatorId);

    SELECT houses.*, accounts.* 
    FROM houses 
    INNER JOIN accounts ON accounts.id = houses.creator_id 
    WHERE houses.id = LAST_INSERT_ID();";

    House house = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }, houseData).SingleOrDefault();
    return house;
  }

  internal House GetHouseById(int houseId)
  {
    string sql = @"
    SELECT houses.*, accounts.* 
    FROM houses 
    INNER JOIN accounts ON accounts.id = houses.creator_id 
    WHERE houses.id = @houseId;";
    House house = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }, new { houseId }).SingleOrDefault();
    return house;
  }

  internal List<House> GetHouses()
  {
    string sql = "SELECT houses.*, accounts.* FROM houses INNER JOIN accounts ON accounts.id = houses.creator_id;";
    List<House> houses = _db.Query(sql, (House house, Account account) =>
    {
      house.Creator = account;
      return house;
    }).ToList();
    return houses;
  }
}