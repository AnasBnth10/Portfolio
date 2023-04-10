using DAL.models.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories.interfaces
{
    public interface ISkillCategoryRepository
    {

       

        Task<IEnumerable<SkillCategory>> GetAllSkillCategories();

        Task<SkillCategory> GetSkillCategoryById(int id);
        Task<SkillCategory> GetSkillCategoryByName(String name);

        Task<SkillCategory> CreateSkillCategory(SkillCategory skillCategory);


    }
}
