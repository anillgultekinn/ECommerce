using Microsoft.SqlServer.Types;

namespace Business.Dtos.Requests.CategoryRequests;

public class CreateCategoryRequest
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}
