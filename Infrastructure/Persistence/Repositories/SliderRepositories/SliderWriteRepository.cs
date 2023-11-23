using Application.Repositories.SliderRepositories;
using Domain;
using Persistence.Context;

namespace Persistence.Repositories.SliderRepositories;

public class SliderWriteRepository: WriteRepository<Slider>, ISliderWriteRepository
{
    public SliderWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}