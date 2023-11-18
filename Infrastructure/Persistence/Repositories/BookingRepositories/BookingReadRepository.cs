using Application.Repositories.BookingRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.BookingRepositories;

public class BookingReadRepository: ReadRepository<Booking>, IBookingReadRepository
{
    public BookingReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}