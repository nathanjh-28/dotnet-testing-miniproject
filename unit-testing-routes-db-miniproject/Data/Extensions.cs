///////////////////////////////////////////////////////////////////////////////
/// filename: 
/// author: Nathan Harris
/// date: 2025-06-23
/// description:
///    
/// error Handling:
/// usage:
///////////////////////////////////////////////////////////////////////////////

namespace unit_testing_routes_db_miniproject.Data;

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ProjectContext>();
                context.Database.EnsureCreated();
                DbInitializer.Initialize(context);
            }
        }
    }
}