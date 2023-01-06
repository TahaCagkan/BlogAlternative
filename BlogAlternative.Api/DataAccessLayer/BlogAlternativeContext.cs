using Microsoft.EntityFrameworkCore;

namespace BlogAlternative.Api.DataAccessLayer
{
    public class BlogAlternativeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0TJT8G1; Database = BlogAlternativeDB; Integrated Security = True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
