using DAL.context;
using DAL.models.entities;
using DAL.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public class SkillCategoryRepository : BaseRepository,ISkillCategoryRepository
    {
        private readonly AppDBContext _context;

        public SkillCategoryRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<SkillCategory> CreateSkillCategory(SkillCategory skillCategory)
        {
            
                var skillCategoryCreated =  await _context.SkillCategories.AddAsync(skillCategory);
                await _context.SaveChangesAsync();

            return skillCategoryCreated.Entity;

        }

        public async Task<IEnumerable<SkillCategory>> GetAllSkillCategories()
        {
            
                var skillsCategories = await _context.SkillCategories.ToListAsync();
                return skillsCategories;
            
        }

        public async Task<SkillCategory> GetSkillCategoryById(int id)
        {
            
                var skillCategory = await _context.SkillCategories.FirstOrDefaultAsync(sc => sc.Id == id);
                return skillCategory;
        }

        
    }

        
    
}
