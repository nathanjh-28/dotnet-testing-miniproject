///////////////////////////////////////////////////////////////////////////////
/// filename: ToDoTask.cs
/// author: Nathan Harris
/// date: 2025-06-23
/// description:
///    
/// error Handling:
/// usage:
///////////////////////////////////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace unit_testing_routes_db_miniproject.Models;

public class ToDoTask
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Task_Name { get; set; }

    public int Difficulty { get; set; }

    public bool isComplete { get; set; } = false;
}