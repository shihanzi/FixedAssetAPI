using Microsoft.AspNetCore.Mvc;

namespace FixedAssetAPI.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
