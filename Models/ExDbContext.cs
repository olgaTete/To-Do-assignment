using Console_core.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Console_core.Models
{
    public class ExDbContext: DbContext
    {
            public ExDbContext(DbContextOptions<ExDbContext> options) : base(options)
            { }
            public DbSet<Person> People { get; set; }
            public DbSet<Todo> Todos { get; set; }
    }
}
