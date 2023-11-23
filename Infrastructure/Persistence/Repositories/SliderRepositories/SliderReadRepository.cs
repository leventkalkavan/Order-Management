using Application.Repositories.SliderRepositories;
using Domain;
using Persistence.Context;

namespace Persistence.Repositories.SliderRepositories;

public class SliderReadRepository: ReadRepository<Slider>, ISliderReadRepository
{
    public SliderReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}