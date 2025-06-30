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

namespace unit_testing_routes_db_miniproject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProjectContext context)
        {
            if (context.Projects.Any())
            {
                return;
            }

            var projects = new Project[]
            {
                new Project {
                    Project_Name = "Video Shoot",
                    Length = 3,
                    isComplete = false,
                    ToDoTasks = new List<ToDoTask>()

                },
                new Project {
                    Project_Name = "Photo Shoot",
                    Length = 1,
                    isComplete = false,
                    ToDoTasks = new List<ToDoTask>()

                }
        };

            context.Projects.AddRange(projects);




            context.SaveChanges();
        }
    }
}

