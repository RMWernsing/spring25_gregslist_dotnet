

namespace gregslist_dotnet.Services;

public class HousesService
{
  private readonly HousesRepository _repository;

  public HousesService(HousesRepository repository)
  {
    _repository = repository;
  }

  internal House CreateHouse(House houseData)
  {
    House house = _repository.CreateHouse(houseData);
    return house;
  }

  internal string DeleteHouse(int houseId, Account userInfo)
  {
    House house = GetHouseById(houseId);
    if (house.CreatorId != userInfo.Id)
    {
      throw new Exception($"{userInfo.Name.ToUpper()}, YOU DO NOT HAVE PERMISSION TO DELETE A POST {house.Creator.Name.ToUpper()}!!! THE POLICE HAVE BEEN NOTIFIED AND YOU WILL BE HELD ACCOUNTABLE 🚓🚓🚓");
    }
    _repository.DeleteHouse(houseId);
    return $"{house.Creator.Name}, your house has been successfully deleted";
  }

  internal House GetHouseById(int houseId)
  {
    House house = _repository.GetHouseById(houseId);
    if (house == null)
    {
      throw new Exception($"Invalid House Id: {houseId}");
    }
    return house;
  }

  internal List<House> GetHouses()
  {
    List<House> houses = _repository.GetHouses();
    return houses;
  }

  internal House UpdateHouse(Account userInfo, House houseData, int houseId)
  {
    House house = GetHouseById(houseId);
    if (house.CreatorId != userInfo.Id)
    {
      throw new Exception("YOU CANNOT UPDATE SOMEONE ELSES HOUSE INFORMATION");
    }
    house.Sqft = houseData.Sqft ?? house.Sqft;
    house.Bedrooms = houseData.Bedrooms ?? house.Bedrooms;
    house.Bathrooms = houseData.Bathrooms ?? house.Bathrooms;
    house.ImgUrl = houseData.ImgUrl ?? house.ImgUrl;
    house.Description = houseData.Description ?? house.Description;
    house.Price = houseData.Price ?? house.Price;

    _repository.UpdateHouse(house);
    return house;

  }
}