using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PCStore.Core.DTO_s.Good;
using PCStore.Core.DTO_s.User;
using PCStore.Core.Interfaces;
using PCStore.Core.Services;
using PCStore.Web.Models;
using System.Diagnostics;
using X.PagedList;
using PCStore.Core.Validation;
using FluentValidation;

namespace PCStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGoodService _goodService;
        private readonly UserService _userService;

        public HomeController(ILogger<HomeController> logger, IGoodService goodService, UserService userService)
        {
            _logger = logger;
            _goodService = goodService;
            _userService = userService;
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
        public async Task<IActionResult> GoodDetail(int id)
        {
            var good = await _goodService.Get(id);

            if (good == null)
                return NotFound();

            return View(good);
        }
        public async Task<IActionResult> Search([FromForm] string searchString)
        {
            List<GoodDto> goods = await _goodService.Search(searchString);
            int pageSize = 20;
            int pageNumber = 1;
            return View("Index", goods.ToPagedList(pageNumber, pageSize));
        }
    }
}