using Microsoft.EntityFrameworkCore;

namespace QuizManagementSystem_1.Models
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasKey(q => q.Qid); // Define primary key here
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=MANISHASHINDE37\\SQLEXPRESS;Initial Catalog=Quiz1;Integrated Security=True;");
            }
        }
        

    }
}
