﻿namespace Business.Dtos.Responses.CityResponses;

public class GetListCityResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public string Name { get; set; }
    public string CountryName { get; set; }
}
