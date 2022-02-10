using CodeBase.Infrastructure.Services;

namespace Assets.CodeBase.Infrastructure.Services.Randomizer
{
    public interface IRandomService : IService
    {
        int Next(int minValue, int maxValue);
    }
}
