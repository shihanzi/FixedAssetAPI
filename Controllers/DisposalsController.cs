using Microsoft.AspNetCore.Mvc;

namespace FixedAssetAPI.Controllers
{
    public class DisposalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
