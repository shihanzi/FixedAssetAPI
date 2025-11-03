using Microsoft.AspNetCore.Mvc;

namespace FixedAssetAPI.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
