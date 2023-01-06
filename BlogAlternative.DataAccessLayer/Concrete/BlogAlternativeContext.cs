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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllMessage>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<AllMessage>()
                .HasOne(x => x.ReceiverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRayting> BlogRaytings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AllMessage> AllMessages { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
