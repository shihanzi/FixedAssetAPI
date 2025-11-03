using Microsoft.AspNetCore.Mvc;

namespace FixedAssetAPI.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
