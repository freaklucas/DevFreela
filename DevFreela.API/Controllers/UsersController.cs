using DevFreela.API.Models;
using DevFreela.Application.ViewModels;
using DevFreela.Infraestructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;
[Route("api/users")]
public class UsersController : Controller
{
    private readonly DevFreelaDbContext _dbContext;
    public UsersController(DevFreelaDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

        var user = _dbContext.Users.FirstOrDefault(p => p.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }



    [HttpPost]
    public IActionResult Post([FromBody] CreateUserModel createUserModel)
    {
        return Created();
    }

    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginModel login)
    {
        return NoContent(); //TODO Retornar token JWT.
    }
}