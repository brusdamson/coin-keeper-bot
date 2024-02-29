using AutoMapper;

namespace FinancialBot.Application.Common.Mappings;

public interface IMapWith<T>
{
    private void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}