using DMS.Domain.Dtos;
using System.Collections.Generic;

namespace DMS.Domain.Services
{
    public interface IProjectCategoryService
    {
        void Create(ProjectCategoryDto project);

        void Delete(int id);

        ProjectCategoryDto Get(int id);

        ICollection<ProjectCategoryDto> GetAll();

        void Update(ProjectCategoryDto project);
    }
}
