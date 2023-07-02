// Import the necessary namespaces
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Define the namespace in which our models reside
namespace GoogleBooksApp.Models
{
    // IdentityContext inherits from IdentityDbContext, a class provided by ASP.NET Core 
    // Identity that extends the base DbContext and includes built-in entity configurations 
    // for Identity's models such as User, Role, etc.
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        // Constructor that accepts a DbContextOptions<IdentityContext> object, which 
        // is used to configure the DbContext such as setting the connection string, 
        // enabling lazy loading, etc. The options object is typically created and passed 
        // in the Startup.cs file's ConfigureServices method, where services such as the DbContext 
        // are registered for dependency injection.
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
    }
}
