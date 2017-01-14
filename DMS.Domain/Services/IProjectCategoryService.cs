using DMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Domain.Services
{
    public interface IProjectCategoryService
    {
        void Create(ProjectCategory project);

        void Delete(int id);

        ProjectCategory Get(int id);

        ICollection<ProjectCategory> GetAll();

        void Update(ProjectCategory project);
    }
}
