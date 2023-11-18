using Application.DTOs.ReferenceDto;
using AutoMapper;
using Domain.Entities;

namespace OrderManagementAPI.Mapping;

public class ReferenceMapping: Profile
{
    public ReferenceMapping()
    {
        CreateMap<Reference, ResultReferenceDto>().ReverseMap();
        CreateMap<Reference, CreateReferenceDto>().ReverseMap();
        CreateMap<Reference, GetReferenceDto>().ReverseMap();
        CreateMap<Reference, UpdateReferenceDto>().ReverseMap();
    }
}