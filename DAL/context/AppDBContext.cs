﻿using DAL.models.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                optionsBuilder.UseInMemoryDatabase("inMemory");
                //optionsBuilder.UseSqlServer(settings.sqlConnectionString);
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

        public void SeedDb()
        {
            if (!SkillCategories.Any())
            {

                var skillCategory1 = new SkillCategory()
                {
                    Name = "Programming Languages",
                    Description = "Programming Languages (Markup, Query, etc...)"
                };


                var skillCategory2 = new SkillCategory()
                {
                    Name = "Frameworks",
                    Description = "Frameworks"
                };


                var skillCategory3 = new SkillCategory()
                {
                    Name = "Office 365",
                    Description = "Office 365"
                };


                var skillCategory4 = new SkillCategory()
                {
                    Name = "Other",
                    Description = "Other"
                };

                skillCategory1 = SkillCategories.Add(skillCategory1).Entity;
                skillCategory2 = SkillCategories.Add(skillCategory2).Entity;
                skillCategory3 = SkillCategories.Add(skillCategory3).Entity;
                skillCategory4 = SkillCategories.Add(skillCategory4).Entity;


                var skillsPL = new List<Skill>()
            {
                new Skill()
                {
                    Name="C#",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="C++",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="Java",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="Python",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="PHP",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="Dart",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="Swift",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="Kotlin",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="HTML",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="CSS",
                    SkillCategoryId=skillCategory1.Id
                },
                new Skill()
                {
                    Name="X++",
                    SkillCategoryId=skillCategory1.Id
                }
            };

                var skillsFrameworks = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "ASP .NET",
                        SkillCategoryId = skillCategory2.Id
                    },
                    new Skill()
                    {
                        Name = "Spring",
                        SkillCategoryId = skillCategory2.Id
                    },
                    new Skill()
                    {
                        Name = "Hibernate",
                        SkillCategoryId = skillCategory2.Id
                    },
                    new Skill()
                    {
                        Name = "ReactJS",
                        SkillCategoryId = skillCategory2.Id
                    },
                    new Skill()
                    {
                        Name = "Laravel",
                        SkillCategoryId = skillCategory2.Id
                    },
                    new Skill()
                    {
                        Name = "Flutter",
                        SkillCategoryId = skillCategory2.Id
                    },
                    new Skill()
                    {
                        Name = "Android",
                        SkillCategoryId = skillCategory2.Id
                    },
                    new Skill()
                    {
                        Name = "IOS",
                        SkillCategoryId = skillCategory2.Id
                    }

                };

                var skillsOffice365 = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "Word",
                        SkillCategoryId = skillCategory3.Id
                    },
                    new Skill()
                    {
                        Name = "Powerpoint",
                        SkillCategoryId = skillCategory3.Id
                    },
                    new Skill()
                    {
                        Name = "Outlook",
                        SkillCategoryId = skillCategory3.Id
                    },
                    new Skill()
                    {
                        Name = "Excel",
                        SkillCategoryId = skillCategory3.Id
                    },
                    new Skill()
                    {
                        Name = "OneNote",
                        SkillCategoryId = skillCategory3.Id
                    },
                    new Skill()
                    {
                        Name = "Sharepoint",
                        SkillCategoryId = skillCategory3.Id
                    }
                };

                var skillsOther = new List<Skill>()
                {
                    new Skill()
                    {
                        Name = "Wordpress",
                        SkillCategoryId = skillCategory4.Id
                    },
                    new Skill()
                    {
                        Name = "Linux",
                        SkillCategoryId = skillCategory4.Id
                    },
                    new Skill()
                    {
                        Name = "Cisco Networking",
                        SkillCategoryId = skillCategory4.Id
                    },
                    new Skill()
                    {
                        Name = "Dynamics 365",
                        SkillCategoryId = skillCategory4.Id
                    },
                    new Skill()
                    {
                        Name = "Docker",
                        SkillCategoryId = skillCategory4.Id
                    },
                    new Skill()
                    {
                        Name = "Power BI",
                        SkillCategoryId = skillCategory4.Id
                    },
                    new Skill()
                    {
                        Name = "Power Automate",
                        SkillCategoryId = skillCategory4.Id
                    },
                    new Skill()
                    {
                        Name = "FireBase",
                        SkillCategoryId = skillCategory4.Id
                    }
                };

                Skills.AddRange(skillsPL);
                Skills.AddRange(skillsFrameworks);
                Skills.AddRange(skillsOffice365);
                Skills.AddRange(skillsOther);

                SaveChanges();
            }
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SkillCategory>()
                .HasMany(sc => sc.Skills)
                .WithOne(s => s.SkillCategory)
                .HasForeignKey(s => s.SkillCategoryId);

            modelBuilder
                .Entity<Skill>()
                .HasOne(s => s.SkillCategory)
                .WithMany(sc => sc.Skills)
                .HasForeignKey(s => s.SkillCategoryId);

           
                
        }
    }
}
