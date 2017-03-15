using DMS.Data;
using DMS.Data.Entities;
using DMS.Domain.Dtos;
using DMS.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace DMS.Tests
{
    public class ProjectsServiceTests
    {      
        public class Create
        {
            [Theory]
            [InlineData("Sholaship for Supun", "As a aid for university education", 1, "Educational", "2017-3-1", "2018-12-31")]
            [InlineData("Sholaship for Amal", "Start a workshop", 2, "Self Employment", "2017-2-1", "2018-2-28")]
            public void WhenPassingCorrectData_SuccessfullyCreate(string title, string description, int categoryId, string category, DateTime startDate, DateTime endDate)
            {
                var options = Helper.GetContextOptions();

                CreateTestData(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);

                    var projectDto = new ProjectDto
                    {
                        Title = title,
                        Description = description,
                        ProjectCategoryId = categoryId,
                        StartDate = startDate,
                        EndDate = endDate
                    };

                    service.Create(projectDto);

                    var project = service.GetAll().Where(p => p.Title == title).FirstOrDefault();

                    ValidateProject(project, null, title, description, category, startDate, endDate);
                }
            }          
        }

        public class Delete
        {
            [Fact]
            public void WhenDeletingExistingProject_DeleteSuccessfully()
            {
                var options = Helper.GetContextOptions();

                CreateTestData(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);

                    service.Delete(1);

                    var deletedProject = service.Get(1);

                    Assert.Null(deletedProject);
                }
            }

            [Fact]
            public void WhenDeletingNonExistingProject_ThrowsException()
            {
                var options = Helper.GetContextOptions();

                CreateTestData(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);

                    Assert.ThrowsAny<ArgumentNullException>(() => service.Delete(100));                  
                }
            }
        }

        public class Get
        {
            [Theory]
            [InlineData(1, "Scholaship for Asitha", "For higher education", "Educational", "2017-1-1", "2017-12-31")]
            [InlineData(2, "Scholaship for Supun", "For O/L education", "Educational", "2017-2-1", "2018-3-31")]
            [InlineData(3, "Scholaship for Viraj", "Aid for self employment", "Self Employment", "2017-3-1", null)]
            public void WhenPassingValidIds_ReturnsProject(int id, string title, string description, string category, DateTime startDate, DateTime endDate)
            {
                var options = Helper.GetContextOptions();

                CreateTestData(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);

                    var project = service.Get(id);

                    Assert.NotNull(project);
                    Assert.Equal(title, project.Title);
                    Assert.Equal(description, project.Description);
                    Assert.Equal(category, project.ProjectCategory);
                    Assert.Equal(startDate, project.StartDate);

                    if (endDate == DateTime.MinValue)
                        Assert.Null(project.EndDate);
                }
            }

            [Theory]
            [InlineData(10)]
            [InlineData(100)]
            [InlineData(101)]
            public void WhenPassingInvalidIds_ReturnsNull(int id)
            {
                var options = Helper.GetContextOptions();

                CreateTestData(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);

                    var project = service.Get(id);

                    Assert.Null(project);
                }
            }
        }

        public class GetAll
        {
            [Fact]
            public void WhenThereAreProjects_ReturnsAll()
            {
                var options = Helper.GetContextOptions();

                CreateTestData(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);
                    var projects = service.GetAll();
                    Assert.Equal(3, projects.Count);
                }
            }

            [Fact]
            public void WhenThereAreNoProjects_ReturnsNon()
            {
                var options = Helper.GetContextOptions();

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);
                    var projects = service.GetAll();

                    Assert.Equal(0, projects.Count);
                }
            }

            [Theory]
            [InlineData("Educational", 2)]
            [InlineData("Self Employment", 1)]
            [InlineData("Missalanious", 0)]
            public void WhenThereProjects_ReturnsAllInSameCategory(string category, int count)
            {
                var options = Helper.GetContextOptions();

                CreateTestData(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);
                    var projects = service.GetAll(category);
                    Assert.Equal(count, projects.Count);
                }
            }

            [Theory]
            [InlineData("Educational", 0)]
            [InlineData("Self Employment", 0)]
            [InlineData("Missalanious", 0)]
            public void WhenThereAreNoProjects_ReturnsNonWhenPassingCategory(string category, int count)
            {
                var options = Helper.GetContextOptions();

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);
                    var projects = service.GetAll(category);
                    Assert.Equal(count, projects.Count);
                }
            }
        }

        public class Update
        {
            [Theory]
            [InlineData(1, "Scholaship for Asitha - Updated", "For higher education - Updated", 1, "Educational", "2017-1-1", "2017-12-31")]
            [InlineData(2, "Scholaship for Supun", "Start Workshop", 2, "Self Employment", "2017-2-1", "2018-3-31")]
            [InlineData(3, "Scholaship for Kasun - Updated", "Buy a sewing machine", 3, "Missalanious", "2017-5-1", "2019-5-1")]
            public void WhenUpdatingExistingProject_UpdateSuccessfully(int id, string title, string description, int categoryId, string category, DateTime startDate, DateTime endDate)
            {
                var options = Helper.GetContextOptions();

                CreateTestData(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);

                    var projectDto = new ProjectDto
                    {
                        Id = id,
                        Title = title,
                        Description = description,
                        ProjectCategoryId = categoryId,
                        StartDate = startDate,
                        EndDate = endDate
                    };

                    service.Update(projectDto);

                    var updatedProject = service.Get(id);

                    ValidateProject(updatedProject, id, title, description, category, startDate, endDate);
                }
            }

            [Fact]
            public void WhenUpdatingNonExistingProject_ThrowsException()
            {
                var options = Helper.GetContextOptions();

                CreateTestData(options);

                using (var context = new DataContext(options))
                {
                    var service = new ProjectsService(context);

                    var projectDto = new ProjectDto
                    {
                        Id = 100,
                        Title = "New Project",
                        Description = "This shoudl fail",
                        ProjectCategoryId = 1,
                        StartDate = new DateTime(2017, 3, 1),
                        EndDate = new DateTime(2018, 3, 1)
                    };

                    Assert.ThrowsAny<NullReferenceException>(() => service.Update(projectDto));
                }
            }
        }

        #region Private support methods

        private static void CreateTestData(DbContextOptions<DataContext> options)
        {
            using (var context = new DataContext(options))
            {
                context.Database.EnsureDeleted();

                context.ProjectCategories.Add(CreateProjectCategory("Educational", "Scholarship for primary, seconday or higher education."));
                context.ProjectCategories.Add(CreateProjectCategory("Self Employment", "One-off donation for socially important matter."));
                context.ProjectCategories.Add(CreateProjectCategory("Missalanious", "Donation for uncategorized purpose."));

                context.Projects.Add(CreateProject("Scholaship for Asitha", "For higher education", 1, new DateTime(2017, 1, 1), new DateTime(2017, 12, 31)));
                context.Projects.Add(CreateProject("Scholaship for Supun", "For O/L education", 1, new DateTime(2017, 2, 1), new DateTime(2018, 3, 31)));
                context.Projects.Add(CreateProject("Scholaship for Viraj", "Aid for self employment", 2, new DateTime(2017, 3, 1), null));

                context.SaveChanges();
            }
        }

        private static ProjectCategory CreateProjectCategory(string shortDesc, string description)
        {
            return new ProjectCategory
            {
                Description = description,
                ShortDescription = shortDesc,
            };
        }

        private static Project CreateProject(string title, string description, int categoryId, DateTime startDate, DateTime? endDate)
        {
            return new Project
            {
                Title = title,
                Description = description,
                ProjectCategoryId = categoryId,
                StartDateUtc = startDate,
                EndDateUtc = endDate,
            };
        }


        private static void ValidateProject(ProjectDto projectDto, int? id, string title, string description, string category, DateTime startDate, DateTime endDate)
        {
            Assert.NotNull(projectDto);

            if (id != null)
                Assert.Equal(id, projectDto.Id);

            Assert.Equal(title, projectDto.Title);
            Assert.Equal(description, projectDto.Description);
            Assert.Equal(category, projectDto.ProjectCategory);
            Assert.Equal(startDate, projectDto.StartDate);

            if (endDate == DateTime.MinValue)
                Assert.Null(projectDto.EndDate);
            else
                Assert.Equal(endDate, projectDto.EndDate);
        }

        #endregion
    }
}
