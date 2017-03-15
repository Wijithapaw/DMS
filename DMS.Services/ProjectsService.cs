using DMS.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using DMS.Data.Entities;
using DMS.Data;
using DMS.Domain.Dtos;

namespace DMS.Services
{
    public class ProjectsService : IProjectsService
    {
        private DataContext _dataContext;

        public ProjectsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(ProjectDto projectDto)
        {
            var project = new Project
            {
                Title = projectDto.Title,
                Description = projectDto.Description,
                ProjectCategoryId = projectDto.ProjectCategoryId,
                StartDateUtc = projectDto.StartDate,
                EndDateUtc = projectDto.EndDate                
            };

            _dataContext.Projects.Add(project);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dataContext.Projects.Find(id);
            _dataContext.Projects.Remove(project);
            _dataContext.SaveChanges();
        }

        public ProjectDto Get(int id)
        {
            return _dataContext.Projects.Where(p => p.Id == id)
                    .Select(p => new ProjectDto
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        ProjectCategory = p.ProjectCategory.ShortDescription,
                        StartDate = p.StartDateUtc,
                        EndDate = p.EndDateUtc
                    }).FirstOrDefault();
        }

        public ICollection<ProjectDto> GetAll()
        {
            var projects = _dataContext.Projects
                    .Select(p => new ProjectDto
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
                        ProjectCategory = p.ProjectCategory.ShortDescription,
                        StartDate = p.StartDateUtc,
                        EndDate = p.EndDateUtc
                    }).ToList();

            return projects;
        }

        public ICollection<ProjectDto> GetAll(string category)
        {
            var projects = _dataContext.Projects
                    .Where(p => p.ProjectCategory.ShortDescription == category)
                     .Select(p => new ProjectDto
                     {
                         Id = p.Id,
                         Title = p.Title,
                         Description = p.Description,
                         ProjectCategory = p.ProjectCategory.ShortDescription,
                         StartDate = p.StartDateUtc,
                         EndDate = p.EndDateUtc
                     }).ToList();

            return projects;
        }

        public void Update(ProjectDto projectDto)
        {
            var project = _dataContext.Projects.Find(projectDto.Id);

            project.Title = projectDto.Title;
            project.Description = projectDto.Description;
            project.ProjectCategoryId = projectDto.ProjectCategoryId;
            project.StartDateUtc = projectDto.StartDate;
            project.EndDateUtc = projectDto.EndDate;

            _dataContext.SaveChanges();
        }
    }
}
