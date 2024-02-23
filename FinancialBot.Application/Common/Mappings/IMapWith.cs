using AutoMapper;

namespace FinancialBot.Application.Common.Mappings;

public class IMapWith<T>
{
    private void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}