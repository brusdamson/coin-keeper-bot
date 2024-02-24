using AutoMapper;
using FinancialBot.Application.Common.Mappings;
using FinancialBot.Application.Products.Queries.GetProductList;
using FinancialBot.Domain;

namespace FinancialBot.Application.Users.Queries.GetUserByChatId;

public class AppUserDto : IMapWith<AppUser>
{
    public Guid Id { get; set; }
    
    public long ChatId { get; set; }
    
    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<AppUser, AppUserDto>()
            .ForMember(userDto => userDto.Id,
                opt =>
                    opt.MapFrom(user => user.Id))
            .ForMember(userDto => userDto.FirstName,
                opt =>
                    opt.MapFrom(user => user.FirstName))
            .ForMember(userDto => userDto.LastName,
                opt =>
                    opt.MapFrom(user => user.LastName))
            .ForMember(userDto => userDto.Username,
                opt => 
                    opt.MapFrom(user => user.Username));
    }
}