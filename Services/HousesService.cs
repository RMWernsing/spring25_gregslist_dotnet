

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
}