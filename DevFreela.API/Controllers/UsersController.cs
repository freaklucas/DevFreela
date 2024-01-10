using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;
[Route("api/users")]
public class UsersController : Controller
{
    public UsersController(ExampleClass exampleClass)
    {
        
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
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