using Application.DTOs.AboutDto;
using AutoMapper;
using Domain.Entities;

namespace OrderManagementAPI.Mapping;

public class AboutMapping: Profile
{
    public AboutMapping()
    {
        CreateMap<About, ResultAboutDto>().ReverseMap();
        CreateMap<About, CreateAboutDto>().ReverseMap();
        CreateMap<About, GetAboutDto>().ReverseMap();
        CreateMap<About, UpdateAboutDto>().ReverseMap();
    }
}