using AutoMapper;
using OnlineShop.Data.Models;
using OnlineShop.ViewModel;

namespace OnlineShop.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Add as many of these lines as you need to map your objects
        CreateMap<User, UserViewModel>();
        CreateMap<UserViewModel, User>();
    }
}