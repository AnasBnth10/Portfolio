using DAL.models.entities;
using DAL.repositories;
using DAL.repositories.interfaces;
using Logic.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository) {
            _skillRepository = skillRepository;
        }
        public Skill CreateSkill(int skillCategoryId, Skill skill)
        {
            skill.SkillCategoryId = skillCategoryId;

            return _skillRepository.CreateSkill(skillCategoryId,skill).Result;
        }

        public IEnumerable<Skill> GetAllSkillsForCategory(int categoryId)
        {
            return _skillRepository.GetAllSkillsForCategory(categoryId).Result;
        }

        public Skill GetSkillFromCategoryById(int categoryId, int skillId)
        {
            return _skillRepository.GetSkillFromCategoryById(categoryId, skillId).Result;
        }

        public bool SkillCategoryExists(int categoryId)
        {
            return _skillRepository.SkillCategoryExists(categoryId).Result;
        }
    }
}
