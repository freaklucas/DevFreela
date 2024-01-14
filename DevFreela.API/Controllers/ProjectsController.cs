using DevFreela.API.Models;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]

public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectsService;
    public ProjectsController(IProjectService projectService)
    {
        _projectsService = projectService;
    }

    [HttpGet]
    public IActionResult Get(string query)
    {
        var projects = _projectsService.GetAll(query);

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post([FromBody] CreateProjectModel createProject)
    {
        if (createProject.Title.Length > 50)
        {
            return BadRequest();
        }

        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectModel updateProject)
    {
        if (updateProject.Description.Length > 250)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id, [FromBody] CreateCommentModel createCommentModel)
    {
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id)
    {
        return NoContent();
    }
}
