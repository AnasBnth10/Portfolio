using DAL.context;
using DAL.models.entities;
using DAL.repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public class SkillRepository : BaseRepository,ISkillRepository
    {
        private readonly AppDBContext _context;
        public SkillRepository(AppDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Skill> CreateSkill(int skillCategoryId,Skill skill)
        {
            
                
                var skillCreated = await _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();

            return skillCreated.Entity;

            
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsForCategory(int categoryId)
        {
           

                var skills = await _context.Skills.Where(s => s.SkillCategoryId == categoryId).ToListAsync();

            return skills;

           
        }

        public async Task<Skill> GetSkillFromCategoryById(int categoryId, int skillId)
        {
               

                var skill = await _context.Skills.FirstOrDefaultAsync(s => s.SkillCategoryId == categoryId && s.Id == skillId);

                return skill;
        }

        public async Task<bool> SkillCategoryExists(int platformId)
        {
            return await _context.SkillCategories.AnyAsync(sc => sc.Id == platformId);
        }

        
    }
}
