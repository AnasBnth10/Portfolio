using API.DTO;
using AutoMapper;
using DAL.models.entities;

namespace API.Profiles
{
    public class SkillCategoryProfile : Profile
    {

        public SkillCategoryProfile()
        {

            
            
            CreateMap<Skill, SkillReadDTO>();
            CreateMap<SkillCreateDto, Skill>();

            CreateMap<SkillCategory, SkillCategoryReadDto>();
                
            CreateMap<SkillCategoryCreateDTO, SkillCategory>();


        }
    }
}
