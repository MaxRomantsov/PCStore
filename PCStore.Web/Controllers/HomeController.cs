using Microsoft.AspNetCore.Mvc;
using PCStore.Core.DTO_s.Good;
using PCStore.Core.Interfaces;
using PCStore.Web.Models;
using System.Diagnostics;
using X.PagedList;

namespace PCStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGoodService _goodService;

        public HomeController(ILogger<HomeController> logger, IGoodService goodService)
        {
            _logger = logger;
            _goodService = goodService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            List<GoodDto> goods = await _goodService.GetAll();
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(goods.ToPagedList(pageNumber, pageSize));
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}