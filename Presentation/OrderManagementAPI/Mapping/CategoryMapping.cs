using Application.DTOs.CategoryDto;
using AutoMapper;
using Domain.Entities;

namespace OrderManagementAPI.Mapping;

public class CategoryMapping: Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, GetCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
    }
}