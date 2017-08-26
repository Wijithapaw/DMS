using DMS.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using DMS.Data.Entities;
using DMS.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DMS.Domain.Dtos.Project;

namespace DMS.Services
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        private DataContext _dataContext;

        public ProjectCategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<int> CreateAsync(ProjectCategoryDto projectCategoryDto)
        {
            var projectCategory = new ProjectCategory
            {
                Title = projectCategoryDto.ShortDescription,
                Description = projectCategoryDto.Description
            };

            _dataContext.ProjectCategories.Add(projectCategory);
            await _dataContext.SaveChangesAsync();
            return projectCategory.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var projectCategory = _dataContext.ProjectCategories.Find(id);
            _dataContext.ProjectCategories.Remove(projectCategory);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<ProjectCategoryDto> GetAsync(int id)
        {
            var projectCategory = await _dataContext.ProjectCategories
                                        .Where(c => c.Id == id)
                                        .Select(c => new ProjectCategoryDto
                                        {
                                            Id = c.Id,
                                            ShortDescription = c.Title,
                                            Description = c.Description
                                        }).FirstOrDefaultAsync();
            return projectCategory;
        }

        public async Task<ICollection<ProjectCategoryDto>> GetAllAsync()
        {
            var categories = await _dataContext.ProjectCategories
                .Select(c => new ProjectCategoryDto
                {
                    ShortDescription = c.Title,
                    Description = c.Description
                }).ToListAsync();

            return categories;
        }

        public async Task UpdateAsync(ProjectCategoryDto categoryDto)
        {
            var category = _dataContext.ProjectCategories.Find(categoryDto.Id);

            category.Title = categoryDto.ShortDescription;
            category.Description = categoryDto.Description;

            await _dataContext.SaveChangesAsync();
        }
    }
}
