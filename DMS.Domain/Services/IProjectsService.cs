using DMS.Domain.Dtos;
using DMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.Domain.Services
{
    public interface IProjectsService
    {
        void Create(ProjectDto project);

        void Delete(int id);

        ProjectDto Get(int id);

        ICollection<ProjectDto> GetAll();

        ICollection<ProjectDto> GetAll(string category);

        void Update(ProjectDto project);
    }
}
