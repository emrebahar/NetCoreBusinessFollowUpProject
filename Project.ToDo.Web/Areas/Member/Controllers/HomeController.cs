using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Todo.Business.Concrete;
using Project.Todo.Business.Interfaces;
using Project.Todo.Entities.Concrete;
using Project.Todo.Web.BaseControllers;
using Project.Todo.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(RoleInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IRaporService _raporService;
        private readonly IGorevService _gorevService;
        private readonly IBildirimService _bildirimService;
        public HomeController(IRaporService raporService, UserManager<AppUser> userManager, IGorevService gorevService, IBildirimService bildirimService) : base(userManager)
        {
            _raporService = raporService;
            _gorevService = gorevService;
            _bildirimService = bildirimService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempDataInfo.Anasayfa;
            var user = await GetirGirisYapanKullanici();
            ViewBag.RaporSayisi = _raporService.GetirRaporSayisiileAppUserId(user.Id);
            ViewBag.TamamlananGorevSayisi = _gorevService.GetirGorevSayisiTamamlananileAppUserId(user.Id);
            ViewBag.OkunmayanBildirimSayisi = _bildirimService.GetirOkunmayanSayisiileAppUserId(user.Id);
            ViewBag.TamamlanmasiGerekenGorevSayisi = _gorevService.GetirGorevSayisiTamamlanmasiGerekenileAppUserId(user.Id);
            return View();
        }
    }
}
