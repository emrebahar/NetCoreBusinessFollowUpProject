using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Todo.Business.Interfaces;
using Project.Todo.DTO.DTOs.GorevDtos;
using Project.Todo.Entities.Concrete;
using Project.Todo.Web.BaseControllers;
using Project.Todo.Web.StringInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Todo.Web.Areas.Member.Controllers
{
    [Authorize(Roles = RoleInfo.Member)]
    [Area(RoleInfo.Member)]
    public class GorevController : BaseIdentityController
    {
        private readonly IGorevService _gorevService;
        private readonly IMapper _mapper;
        public GorevController(IGorevService gorevService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _gorevService = gorevService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int aktifSayfa = 1)
        {
            TempData["Active"] = TempDataInfo.Gorev;

            var user = await GetirGirisYapanKullanici();


            var gorevler = _mapper.Map<List<GorevListAllDto>>(_gorevService.GetirTumTablolarlaTamamlanmayan(out int toplamSayfa, user.Id, aktifSayfa));

            ViewBag.ToplamSayfa = toplamSayfa;
            ViewBag.AktifSayfa = aktifSayfa;

            return View(gorevler);
        }
    }
}
