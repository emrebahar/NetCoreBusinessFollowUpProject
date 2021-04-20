using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Todo.Business.Interfaces;
using AutoMapper;
using Project.Todo.DTO.DTOs.AppUSerDtos;

namespace Project.Todo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBildirimService _bildirimService;
        private readonly IMapper _mapper;
        public Wrapper(UserManager<AppUser> userManager, IBildirimService bildirimService, IMapper mapper)
        {
            _userManager = userManager;
            _bildirimService = bildirimService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var IdentityUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var model = _mapper.Map<AppUserListDto>(IdentityUser);

            var bildirimler = _bildirimService.GetirOkunmayanlar(model.Id).Count;
            ViewBag.BildirimSayisi = bildirimler;

            var roles = _userManager.GetRolesAsync(IdentityUser).Result;

            if (roles.Contains("Admin"))
            {
                return View(model);
            }
            return View("Member", model);
        }
    }
}
