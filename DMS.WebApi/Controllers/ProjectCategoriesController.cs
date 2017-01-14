using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DMS.Domain.Services;
using DMS.Domain.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectCategoriesController : Controller
    {
        private IProjectCategoryService _projectCategoryService;

        public ProjectCategoriesController(IProjectCategoryService projectCategoryService)
        {
            _projectCategoryService = projectCategoryService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ProjectCategory> Get()
        {
            return _projectCategoryService.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ProjectCategory Get(int id)
        {
            return _projectCategoryService.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
