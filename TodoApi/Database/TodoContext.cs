using Microsoft.EntityFrameworkCore;
using TodoApi.Model;

namespace TodoApi.Database
{
    /// <summary>
    /// Represents the database context for managing Todo items.
    /// </summary>
    public class  TodoContext:DbContext
    {
        /// <summary>
        ///  initializes a TodoContext instance with the specified DbContextOptions.
        /// </summary>
        /// <param name="options">The options to be used by the context to facilitating configuration for database connection and behavior..</param>
        public TodoContext(DbContextOptions options) : base(options)
        {


        }
        /// <summary>
        /// representing a collection of Todo entities in the associated database.
        /// DbSet represents a collection of Todo entities and provides a way to query and perform CRUD operations on that Todo in the associated database.
        /// </summary>
        public DbSet<Todo> Todos { get; set; }
    }
}
