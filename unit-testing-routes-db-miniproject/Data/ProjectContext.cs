///////////////////////////////////////////////////////////////////////////////
/// filename: ProjectContext.cs
/// author: Nathan Harris
/// date: 2025-06-23
/// description: 
///    
/// error Handling: 
/// usage:
///////////////////////////////////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using unit_testing_routes_db_miniproject.Models;

namespace unit_testing_routes_db_miniproject.Data;

public class ProjectContext : DbContext
{
    public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
    {

    }

    // DbSets

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ToDoTask> ToDoTasks => Set<ToDoTask>();


}