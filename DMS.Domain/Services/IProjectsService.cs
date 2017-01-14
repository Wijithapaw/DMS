using DMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Domain.Services
{
    public interface IProjectsService
    {
        void Create(Project project);

        void Delete(int id);

        Project Get(int id);

        ICollection<Project> GetAll();

        ICollection<Project> GetAll(string category);

        Project Update(Project project);
    }
}
