using AutoMapper;
using Project.Todo.DTO.DTOs.AciliyetDtos;
using Project.Todo.DTO.DTOs.AppUSerDtos;
using Project.Todo.DTO.DTOs.BildirimDtos;
using Project.Todo.DTO.DTOs.GorevDtos;
using Project.Todo.DTO.DTOs.RaporDtos;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Todo.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Aciliyet - AciliyetDto
            CreateMap<AciliyetAddDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetAddDto>();
            CreateMap<AciliyetListDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetListDto>();
            CreateMap<AciliyetUpdateDto, Aciliyet>();
            CreateMap<Aciliyet, AciliyetUpdateDto>();
            #endregion

            #region AppUser - AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region Bildirim - BildirimDto
            CreateMap<BildirimListDto, Bildirim>();
            CreateMap<Bildirim, BildirimListDto>();
            #endregion

            #region Gorev- GorevDto
            CreateMap<GorevAddDto, Gorev>();
            CreateMap<Gorev, GorevAddDto>();
            CreateMap<GorevListDto, Gorev>();
            CreateMap<Gorev, GorevListDto>();
            CreateMap<GorevUpdateDto, Gorev>();
            CreateMap<Gorev, GorevUpdateDto>();
            CreateMap<GorevListAllDto, Gorev>();
            CreateMap<Gorev, GorevListAllDto>();
            #endregion

            #region Rapor - RaporDto
            CreateMap<RaporAddDto, Rapor>();
            CreateMap<Rapor, RaporAddDto>();
            CreateMap<RaporUpdateDto, Rapor>();
            CreateMap<Rapor, RaporUpdateDto>();
            CreateMap<RaporDosyaDto, Rapor>();
            CreateMap<Rapor, RaporDosyaDto>();
            #endregion
        }
    }
}
