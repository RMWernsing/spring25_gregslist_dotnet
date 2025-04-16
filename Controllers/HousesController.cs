namespace gregslist_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
  public HousesController(HousesService housesService)
  {
    _housesService = housesService;
  }
  private readonly HousesService _housesService;

  [HttpGet]
  public ActionResult<List<House>> GetHouses()
  {
    try
    {
      List<House> houses = _housesService.GetHouses();
      return Ok(houses);

    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}