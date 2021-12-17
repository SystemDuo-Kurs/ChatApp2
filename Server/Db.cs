using ChatApp2.Shared;
using Microsoft.EntityFrameworkCore;


namespace ChatApp2.Server
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> o) : base(o) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().HasKey(m => m.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages);
        }
    }
}
