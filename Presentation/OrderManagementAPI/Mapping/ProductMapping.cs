using Application.DTOs.ProductDto;
using AutoMapper;
using Domain.Entities;

namespace OrderManagementAPI.Mapping;

public class ProductMapping: Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, GetProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
    }
}