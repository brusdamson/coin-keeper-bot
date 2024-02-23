using AutoMapper;
using FinancialBot.Application.Common.Mappings;
using FinancialBot.Domain;

namespace FinancialBot.Application.Products.Queries.GetProductList;

public class PurchaseProductsDto : IMapWith<Product>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public double Cost { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, PurchaseProductsDto>()
            .ForMember(productDto => productDto.Id,
                opt =>
                    opt.MapFrom(product => product.Id))
            .ForMember(productDto => productDto.Name,
                opt =>
                    opt.MapFrom(product => product.Name))
            .ForMember(productDto => productDto.Cost,
                opt =>
                    opt.MapFrom(product => product.Price));
    }
}