using AutoMapper;
using MyCodeCamp.Data.Entities;
using System;

namespace LearningApiCore.Models
{
    public class CampMappingProfile : Profile
    {
        public CampMappingProfile()
        {
            CreateMap<Camp, CampModel>()
                .ForMember(c => c.StartDate,
                           opt => opt.MapFrom(camp => camp.EventDate))

                .ForMember(c => c.EndDate,
                           opt => opt.ResolveUsing(camp =>
                           {
                               return camp.EventDate.AddDays(camp.Length - 1);
                           }))

                .ForMember(c => c.Url,
                           opt => opt.ResolveUsing<CampUrlResolver>());

        }
    }
}
