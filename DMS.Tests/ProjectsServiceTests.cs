using DMS.Data;
using DMS.Domain.Entities;
using DMS.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DMS.Tests
{
    public class ProjectsServiceTests
    {
        private static void CreateTestProjects(DbContextOptions<DataContext> options)
        {
            using (var context = new DataContext(options))
            {
                context.Database.EnsureDeleted();

                context.ProjectCategories.Add(CreateProjectCategory(1, "Educational", "Scholarship for primary, seconday or higher education."));
                context.ProjectCategories.Add(CreateProjectCategory(2, "Self Employment", "One-off donation for socially important matter."));
                context.ProjectCategories.Add(CreateProjectCategory(3, "Missalanious", "Donation for uncategorized purpose."));

                context.Projects.Add(CreateProject(1, "Scholaship for Asitha", "For higher education", 1, new DateTime(2017, 1, 1), new DateTime(2017, 12, 31)));
                context.Projects.Add(CreateProject(2, "Scholaship for Supun", "For O/L education", 1, new DateTime(2017, 2, 1), new DateTime(2018, 3, 31)));
                context.Projects.Add(CreateProject(3, "Scholaship for Viraj", "Aid for self employment", 2, new DateTime(2017, 3, 1), null));

                context.SaveChanges();
            }
        }

        private static ProjectCategory CreateProjectCategory(int id, string shortDesc, string description)
        {
            return new ProjectCategory
            {
                Id = id,
                Description = description,
                ShortDescription = shortDesc,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedBy = 1,
                LastUpdatedDateUtc = DateTime.UtcNow
            };
        }

        private static Project CreateProject(int id, string title, string description, int categoryId, DateTime startDate, DateTime? endDate)
        {
            return new Project
            {
                Id = id,
                Title = title,
                Description = description,
                ProjectCategoryId = categoryId,
                StartDateUtc = startDate,
                EndDateUtc = endDate,
                CreatedBy = 1,
                CreatedDateUtc = DateTime.UtcNow,
                LastUpdatedBy = 1,
                LastUpdatedDateUtc = DateTime.UtcNow
            };
        }

        public class GetAll
        {
            [Fact]
            public void WhenThereAreProjects_ReturnsAll()
            {
                var options = Helper.GetContextOptions();

                CreateTestProjects(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);
                    var projects = service.GetAll();
                    Assert.Equal(3, projects.Count);
                }
            }

            [Theory]
            [InlineData("Educational", 2)]
            public void WhenThereGivenCategory_ReturnsAllInSameCategory(string category, int count)
            {
                var options = Helper.GetContextOptions();

                CreateTestProjects(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);
                    var projects = service.GetAll(category);
                    Assert.Equal(count, projects.Count);
                }
            }
        }
    }
}
