using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using unit_testing_routes_db_miniproject.Data;
using unit_testing_routes_db_miniproject.Services;
using unit_testing_routes_db_miniproject.Models;

namespace unit_testing_routes_db_miniproject.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    ProjectService _service;

    public ProjectsController(ProjectService service)
    {
        _service = service;
    }


    [HttpGet]
    public ActionResult Get()
    {
        var projects = _service.GetAllProjects();
        return Ok(projects);
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