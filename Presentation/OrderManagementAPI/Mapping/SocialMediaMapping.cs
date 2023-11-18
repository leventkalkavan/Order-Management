using Application.DTOs.SocialMediaDto;
using AutoMapper;
using Domain.Entities;

namespace OrderManagementAPI.Mapping;

public class SocialMediaMapping: Profile
{
    public SocialMediaMapping()
    {
        CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
        CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
        CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
        CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
    }
}