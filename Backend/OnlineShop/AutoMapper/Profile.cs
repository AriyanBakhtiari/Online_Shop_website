using AutoMapper;
using OnlineShop.Data.Models;
using OnlineShop.ViewModel;

namespace OnlineShop.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CurrencyInquiryDataList, CurrencyInquieyViewModel>();
        CreateMap<CryptoCurrencyInquiryDataList, CryptoCurrencyViewModel>();

    }
}