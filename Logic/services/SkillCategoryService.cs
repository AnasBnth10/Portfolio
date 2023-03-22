using DAL.models.entities;
using Logic.services.interfaces;
using DAL.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.services
{
    public class SkillCategoryService : ISkillCategoryService
    {
        private readonly ISkillCategoryRepository _skillCategoryRepository;

        public SkillCategoryService(ISkillCategoryRepository skillCategoryRepository) 
        {
            _skillCategoryRepository = skillCategoryRepository;
        }
        public SkillCategory CreateSkillCategory(SkillCategory skillCategory)
        {
            return _skillCategoryRepository.CreateSkillCategory(skillCategory).Result;
        }

        public IEnumerable<SkillCategory> GetAllSkillCategories()
        {
            return _skillCategoryRepository.GetAllSkillCategories().Result;
        }

        public SkillCategory GetSkillCategoryById(int id)
        {
            return _skillCategoryRepository.GetSkillCategoryById(id).Result;
        }
    }
}
