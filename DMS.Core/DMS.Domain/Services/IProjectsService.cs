using DMS.Domain.Dtos;
using System.Collections.Generic;

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
