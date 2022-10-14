using BlogAlternative.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BlogAlternative.DataAccessLayer.Concrete
{
    public class BlogAlternativeContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-0TJT8G1; Database = BlogAlternativeDB; Integrated Security = True;");

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }


    }
}
