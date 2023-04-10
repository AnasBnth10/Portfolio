using DAL.models.entities;

namespace API.DTO
{
    public class SkillCategoryReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SkillReadDTO> Skills { get; set; } 
    }
}
