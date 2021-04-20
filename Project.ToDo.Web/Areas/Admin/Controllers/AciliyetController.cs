using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Todo.Business.Interfaces;
using Project.Todo.Entities.Concrete;
using System.Collections.Generic;
using AutoMapper;
using Project.Todo.DTO.DTOs.AciliyetDtos;
using Project.Todo.Web.StringInfo;

namespace Project.Todo.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = RoleInfo.Admin)]
    [Area(AreaInfo.Admin)]
    public class AciliyetController : Controller
    {
        private readonly IAciliyetService _aciliyetService;
        private readonly IMapper _mapper;
        public AciliyetController(IAciliyetService aciliyetService, IMapper mapper)
        {
            _aciliyetService = aciliyetService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempDataInfo.Aciliyet;
            return View(_mapper.Map<List<AciliyetListDto>>(_aciliyetService.GetirHepsi()));
        }
        public IActionResult EkleAciliyet()
        {
            TempData["Active"] = TempDataInfo.Aciliyet;
            return View(new AciliyetAddDto());
        }

        [HttpPost]
        public IActionResult EkleAciliyet(AciliyetAddDto model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Kaydet(new Aciliyet()
                {
                    Tanim = model.Tanim
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult GuncelleAciliyet(int id)
        {
            TempData["Active"] = TempDataInfo.Aciliyet;

            return View(_mapper.Map<AciliyetUpdateDto>(_aciliyetService.GetirIdile(id)));
        }
        [HttpPost]
        public IActionResult GuncelleAciliyet(AciliyetUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _aciliyetService.Guncelle(new Aciliyet
                {
                    Id = model.Id,
                    Tanim = model.Tanim
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
