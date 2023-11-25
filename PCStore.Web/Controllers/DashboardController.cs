using Microsoft.AspNetCore.Mvc;

namespace PCStore.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
