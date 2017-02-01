using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DMS.Domain.Services;
using DMS.Domain.Entities;
using DMS.Domain.Dtos;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DMS.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ProjectDto> Get()
        {
            return _projectsService.GetAll();            
        }

        [Route("GetByCategory")]
        public IEnumerable<Project> Get([FromQuery] string category)
        {
            return _projectsService.GetAll(category);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ProjectDto Get(int id)
        {
            var project = _projectsService.Get(id);
            return project;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Project project)
        {
            _projectsService.Create(project);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]ProjectDto project)
        {
            _projectsService.Update(project);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
