namespace DiWebApp.Services
{
    public class RandomService: IRandomService
    {
        public int _number;
        public RandomService() => _number = new Random().Next(1000000);
        public int GetNumber() => _number;
    }
}