namespace Business.Dtos.Requests.AddressRequests;

public class CreateAddressRequest
{
    public Guid AccountId { get; set; }
    public Guid DistrictId { get; set; }
    public string AddressDetail { get; set; }
}