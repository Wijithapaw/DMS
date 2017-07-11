using DMS.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using DMS.Data.Entities;
using DMS.Data;
using DMS.Domain.Dtos;

namespace DMS.Services
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        private DataContext _dataContext;

        public ProjectCategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Create(ProjectCategoryDto projectCategoryDto)
        {
            var projectCategory = new ProjectCategory
            {
                ShortDescription = projectCategoryDto.ShortDescription,
                Description = projectCategoryDto.Description
            };

            _dataContext.ProjectCategories.Add(projectCategory);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var projectCategory = _dataContext.ProjectCategories.Find(id);
            _dataContext.ProjectCategories.Remove(projectCategory);
            _dataContext.SaveChanges();
        }

        public ProjectCategoryDto Get(int id)
        {
            var projectCategory = _dataContext.ProjectCategories
                                        .Where(c => c.Id == id)
                                        .Select(c => new ProjectCategoryDto
                                        {
                                            Id = c.Id,
                                            ShortDescription = c.ShortDescription,
                                            Description = c.Description
                                        }).FirstOrDefault();
            return projectCategory;
        }

        public ICollection<ProjectCategoryDto> GetAll()
        {
            var categories = _dataContext.ProjectCategories
                .Select(c => new ProjectCategoryDto
                {
                    ShortDescription = c.ShortDescription,
                    Description = c.Description
                }).ToList();

            return categories;
        }

        public void Update(ProjectCategoryDto categoryDto)
        {
            var category = _dataContext.ProjectCategories.Find(categoryDto.Id);

            category.ShortDescription = categoryDto.ShortDescription;
            category.Description = categoryDto.Description;

            _dataContext.SaveChanges();
        }
    }
}
