using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Todo.Business.Interfaces;
using Project.Todo.Entities.Concrete;
using Project.Todo.Web.BaseControllers;
using Project.Todo.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ToDo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class HomeController : BaseIdentityController
    {
        private readonly IGorevService _gorevService;
        private readonly IBildirimService _bildirimService;
        private readonly IRaporService _raporService;
        public HomeController(IGorevService gorevService, IBildirimService bildirimService, UserManager<AppUser> userManager, IRaporService raporService) : base(userManager)
        {
            _gorevService = gorevService;
            _bildirimService = bildirimService;
            _raporService = raporService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Anasayfa;
            var user = await GetirGirisYapanKullanici();
            ViewBag.AtanmayiBekleyenGorevSayisi = _gorevService.GetirGorevSayisiAtanmayiBekleyen();
            ViewBag.TamamlanmisGorevSayisi = _gorevService.GetirGorevTamamlanmis();
            ViewBag.OkunmamisBildirimSayisi = _bildirimService.GetirOkunmayanSayisiileAppUserId(user.Id);
            ViewBag.ToplamRaporSayisi = _raporService.GetirRaporSayisi();
            return View();
        }
    }
}
