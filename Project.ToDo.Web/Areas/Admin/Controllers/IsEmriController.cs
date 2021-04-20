using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Todo.Business.Interfaces;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Project.Todo.DTO.DTOs.GorevDtos;
using Project.Todo.DTO.DTOs.AppUSerDtos;
using Project.Todo.Web.StringInfo;
using Project.Todo.DTO.DTOs.RaporDtos;

namespace Project.Todo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class IsEmriController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IGorevService _gorevService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDosyaService _dosyaService;
        private readonly IBildirimService _bildirimService;
        private readonly IMapper _mapper;
        public IsEmriController(IAppUserService appUserService, IGorevService gorevService, UserManager<AppUser> userManager, IDosyaService dosyaService, IBildirimService bildirimService, IMapper mapper)
        {
            _appUserService = appUserService;
            _gorevService = gorevService;
            _userManager = userManager;
            _dosyaService = dosyaService;
            _bildirimService = bildirimService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.IsEmri;
            return View(_mapper.Map<List<GorevListAllDto>>(_gorevService.GetirTumTablolarla()));
        }
        public IActionResult Detaylandir(int id)
        {
            TempData["Active"] = TempDataInfo.IsEmri;
            return View(_mapper.Map<GorevListAllDto>(_gorevService.GetirRaporlarileId(id)));
        }
        public IActionResult AtaPersonel(int id, string s, int sayfa = 1)
        {
            TempData["Active"] = TempDataInfo.IsEmri;
            ViewBag.AktifSayfa = sayfa;
            ViewBag.Aranan = s;


            var personeller = _mapper.Map<List<AppUserListDto>>(_appUserService.GetirAdminOlmayanlar(out int toplamSayfa, s, sayfa));

            ViewBag.ToplamSayfa = toplamSayfa;

            ViewBag.Personeller = personeller;

            return View(_mapper.Map<GorevListDto>(_gorevService.GetirAciliyetileId(id)));
        }
        [HttpPost]
        public IActionResult AtaPersonel(PersonelGorevlendirDto model)
        {
            var guncellenecekGorev = _gorevService.GetirIdile(model.GorevId);
            guncellenecekGorev.AppUserId = model.PersonelId;
            _gorevService.Guncelle(guncellenecekGorev);
            _bildirimService.Kaydet(new Bildirim
            {
                AppUserId = model.PersonelId,
                Aciklama = $"{guncellenecekGorev.Ad} adlı iş için görevlendirildiniz."
            });
            return RedirectToAction("Index");
        }
        public IActionResult GorevlendirPersonel(PersonelGorevlendirDto model)
        {
            TempData["Active"] = TempDataInfo.IsEmri;

            PersonelGorevlendirListDto personelGorevlendirModel = new PersonelGorevlendirListDto
            {
                AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.PersonelId)),

                Gorev = _mapper.Map<GorevListDto>(_gorevService.GetirAciliyetileId(model.GorevId))
            };

            return View(personelGorevlendirModel);
        }
        public IActionResult GetirExcel(int id)
        {
            return File(_dosyaService.AktarExcel(_mapper.Map<List<RaporDosyaDto>>(_gorevService.GetirRaporlarileId(id).Raporlar)), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", Guid.NewGuid() + ".xlsx");
        }
        public IActionResult GetirPdf(int id)
        {
            var path = _dosyaService.AktarPdf(_mapper.Map<List<RaporDosyaDto>>( _gorevService.GetirRaporlarileId(id).Raporlar));
            return File(path, "application/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}
