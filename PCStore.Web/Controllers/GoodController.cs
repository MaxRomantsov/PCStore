using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using PCStore.Core.DTO_s.Good;
using PCStore.Core.DTO_s.Site;
using PCStore.Core.Interfaces;
using PCStore.Core.Validation.Good;
using System.Data;
using X.PagedList;

namespace PCStore.Web.Controllers
{
    public class GoodController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IGoodService _goodService;
        public GoodController(ICategoryService categoryService, IGoodService goodService)
        {
            _categoryService = categoryService;
            _goodService = goodService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int? page)
        {
            List<GoodDto> goods = await _goodService.GetAll();
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(goods.ToPagedList(pageNumber, pageSize));
        }


        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> Create()
        {
            await LoadCategories();
            return View();
        }
        [Authorize(Roles = "administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GoodDto model)
        {
            var validator = new CreateValidation();
            var validatinResult = await validator.ValidateAsync(model);
            if (validatinResult.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                model.File = files;
                await _goodService.Create(model);
                return RedirectToAction("Index", "Good");
            }
            ViewBag.AuthError = validatinResult.Errors[0];
            return View();
        }
        private async Task LoadCategories()
        {
            ViewBag.CategoryList = new SelectList(
                await _categoryService.GettAll(),
                nameof(CategoryDto.Id),
                nameof(CategoryDto.Name)
                );
            ;
        }
        public async Task<IActionResult> GoodsByCategory(int id)
        {
            List<GoodDto> goods = await _goodService.GetByCategory(id);
            int pageSize = 20;
            int pageNumber = 1;
            return View("Index", goods.ToPagedList(pageNumber, pageSize));
        }
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var goods = await _goodService.Get(id);

            if (goods == null) return NotFound();

            await LoadCategories();
            return View(goods);
        }

        [Authorize(Roles = "administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GoodDto model)
        {
            var validator = new CreateValidation();
            var validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                model.File = files;
                await _goodService.Update(model);
                return RedirectToAction("Index", "Good");
            }
            ViewBag.CreatePostError = validationResult.Errors[0];
            return View(model);
        }
        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var goodDto = await _goodService.Get(id);

            if (goodDto == null)
            {
                ViewBag.AuthError = "Good not found.";
                return View();
            }
            return View(goodDto);
        }

        [Authorize(Roles = "administrator")]
        public async Task<IActionResult> DeleteById(int id)
        {
            await _goodService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
