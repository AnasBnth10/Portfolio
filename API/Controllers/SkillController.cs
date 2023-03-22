using API.DTO;
using AutoMapper;
using DAL.models.entities;
using Logic.services;
using Logic.services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/category/{categoryId}/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public SkillController(ISkillService skillService,IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SkillReadDTO>> GetAllSkilsForCategory(int categoryId) {

            bool skillCategoryExist = _skillService.SkillCategoryExists(categoryId);

            if(!skillCategoryExist)
            {
                return NotFound();
            }

            var skillItems = _skillService.GetAllSkillsForCategory(categoryId);

            return Ok(_mapper.Map<IEnumerable<SkillReadDTO>>(skillItems));
        }

        [HttpGet("skillId", Name = "GetSkillFromCategoryById")]
        public ActionResult<SkillReadDTO> GetSkillFromCategoryById(int categoryId,int skillId)
        {
            bool skillCategoryExist = _skillService.SkillCategoryExists(categoryId);

            if (!skillCategoryExist)
            {
                return NotFound();
            }

            var skillItem = _skillService.GetSkillFromCategoryById(categoryId, skillId);

            if (skillItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SkillReadDTO>(skillItem));
        }

        [HttpPost]
        public ActionResult<SkillReadDTO> CreateSkill(int categoryId,SkillCreateDto skillCreateDto)
        {
            if (skillCreateDto == null) throw new ArgumentNullException(nameof(skillCreateDto));

            bool skillCategoryExist = _skillService.SkillCategoryExists(categoryId);

            if (!skillCategoryExist)
            {
                return NotFound();
            }

            var skill = _mapper.Map<Skill>(skillCreateDto);

            skill = _skillService.CreateSkill(categoryId,skill);

            var skillReadDTO = _mapper.Map<SkillReadDTO>(skill);

            return CreatedAtRoute(nameof(GetSkillFromCategoryById), new {categoryId=skillReadDTO.SkillCategoryId, skillId = skillReadDTO.Id }, skillReadDTO);

           
        }
    }
}
