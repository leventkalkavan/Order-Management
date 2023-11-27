using Application.Repositories.SliderRepositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories.SliderRepositories;

public class SliderReadRepository: ReadRepository<Slider>, ISliderReadRepository
{
    public SliderReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}