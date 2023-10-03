namespace ECommerceProject.Shared.Models.ECommerce;

public class CategoryIM
{
    public string Name { get; set; } = string.Empty;

    public List<string> Filters { get; set; } = default!;
}
