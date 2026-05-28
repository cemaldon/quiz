using Microsoft.EntityFrameworkCore;
using RazorQuizDemo.Models;

namespace RazorQuizDemo.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        public DbSet<QuizQuestion> Questions { get; set; }
    }
}
