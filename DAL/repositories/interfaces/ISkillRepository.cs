using DAL.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories.interfaces
{
    public interface ISkillRepository
    {

        Task<bool> SkillCategoryExists(int categoryId);

        Task<IEnumerable<Skill>> GetAllSkillsForCategory(int categoryId);

        Task<Skill> GetSkillFromCategoryById(int categoryId,int skillId);

       Task<Skill> CreateSkill(int skillCategoryId,Skill skill);
    }
}
