﻿namespace Business.Dtos.Requests.ProductRequests;

public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
