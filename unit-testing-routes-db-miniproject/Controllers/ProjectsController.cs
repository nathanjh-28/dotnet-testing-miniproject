using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace unit_testing_routes_db_miniproject.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Hello, World!");
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid ID provided.");
        }
        else
        {
            return Ok($"Project with ID {id} retrieved successfully.");
        }
    }

}