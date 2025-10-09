using DiWebApp.Services;

namespace DiWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<IRandomService, RandomService>();
            builder.Services.AddTransient<IRandomWrapper, RandomWrapper>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}