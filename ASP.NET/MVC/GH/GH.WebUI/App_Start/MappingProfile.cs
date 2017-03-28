using AutoMapper;
using GH.WebUI.Core.Dtos;
using GH.WebUI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GH.WebUI.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, UserDto>();
            Mapper.CreateMap<Gig, GigDto>();
            Mapper.CreateMap<Notification, NotificationDto>();
        }
    }
}