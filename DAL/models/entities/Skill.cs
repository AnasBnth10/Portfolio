using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.models.entities
{
    public class Skill
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }
    }
}
