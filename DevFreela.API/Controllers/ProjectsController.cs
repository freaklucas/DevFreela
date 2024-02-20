using DevFreela.API.Models;
using DevFreela.Application.InputModels;
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
        var project = _projectsService.GetById(id);

        if (project == null)
        {
            return NotFound("Indentificador não encontrado.");
        }

        return Ok(project);
    }

    [HttpGet("GetAllComments")]
    public IActionResult GetCreatedComments()
    {
        var comments = _projectsService.GetCreatedComments();

        if (comments == null)
        {
            return NotFound("Comentários não encontrado.");
        }

        return Ok(comments);
    }

    [HttpPost]
    public IActionResult Post([FromBody] NewProjectInputModel inputModel)
    {
        if (inputModel.Title.Length > 50)
        {
            return BadRequest();
        }

        _projectsService.Create(inputModel);
        
        return Created();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProjectInputModel updateProject)
    {
        if (updateProject.Description.Length > 250)
        {
            return BadRequest();
        }

        _projectsService.Update(id, updateProject);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existsId = _projectsService.GetById(id);
        if (existsId == null)
        {
            return NotFound("Identificador não encontrado.");
        }
        
        _projectsService.Delete(id);
        // TODO: verificar inclusao de status cancelado ao invés de remover.
        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel createCommentModel)
    {
        _projectsService.CreateComment(createCommentModel);

        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        _projectsService.Start(id);

        return NoContent();
    }

    [HttpPut("{id}/finish")]
    public IActionResult Finish(int id)
    {
        _projectsService.Finish(id);
        return NoContent();
    }
}
