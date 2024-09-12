namespace Business.Dtos.Responses.AddressResponses;

public class CreatedAddressResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid DistrictId { get; set; }
    public string AddressDetail { get; set; }
}