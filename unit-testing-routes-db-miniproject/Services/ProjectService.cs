///////////////////////////////////////////////////////////////////////////////
/// filename: 
/// author: Nathan Harris
/// date: 2025-06-23
/// description:
///    
/// error Handling:
/// usage:
///////////////////////////////////////////////////////////////////////////////

using unit_testing_routes_db_miniproject.Models;
using unit_testing_routes_db_miniproject.Data;
using Microsoft.EntityFrameworkCore;

namespace unit_testing_routes_db_miniproject.Services;

public class ProjectService
{
    private readonly ProjectContext _context;

    public ProjectService(ProjectContext context)
    {
        _context = context;
    }

    ///////////// Get

    // get all projects

    public IEnumerable<Project> GetAllProjects()
    {
        return _context.Projects
            .AsNoTracking()
            .ToList();
    }

    // get project by id

    public Project? GetProjectById(int id)
    {
        return _context.Projects
            .Include(p => p.ToDoTasks)
            .AsNoTracking()
            .SingleOrDefault(p => p.Id == id);
    }
    // get task by id

    public ToDoTask? GetToDoTaskById(int id)
    {
        return _context.ToDoTasks
            .AsNoTracking()
            .SingleOrDefault(t => t.Id == id);
    }

    // get all tasks for a project

    public IEnumerable<ToDoTask> GetToDoTasksByProjectId(int projectId)
    {
        return _context.ToDoTasks
            .Where(t => t.Id == projectId)
            .AsNoTracking()
            .ToList();
    }

    ///////////// CRUD

    // create a new project

    public Project CreateProject(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
        return project;
    }

    // update an existing project
    public void UpdateProject(int id, Project updatedProject)
    {
        var existingProject = _context.Projects.Find(id);

        if (existingProject == null || updatedProject == null)
        {
            throw new InvalidOperationException("project or updated project does not exist.");
        }

        existingProject.Project_Name = updatedProject.Project_Name;
        existingProject.Length = updatedProject.Length;
        existingProject.isComplete = updatedProject.isComplete;
        existingProject.ToDoTasks = updatedProject.ToDoTasks;

        _context.SaveChanges();
    }

    // delete a project

    public void DeleteById(int id)
    {
        var projectToDelete = _context.Projects.Find(id);
        if (projectToDelete is not null)
        {
            _context.Projects.Remove(projectToDelete);
            _context.SaveChanges();
        }
    }

    // create a new task for a project

    public void AddTask(int projectId, ToDoTask new_task)
    {
        var project = _context.Projects.Find(projectId);

        if (project == null || new_task == null)
        {
            throw new InvalidOperationException("Project or task cannot be null.");
        }

        project.ToDoTasks.Add(new_task);
        _context.SaveChanges();

    }

    // mark a task as complete for a project

    public void MarkTaskAsComplete(int taskId)
    {
        var task_to_complete = _context.ToDoTasks.Find(taskId);

        if (task_to_complete is null)
        {
            throw new InvalidOperationException("todotask does not exist.");
        }

        else if (task_to_complete.isComplete == true)
        {
            throw new InvalidOperationException("task is already complete");
        }
        else
        {
            task_to_complete.isComplete = true;
            _context.SaveChanges();
        }

    }

    // mark a task as incomplete for a project

    /////////// If time permits

    // update an existing task for a project

    // delete a task for a project


}