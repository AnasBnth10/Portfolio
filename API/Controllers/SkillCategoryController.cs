using API.DTO;
using AutoMapper;
using DAL.models.entities;
using Logic.services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoryController : ControllerBase
    {
        private readonly ISkillCategoryService _skillCategoryService;
        private readonly IMapper _mapper;

        public SkillCategoryController(ISkillCategoryService skillCategoryService,IMapper mapper)
        {
            _skillCategoryService = skillCategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SkillCategoryReadDto>> GetAllSkillCategories() {

            var skillCategoriesItems = _skillCategoryService.GetAllSkillCategories();

            return Ok(_mapper.Map<IEnumerable<SkillCategoryReadDto>>(skillCategoriesItems));
        }

        [HttpGet("id",Name = "GetSkillCategoryById")]
        public ActionResult<SkillCategoryReadDto> GetSkillCategoryById(int id)
        {

            var skillCategory = _skillCategoryService.GetSkillCategoryById(id);

            if(skillCategory !=  null)
            {
                return Ok(_mapper.Map<SkillCategoryReadDto>(skillCategory));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<SkillCategoryReadDto> CreateSkillCategory(SkillCategoryCreateDTO skillCategoryCreateDTO)
        {
            if(skillCategoryCreateDTO == null) throw new ArgumentNullException(nameof(skillCategoryCreateDTO));

            var skillCategory = _mapper.Map<SkillCategory>(skillCategoryCreateDTO);

            skillCategory = _skillCategoryService.CreateSkillCategory(skillCategory);

            var skillCategoryReadDTO = _mapper.Map<SkillCategoryReadDto>(skillCategory);

            return CreatedAtRoute(nameof(GetSkillCategoryById),new { id = skillCategoryReadDTO.Id },skillCategoryReadDTO);
        }

    }
}
