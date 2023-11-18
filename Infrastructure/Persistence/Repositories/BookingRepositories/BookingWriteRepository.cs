using Application.Repositories.BookingRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.BookingRepositories;

public class BookingWriteRepository: WriteRepository<Booking>, IBookingWriteRepository
{
    public BookingWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}