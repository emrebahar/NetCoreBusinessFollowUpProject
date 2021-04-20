using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Todo.Business.Interfaces;
using Project.Todo.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Todo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class GrafikController : Controller
    {
        private readonly IAppUserService _appUserService;
        public GrafikController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Grafik;

            return View();
        }
        public IActionResult EnCokTamamlayan()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetirEnCokGorevTamamlamisPersoneller());
            return Json(jsonString);
        }
        public IActionResult EnCokCalisan()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetirEnCokGorevdeCalisanPersoneller());
            return Json(jsonString);
        }
    }
}
