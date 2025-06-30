///////////////////////////////////////////////////////////////////////////////
/// filename: Project.cs
/// author: Nathan Harris
/// date: 2025-06-23
/// description: file containing the Project model for app.
///    
/// error Handling:
/// usage:
///////////////////////////////////////////////////////////////////////////////
using System.ComponentModel.DataAnnotations;
namespace unit_testing_routes_db_miniproject.Models;


public class Project
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Project_Name { get; set; }

    public int Length { get; set; }

    public bool isComplete { get; set; } = false;

    public List<ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();


}

