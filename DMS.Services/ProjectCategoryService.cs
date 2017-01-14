using DMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMS.Domain.Entities;
using DMS.Data;

namespace DMS.Services
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        private DataContext _dataContext;

        public ProjectCategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Create(ProjectCategory project)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectCategory Get(int id)
        {
            return _dataContext.ProjectCategories.Find(id);
        }

        public ICollection<ProjectCategory> GetAll()
        {
            return _dataContext.ProjectCategories.ToList();
        }

        public void Update(ProjectCategory project)
        {
            throw new NotImplementedException();
        }
    }
}
