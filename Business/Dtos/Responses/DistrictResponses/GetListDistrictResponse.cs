namespace Business.Dtos.Responses.DistrictResponses;

public class GetListDistrictResponse
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string Name { get; set; }
    public string CityName { get; set; }
}
