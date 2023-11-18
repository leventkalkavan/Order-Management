using Application.DTOs.DiscountDto;
using AutoMapper;
using Domain.Entities;

namespace OrderManagementAPI.Mapping;

public class DiscountMapping: Profile
{
    public DiscountMapping()
    {
        CreateMap<Discount, ResultDiscountDto>().ReverseMap();
        CreateMap<Discount, CreateDiscountDto>().ReverseMap();
        CreateMap<Discount, GetDiscountDto>().ReverseMap();
        CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
    }
}