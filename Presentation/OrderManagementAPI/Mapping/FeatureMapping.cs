using Application.DTOs.FeatureDto;
using AutoMapper;
using Domain.Entities;

namespace OrderManagementAPI.Mapping;

public class FeatureMapping: Profile
{
    public FeatureMapping()
    {
        CreateMap<Feature, ResultFeatureDto>().ReverseMap();
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, GetFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
    }
}