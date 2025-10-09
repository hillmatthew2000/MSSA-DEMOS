namespace DiWebApp.Services
{
    public class RandomWrapper: IRandomWrapper
    {
        private readonly IRandomService _randomService;
        public RandomWrapper(IRandomService randomService) => _randomService = randomService;
        public int GetNumber() => _randomService.GetNumber();
    }
}