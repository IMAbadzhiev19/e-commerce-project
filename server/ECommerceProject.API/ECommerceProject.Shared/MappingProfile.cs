using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;
using Mapster;

namespace ECommerceProject.Shared;

public static class MappingProfile
{
    public static void Configure()
    {
        TypeAdapterConfig
            .GlobalSettings
            .NewConfig<Product, ProductVM>()
            .Map(p => p.Category, pvm => pvm.Category.ToString());
    }
}