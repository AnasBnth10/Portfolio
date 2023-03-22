using DAL.models.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.context
{
    public class AppDBContext : DbContext
    {
        public class OptionsBuild
        {

            public OptionsBuild()
            {
                settings = new AppConfiguration();
                optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
                optionsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = optionsBuilder.Options;

            }
            public DbContextOptionsBuilder<AppDBContext> optionsBuilder { get; set; }
            public DbContextOptions<AppDBContext> dbOptions { get; set; }

            private AppConfiguration settings { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();

        public AppDBContext(DbContextOptions<AppDBContext> dbOptions) :  base(dbOptions)
        {
           
        }

        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<Skill> Skills { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SkillCategory>()
                .HasMany(sc => sc.Skills)
                .WithOne(s => s.SkillCategory!)
                .HasForeignKey(sc => sc.SkillCategoryId);

            modelBuilder
                .Entity<Skill>()
                .HasOne(s => s.SkillCategory)
                .WithMany(sc => sc.Skills)
                .HasForeignKey(s => s.SkillCategoryId);
                
        }
    }
}
