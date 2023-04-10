using DAL.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.services.interfaces
{
    public interface ISkillCategoryService
    {
        IEnumerable<SkillCategory> GetAllSkillCategories();

        SkillCategory GetSkillCategoryById(int id);

        SkillCategory GetSkillCategoryByName(string name);

        SkillCategory CreateSkillCategory(SkillCategory skillCategory);
    }
}
