using DiWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRandomService _randomService;
        private readonly IRandomWrapper _randomWrapper;
        public HomeController(IRandomService randomService, IRandomWrapper randomWrapper)
        {
            _randomService = randomService;
            _randomWrapper = randomWrapper;
        }

        public IActionResult Index()
        {
            string result = $"Service number: {_randomService.GetNumber()}, " +
                        $"Wrapper number: {_randomWrapper.GetNumber()}";
            return Content(result);
        }
    }
}