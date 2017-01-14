using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Domain.Entities;
using DMS.Domain;
using DMS.Data;

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

        public Project Get(int id)
        {
            return _dataContext.Projects.Find(id);
        }

        public ICollection<Project> GetAll()
        {
            return _dataContext.Projects.ToList();
        }

        public ICollection<Project> GetAll(string category)
        {
            var projects = _dataContext.ProjectCategories.Where(c => c.ShortDescription == category).Select(c => c.Projects).FirstOrDefault();
                 
            
            //var projs = project.Projects.ToList();                 

            return projects;
        }

        public Project Update(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
