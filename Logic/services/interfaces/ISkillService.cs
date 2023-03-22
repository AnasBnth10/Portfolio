using DAL.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.services.interfaces
{
    public interface ISkillService
    {
        IEnumerable<Skill> GetAllSkillsForCategory(int categoryId);

        Skill GetSkillFromCategoryById(int categoryId, int skillId);

        Skill CreateSkill(int skillCategoryId, Skill skill);

        bool SkillCategoryExists(int categoryId);
    }
}
