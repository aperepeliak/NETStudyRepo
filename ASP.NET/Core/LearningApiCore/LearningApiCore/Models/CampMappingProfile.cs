﻿using AutoMapper;
using MyCodeCamp.Data.Entities;

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
                           opt => opt.ResolveUsing<CampUrlResolver>())

                .ReverseMap()

                .ForMember(m => m.EventDate,
                           opt => opt.MapFrom(model => model.StartDate))
                .ForMember(m => m.Length,
                           opt => opt.ResolveUsing(model => (model.EndDate - model.StartDate).Days + 1))
                .ForMember(m => m.Location,
                           opt => opt.ResolveUsing(model => new Location
                           {
                               Address1 = model.LocationAddress1,
                               Address2 = model.LocationAddress2,
                               Address3 = model.LocationAddress3,
                               CityTown = model.LocationCityTown,
                               StateProvince = model.LocationStateProvince,
                               PostalCode = model.LocationPostalCode,
                               Country = model.LocationCountry
                           }));

        }
    }
}
