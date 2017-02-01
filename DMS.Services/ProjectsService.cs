using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Domain.Entities;
using DMS.Domain;
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

        public void Create(Project project)
        {
            _dataContext.Projects.Add(project);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectDto Get(int id)
        {
            return _dataContext.Projects.Where(p => p.Id == id)
                    .Select(p => new ProjectDto
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Description = p.Description,
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
                        StartDate = p.StartDateUtc,
                        EndDate = p.EndDateUtc
                    }).ToList();

            return projects;
        }

        public ICollection<Project> GetAll(string category)
        {
            var projects = _dataContext.ProjectCategories.Where(c => c.ShortDescription == category).Select(c => c.Projects).FirstOrDefault();
                 
            
            //var projs = project.Projects.ToList();                 

            return projects;
        }

        public void Update(ProjectDto projectDto)
        {
            var project = new Project
            {
                Id = projectDto.Id,
                Title = projectDto.Title,
                Description = projectDto.Description,
                StartDateUtc = projectDto.StartDate,
                EndDateUtc = projectDto.EndDate
            };

            _dataContext.Update(project);

            _dataContext.SaveChanges();
        }
    }
}
