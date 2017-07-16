using AutoMapper;
using MyCodeCamp.Data.Entities;

namespace LearningApiCore.Models
{
    public class CampMappingProfile : Profile
    {
        public CampMappingProfile()
        {
            CreateMap<Camp, CampModel>();
        }
    }
}
