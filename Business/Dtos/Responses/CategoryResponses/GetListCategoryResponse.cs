using Microsoft.SqlServer.Types;

namespace Business.Dtos.Responses.CategoryResponses;

public class GetListCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; } // Üst kategori ID'si
   
}
