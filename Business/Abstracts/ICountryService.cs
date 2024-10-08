﻿using Business.Dtos.Requests.CountryRequests;
using Business.Dtos.Responses.CountryResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICountryService
{
    Task<CreatedCountryResponse> AddAsync(CreateCountryRequest createCountryRequest);
    Task<UpdatedCountryResponse> UpdateAsync(UpdateCountryRequest updateCountryRequest);
    Task<DeletedCountryResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListCountryResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetCountryResponse> GetByIdAsync(Guid id);
}