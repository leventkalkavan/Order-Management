using Application.DTOs.AboutDto;
using Application.DTOs.BookingDto;
using AutoMapper;
using Domain.Entities;

namespace OrderManagementAPI.Mapping;

public class BookingMapping: Profile
{
    public BookingMapping()
    {
        CreateMap<Booking, ResultBookingDto>().ReverseMap();
        CreateMap<Booking, CreateBookingDto>().ReverseMap();
        CreateMap<Booking, GetBookingDto>().ReverseMap();
        CreateMap<Booking, UpdateBookingDto>().ReverseMap();
    }
}