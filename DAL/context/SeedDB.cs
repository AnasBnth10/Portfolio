using DAL.models.entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.context
{
    public static class SeedDB
    {

        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                Seed(serviceScope.ServiceProvider.GetService<AppDBContext>());
            }
        }

        public static void Seed(AppDBContext context)
        {

            var skillCategory1 = new SkillCategory();
            var skillCategory2 = new SkillCategory();
            var skillCategory3 = new SkillCategory();
            var skillCategory4 = new SkillCategory();


            if (!context.SkillCategories.Any())
            {

                skillCategory1 = new SkillCategory()
                {
                    Name = "Programming Languages",
                    Description = "Programming Languages (Markup, Query, etc...)"
                };


                skillCategory2 = new SkillCategory()
                {
                    Name = "Frameworks",
                    Description = "Frameworks"
                };


                skillCategory3 = new SkillCategory()
                {
                    Name = "Office 365",
                    Description = "Office 365"
                };


                skillCategory4 = new SkillCategory()
                {
                    Name = "Other",
                    Description = "Other"
                };

                skillCategory1 = context.SkillCategories.Add(skillCategory1).Entity;
                skillCategory2 = context.SkillCategories.Add(skillCategory2).Entity;
                skillCategory3 = context.SkillCategories.Add(skillCategory3).Entity;
                skillCategory4 = context.SkillCategories.Add(skillCategory4).Entity;

                context.SaveChanges();


                if (!context.Skills.Any())
                {


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

                    context.Skills.AddRange(skillsPL);
                    context.Skills.AddRange(skillsFrameworks);
                    context.Skills.AddRange(skillsOffice365);
                    context.Skills.AddRange(skillsOther);

                    context.SaveChanges();

                }
            }
            }

    }
}
