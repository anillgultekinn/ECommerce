using Core.Entities;

namespace Entities.Concretes;

public class Address : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid DistrictId { get; set; }
    public string AddressDetail { get; set; }

    public District District { get; set; }
    public Account Account { get; set; }
}