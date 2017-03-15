using DMS.Domain.Dtos;
using DMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
